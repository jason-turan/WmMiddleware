using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Middleware.Integration.Models;
using WmMiddleware.Configuration.Database;

namespace Middleware.Integration.Repositories
{
    public class IntegrationTaskRespository : IIntegrationTaskRespository
    {
        public IntegrationTask GetTask(int jobId)
        {
            IntegrationTask integrationTask = null;
            const string integrationTaskSql = @"SELECT it.* 
                                                FROM Job j
                                                INNER JOIN IntegrationTask it
	                                                ON j.JobId = it.JobId 
                                                WHERE j.JobId = @JobId";
            
            var integration = new DynamicParameters();
            integration.Add("@JobId", jobId, DbType.Int32);
            
            using (var connection = DatabaseConnectionFactory.GetIntegrationManagementConnection())
            {
                connection.Open();

                integrationTask = connection.Query<IntegrationTask>(integrationTaskSql, integration).FirstOrDefault();

                if (integrationTask == null) return null;

                integrationTask.Source = GetEndpoint(connection, integrationTask.IntegrationTaskId, integrationTask.SourceTypeId);
                integrationTask.Destination = GetEndpoint(connection, integrationTask.IntegrationTaskId, integrationTask.DestinationTypeId);
            }

            return integrationTask;
        }

        private static IntegrationTaskEndpoint GetEndpoint(IDbConnection connection, int integrationTaskId, IntegrationTaskEndpointType endpointTypeId)
        {
            IntegrationTaskEndpoint integrationTaskEndpoint = null;
            
            const string integrationEndpointConfiguration = @"SELECT ep.IntegrationTaskEndpointId,
	                                                                 ct.IntegrationTaskConfigurationTypeId,
	                                                                 config.ConfigurationValue,
                                                                     config.IntegrationTaskId
                                                              FROM IntegrationTaskEndpointConfigurationType ct
                                                              INNER JOIN IntegrationTaskEndpointConfiguration config
	                                                              ON config.IntegrationTaskConfigurationTypeId = ct.IntegrationTaskConfigurationTypeId
                                                              INNER JOIN IntegrationTaskEndpoint ep
	                                                              ON ep.IntegrationTaskEndpointId = ct.IntegrationTaskEndpointId
                                                              WHERE config.IntegrationTaskId = @IntegrationTaskId
                                                              AND ep.IntegrationTaskEndpointId = @IntegrationTaskEndpointId";


            var integrationConfiguration = new DynamicParameters();
            integrationConfiguration.Add("@IntegrationTaskId", integrationTaskId);
            integrationConfiguration.Add("@IntegrationTaskEndpointId", endpointTypeId);

                using (var reader = connection.ExecuteReader(integrationEndpointConfiguration, integrationConfiguration))
                {
                    while (reader.Read())
                    {
                        if (integrationTaskEndpoint == null)
                        {
                            integrationTaskEndpoint = new IntegrationTaskEndpoint
                            {
                                EndpointType = (IntegrationTaskEndpointType)reader["IntegrationTaskEndpointId"],
                                EndpointConfigurations = new List<IntegrationTaskEndpointConfiguration>()
                            };
                        }

                        integrationTaskEndpoint.EndpointConfigurations.Add(new IntegrationTaskEndpointConfiguration
                        {
                            ConfigurationValue = reader["ConfigurationValue"] as string,
                            IntegrationTaskEndpointConfigurationType =
                                (IntegrationTaskEndpointConfigurationType) reader["IntegrationTaskConfigurationTypeId"],
                            IntegrationTaskId = (int) reader["IntegrationTaskId"]
                        });
                    }
            }

            return integrationTaskEndpoint;
        }
    }
}
