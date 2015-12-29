using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;

namespace Middleware.Jobs.Tests
{
    [TestClass]
    public class RepositoryIntegrationTests
    {
        [TestMethod]
        public void GetLastSuccess()
        {
            var jobRepository = new JobRepository();
            var job = jobRepository.GetLastSuccessfulJobExecution(JobKey.ShipmentJob);
            Assert.IsNotNull(job);
        }

        [TestMethod]
        public void InsertAJob()
        {
            var jobRepository = new JobRepository();
            var middlewareJob = new MiddlewareJob
            {
                Schedule = "What",
                JobKey = "SomeJob",
                IsActive = true,
                JobExecutable = "something.sb, somethingtype"
            };

            using (var ts = new TransactionScope())
            {
                // insert a job
                jobRepository.InsertJob(middlewareJob);    

                // query it back
                var job = jobRepository.GetJobs().SingleOrDefault(j => j.JobKey == "SomeJob");

                // assert 
                Assert.IsNotNull(job);

                // update it
                job.JobExecutable = "Test";
                jobRepository.UpdateJob(job);

                // get it again
                job = jobRepository.GetJobs().SingleOrDefault(j => j.JobKey == "SomeJob");

                Assert.IsNotNull(job);
                Assert.IsTrue(job.JobKey == "SomeJob");
                Assert.IsTrue(job.JobExecutable == "Test");

                // get a single by job key
                job = jobRepository.GetJob("SomeJob");
                Assert.IsNotNull(job);
                Assert.IsTrue(job.JobKey == "SomeJob");
                Assert.IsTrue(job.JobExecutable == "Test");
            }
        }
    }
}
