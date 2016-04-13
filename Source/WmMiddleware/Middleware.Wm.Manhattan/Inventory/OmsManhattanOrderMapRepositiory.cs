using System;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Configuration.Database;

namespace Middleware.Wm.Manhattan.Inventory
{
    public class OmsManhattanOrderMapRepositiory : IOmsManhattanOrderMapRepository
    {

        public void InsertOmsManhattanOrderMapRepository(OmsManhattanOrderMap omsManhattanOrderMap)
        {
            const string insertOmsOrderMap = @"INSERT INTO [dbo].[OmsManhattanOrderMap]
                                                            ([OMSOrderNumber]
                                                            ,[WmOrderNumber]
                                                            ,[Created]
                                                            ,[Company])
                                                            VALUES
                                                            (@OMSOrderNumber
                                                            ,@WmOrderNumber
                                                            ,@Created
                                                            ,@Company)";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                connection.Execute(insertOmsOrderMap, omsManhattanOrderMap);
            }
        }

        public OmsManhattanOrderMap GetOmsManhattanOrderMap(OmsManhattanOrderMapFindCriteria criteria)
        {
            const string findOmsManhattanOrder = @"SELECT [OMSOrderNumber]
                                                            ,[WmOrderNumber]
                                                            ,[Created]
                                                            ,[Company]
                                                   FROM OmsManhattanOrderMap
                                                   WHERE OMSOrderNumber = @OmsOrderNumber
                                                   OR WmOrderNumber = @WmOrderNumber";

            var parameters = new DynamicParameters();
            parameters.Add("@OmsOrderNumber", criteria.OmsOrderNumber);
            parameters.Add("@WmOrderNumber", criteria.ManhattanOrderNumber);

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Open();
                return connection.Query<OmsManhattanOrderMap>(findOmsManhattanOrder, parameters).SingleOrDefault();
            }
        }
    }
}
