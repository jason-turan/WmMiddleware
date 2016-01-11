using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
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

                var integrationTask = connection.Query<IntegrationTask>(integrationTaskSql, integration).FirstOrDefault();

                if (integrationTask == null) return null;

                integrationTask.Source = GetEndpoint(connection, integrationTask.SourceTypeId);
                integrationTask.Destination = GetEndpoint(connection, integrationTask.DestinationTypeId);
                return integrationTask;
            }
        }

        private static IntegrationTaskEndpoint GetEndpoint(IDbConnection connection, int endpointId)
        {
            const string integrationEndpointConfigurationSql = @"
                SELECT 
	                itec.ConfigurationValue,
	                itet.IntegrationTaskEndpointTypeName,
	                itect.IntegrationTaskEndpointConfigurationType
                FROM IntegrationTaskEndpoint ite
                JOIN IntegrationTaskEndpointType itet 
                    ON ite.IntegrationTaskEndpointTypeId = itet.IntegrationTaskEndpointTypeId
                JOIN IntegrationTaskEndpointConfigurationType itect 
                    ON itect.IntegrationTaskEndpointTypeId = itet.IntegrationTaskEndpointTypeId
                LEFT JOIN IntegrationTaskEndpointConfiguration itec 
                    ON itec.IntegrationTaskEndpointId = ite.IntegrationTaskEndpointId 
                    AND itec.IntegrationTaskEndpointConfigurationTypeId = itect.IntegrationTaskEndpointConfigurationTypeId
                WHERE ite.IntegrationTaskEndpointId = @IntegrationTaskEndpointId";


            var integrationConfiguration = new DynamicParameters();
            integrationConfiguration.Add("@IntegrationTaskEndpointId", endpointId);

            var rows = connection.Query<ConfigurationRow>(integrationEndpointConfigurationSql, new {IntegrationTaskEndpointId = endpointId}).ToList();
            var integrationTaskEndpoint = new IntegrationTaskEndpoint
            {
                EndpointType = (IntegrationTaskEndpointType) Enum.Parse(typeof (IntegrationTaskEndpointType), rows.First().IntegrationTaskEndpointTypeName),
                EndpointConfigurations = rows.Select(r => r.ToEndpointConfiguration()).ToList()
            };

            return integrationTaskEndpoint;
        }

        [SuppressMessage("ReSharper", "ClassNeverInstantiated.Local")]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        private class ConfigurationRow
        {
            public string ConfigurationValue { get; set; }
            public string IntegrationTaskEndpointTypeName { get; set; }
            public string IntegrationTaskEndpointConfigurationType { get; set; }

            public IntegrationTaskEndpointConfiguration ToEndpointConfiguration()
            {
                return new IntegrationTaskEndpointConfiguration
                {
                    ConfigurationValue = ConfigurationValue,
                    ConfigurationType = (ConfigurationType) Enum.Parse(typeof(ConfigurationType), IntegrationTaskEndpointConfigurationType)
                };
            }
        }
    }
}
