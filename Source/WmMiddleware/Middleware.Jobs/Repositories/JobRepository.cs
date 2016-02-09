using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WmMiddleware.Configuration.Database;
using Middleware.Jobs.Models;

namespace Middleware.Jobs.Repositories
{
    public class JobRepository : IJobRepository
    {
        private const string JobQuery = @"SELECT  JobId
                                                 ,JobKey
                                                 ,Schedule
                                                 ,JobExecutable
                                                 ,IsActive
                                                 ,LastRunExecutionTime
                                                 ,LastRunStatus
                                                 ,LastRunDateTime
                                                 ,NextRunDateTime
                                                 ,JobType
                                                 ,IsAlerted
                                         FROM [dbo].[Job]";

        public MiddlewareJob GetJob(string jobKey)
        {
            var selectMiddlewareJob = JobQuery + @" WHERE JobKey = '" + jobKey + "'";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                var result = connection.Query<MiddlewareJob>(selectMiddlewareJob).FirstOrDefault();
                if (result == null)
                {
                    throw new ArgumentException("Could not find job with key: " + jobKey);
                }

                return result;
            }
        }

        public MiddlewareJob GetJobByExecutable(string executableName)
        {
            var selectMiddlewareJob = JobQuery + @" WHERE JobExecutable = '" + executableName + "'";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                var result = connection.Query<MiddlewareJob>(selectMiddlewareJob).FirstOrDefault();
                if (result == null)
                {
                    throw new ArgumentException("Could not find job with executable name: " + executableName);
                }

                return result;
            }
        }

        public MiddlewareJob GetLastSuccessfulJobExecution(string jobKey)
        {
            const string selectMiddlewareJob = @"SELECT TOP 1   j.JobId
                                                               ,j.JobKey
                                                               ,j.Schedule
                                                               ,j.JobExecutable
                                                               ,j.IsActive
                                                               ,j.LastRunExecutionTime
                                                               ,j.LastRunStatus
                                                               ,j.LastRunDateTime
                                                               ,j.NextRunDateTime
                                                               ,j.JobType
                                                               ,j.IsAlerted
                                                        FROM Job j
                                                        INNER JOIN JobHistory jh
                                                            ON j.JobId = jh.JobId
                                                        WHERE jh.RunStatus = 'SUCCESS' 
                                                        ORDER BY JobHistoryId DESC";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                var result = connection.Query<MiddlewareJob>(selectMiddlewareJob).FirstOrDefault();
                return result;
            }
        }

        public void InsertJob(MiddlewareJob job)
        {
            const string insertMiddlewareJob = @"INSERT INTO [dbo].[Job]
                                                            ([JobKey]
                                                            ,[Schedule]
                                                            ,[JobExecutable]
                                                            ,[IsActive]
                                                            ,[LastRunExecutionTime]
                                                            ,[LastRunStatus]
                                                            ,[LastRunDateTime]
                                                            ,[NextRunDateTime]
                                                            ,[IsAlerted])
                                                            VALUES
                                                            (@JobKey
                                                            ,@Schedule
                                                            ,@JobExecutable
                                                            ,@IsActive
                                                            ,@LastRunExecutionTime
                                                            ,@LastRunStatus
                                                            ,@LastRunDateTime
                                                            ,@NextRunDateTime
                                                            ,@IsAlerted)";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();

                connection.Execute(insertMiddlewareJob, job);
            }
        }

        public void InsertJobHistory(MiddlewareJobHistory jobHistory)
        {
                  const string insertMiddlewareJobHistory = @"INSERT INTO [dbo].[JobHistory]
                                                            ([JobId]
                                                            ,[RunStatus]
                                                            ,[RunDate]
                                                            ,[MachineName]
                                                            ,[UserName])
                                                            VALUES
                                                            (@JobId
                                                            ,@RunStatus
                                                            ,@RunDate
                                                            ,@MachineName
                                                            ,@UserName)";

                using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                connection.Execute(insertMiddlewareJobHistory, jobHistory);
            }
        }

        public IEnumerable<MiddlewareJob> GetJobs()
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                return connection.Query<MiddlewareJob>(JobQuery);
            }
        }

        public void UpdateJobActiveInactive(int jobId, bool isActive)
        {
            const string update = @"UPDATE [Job]
                                    SET   IsActive = @IsActive
                                    WHERE JobId = @JobId";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();
                var dynamicParmaters = new DynamicParameters();
                dynamicParmaters.Add("@JobId", jobId);
                dynamicParmaters.Add("@IsActive", isActive);

                connection.Execute(update, dynamicParmaters);
            }
        }

        public void UpdateJob(MiddlewareJob job)
        {
            const string updateMiddlewareJob = @"UPDATE [Job]
                                                 SET Schedule = @Schedule,
                                                     JobExecutable = @JobExecutable,
	                                                 IsActive = @IsActive,
                                                     LastRunExecutionTime = @LastRunExecutionTime,
	                                                 JobKey = @JobKey,
                                                     LastRunStatus = @LastRunStatus,
                                                     LastRunDateTime = @LastRunDateTime,
                                                     NextRunDateTime = @NextRunDateTime,
                                                     JobType = @JobType,
                                                     IsAlerted = @IsAlerted
                                                 WHERE JobId = @JobId";

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();

                connection.Execute(updateMiddlewareJob, job);
            }
        }

        public int? GetJobIdByFilePrefix(string filePrefix)
        {
            const string getJobIdByFilePrefix =
                @"SELECT j.JobId 
                  FROM Job j
                  INNER JOIN TransferControlFileType fcft
	                ON j.JobId = fcft.JobId
                  WHERE  FilePrefix = @FilePrefix
                  AND JobType = 'Outbound'";

            var jobArguments = new DynamicParameters();
            jobArguments.Add("@FilePrefix", filePrefix, DbType.String);

            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();

                return connection.ExecuteScalar<int?>(getJobIdByFilePrefix, jobArguments);
            }
        }

        public int DeleteJobHistoryByDate(DateTime deleteOlderThanDate)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementConnection())
            {
                connection.Open();

                return connection.Execute("DELETE FROM JobHistory WHERE RunDate < '" + 
                                          deleteOlderThanDate.Date + 
                                          "'");
            }
        }
    }
}
