using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Middleware.Jobs.Models;
using Middleware.Wm.Configuration.Database;
using Middleware.Wm.TransferControl.Models;

namespace Middleware.Wm.TransferControl.Repositories
{
    public class TransferControlRepository : ITransferControlRepository
    {
        public const string InboundAurora = "AuroraInbound";
        public const string InboundManhattan = "ManhattanInbound";
        public const string Outbound = "Outbound";

        private const string SelectTransferControlSql = @"SELECT [TransferControlId]
                                                                ,j.[JobId]
                                                                ,[BatchControlNumber]
                                                                ,[ReceivedDate]
                                                                ,[ProcessedDate] 
                                                         FROM TransferControl tc
                                                         INNER JOIN Job j ON j.JobId = tc.JobId";

        public Models.TransferControl GetTransferControl(int transferControlId)
        {
            var whereClause = " WHERE TransferControlId = " + transferControlId;

            string selectTransferControlFileSql = @"SELECT [TransferControlFileId]
                                                                ,[TransferControlId]
                                                                ,[FileLocation]
                                                    FROM TransferControlFile" +
                                                    whereClause;

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();

                var transferControl = connection.Query<Models.TransferControl>(SelectTransferControlSql + whereClause).FirstOrDefault();

                if (transferControl != null)
                {
                    transferControl.Files = connection.Query<TransferControlFile>(selectTransferControlFileSql).ToList();
                }

                return transferControl;
            }
        }

        public IEnumerable<Models.TransferControl> FindTransferControls(TransferControlSearchCriteria transferControlSearchCriteria)
        {
            const string selectTransferControlFileSql = @"SELECT [TransferControlFileId]
                                                                ,[TransferControlId]
                                                                ,[FileLocation]
                                                          FROM TransferControlFile";

            var  selectTransferControl = SelectTransferControlSql + @" WHERE (@Processed IS NULL 
                                                                              OR (@Processed = 1 AND ProcessedDate IS NOT NULL)
                                                                              OR (@Processed = 0 AND ProcessedDate IS NULL))
                                                                       AND (j.JobId = @JobId OR @JobId IS NULL)";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();

                var searchArguments = new DynamicParameters();
                searchArguments.Add("@Processed", transferControlSearchCriteria.Processed, DbType.Boolean);
                searchArguments.Add("@JobId", transferControlSearchCriteria.JobId, DbType.Int32);

                selectTransferControl = SetJobTypeParameter(transferControlSearchCriteria, selectTransferControl);

                var transferControls = connection.Query<Models.TransferControl>(selectTransferControl, searchArguments);

                var enumerable = transferControls as Models.TransferControl[] ?? transferControls.ToArray();

                foreach (var transferControl in enumerable)
                {
                    transferControl.Files =
                        connection.Query<TransferControlFile>(selectTransferControlFileSql +
                                                              " WHERE TransferControlId = " +
                                                              transferControl.TransferControlId).ToList();
                }

                return enumerable;
            }
        }

        public void UpdateTransferControl(Models.TransferControl transferControl)
        {
            const string updateTransferControl = @"UPDATE TransferControl
                                                   SET [JobId] = @JobId
                                                        ,[BatchControlNumber] = @BatchControlNumber
                                                        ,[ReceivedDate] = @ReceivedDate
                                                        ,[ProcessedDate] =@ProcessedDate
                                                   WHERE TransferControlid = @TransferControlId";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();

                connection.Execute(updateTransferControl, transferControl);
            }
        }

        public int InsertTransferControl(Models.TransferControl transferControl)
        {
            int transferControlId;

            const string insertTransferControlSql = @"INSERT INTO TransferControl
                                                    ([JobId]
                                                    ,[BatchControlNumber]
                                                    ,[ReceivedDate]
                                                    ,[ProcessedDate]) 
                                                    VALUES
                                                    (@JobId
                                                    ,@BatchControlNumber
                                                    ,@ReceivedDate
                                                    ,@ProcessedDate)
                                                    SELECT CAST(SCOPE_IDENTITY() as int)";

            const string insertTransferControlFileSql = @"INSERT INTO TransferControlFile
                                                       ( [TransferControlId]
                                                        ,[FileLocation] )
                                                       VALUES 
                                                       (@TransferControlId,
                                                        @FileLocation)";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();

                transferControlId = connection.Query<int>(insertTransferControlSql, transferControl).Single();

                foreach (var controlFile in transferControl.Files)
                {
                    controlFile.TransferControlId = transferControlId;
                    connection.Execute(insertTransferControlFileSql, controlFile);
                }
            }

            return transferControlId;
        }

        private static string SetJobTypeParameter(TransferControlSearchCriteria transferControlSearchCriteria,
                                                  string selectTransferControl)
        {
            switch (transferControlSearchCriteria.JobType)
            {
                case JobType.AuroraInbound:
                    selectTransferControl = selectTransferControl + " AND j.JobType = '" + InboundAurora + "'";
                    break;
                case JobType.ManhattanInbound:
                    selectTransferControl = selectTransferControl + " AND j.JobType = '" + InboundManhattan + "'";
                    break;
                case JobType.Outbound:
                    selectTransferControl = selectTransferControl + " AND j.JobType = '" + Outbound + "'";
                    break;
            }
            return selectTransferControl;
        }
    }
}
