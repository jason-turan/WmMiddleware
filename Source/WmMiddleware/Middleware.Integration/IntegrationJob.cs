using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using Middleware.Integration.Factories;
using Middleware.Integration.Repositories;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;

namespace Middleware.Integration
{
    public class IntegrationJob : IUnitOfWork
    {
        private readonly ILog _log;
        private readonly IIntegrationTaskRespository _integrationTaskRespository;
        private readonly IJobRepository _jobRepository;
        private readonly IXmlRepositoryFactory _xmlRepositoryFactory;

        public IntegrationJob(ILog log, 
                              IIntegrationTaskRespository integrationTaskRespository, 
                              IJobRepository jobRepository,
                              IXmlRepositoryFactory xmlRepositoryFactory)
        {
            _log = log;
            _integrationTaskRespository = integrationTaskRespository;
            _jobRepository = jobRepository;
            _xmlRepositoryFactory = xmlRepositoryFactory;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var job = _jobRepository.GetJob(jobKey);
            var integrationTask = _integrationTaskRespository.GetTask(job.JobId);

            var reader = _xmlRepositoryFactory.CreateReader(integrationTask.Source);
            var xml = reader.Read();

            var transform = new XslCompiledTransform();
            transform.Load(XmlReader.Create(File.OpenRead(Path.Combine("./Resources/Xslt", integrationTask.XsltTransformName))));
            var newXml = new XDocument();
            using (XmlWriter xmlWriter = newXml.CreateWriter())
            {
                transform.Transform(xml.CreateReader(), xmlWriter);
            }

            var writer = _xmlRepositoryFactory.CreateWriter(integrationTask.Destination);
            writer.Save(newXml);
        }
    }
}
