using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.TransferControl.Tests.IntegrationTests
{
    [TestClass]
    public class RepositoryIntegrationTests
    {
        [TestMethod]
        public void InsertATransferControlAndSelectIt()
        {
            // arrange
            using (var ts = new TransactionScope())
            {
                var transferControlRepository = new TransferControlRepository();

                var transferControl = new TransferControl.Models.TransferControl {BatchControlNumber = "123", JobId = 5};

                var transferControlFiles = new List<Models.TransferControlFile>
                {
                    new TransferControlFile() {FileLocation = @"C:\file1.txt"},
                    new TransferControlFile() {FileLocation = @"C:\file2.txt"},
                    new TransferControlFile() {FileLocation = @"C:\file3.txt"}
                };

                transferControl.Files = transferControlFiles;

                // act
                var tranfserId = transferControlRepository.InsertTransferControl(transferControl);
                var transferControlQuery = transferControlRepository.GetTransferControl(tranfserId);

                // assert
                Assert.IsTrue(transferControlQuery.BatchControlNumber == "123");
                Assert.IsTrue(transferControlQuery.JobId == 5);
                Assert.IsTrue(transferControlQuery.Files.Count() == 3);
                Assert.IsTrue(transferControlQuery.Files.ToList()[0].FileLocation == @"C:\file1.txt");
                Assert.IsTrue(transferControlQuery.Files.ToList()[1].FileLocation == @"C:\file2.txt");
                Assert.IsTrue(transferControlQuery.Files.ToList()[2].FileLocation == @"C:\file3.txt");
            }
        }

        [TestMethod]
        public void FindUnprocessedBatches()
        {
            // arrange
            using (var ts = new TransactionScope())
            {
                var transferControlRepository = new TransferControlRepository();

                var transferControl = new TransferControl.Models.TransferControl
                {
                    BatchControlNumber = "123",
                    JobId = 5,
                    ProcessedDate = DateTime.Now
                };
                var transferControl2 = new TransferControl.Models.TransferControl
                {
                    BatchControlNumber = "124",
                    JobId = 5
                };

                var transferControlFiles = new List<Models.TransferControlFile>
                {
                    new TransferControlFile() {FileLocation = @"C:\file1.txt"},
                    new TransferControlFile() {FileLocation = @"C:\file2.txt"},
                    new TransferControlFile() {FileLocation = @"C:\file3.txt"}
                };

                transferControl.Files = transferControlFiles;
                transferControl2.Files = transferControlFiles;

                // act
                transferControlRepository.InsertTransferControl(transferControl);
                transferControlRepository.InsertTransferControl(transferControl2);

                var transferControlQuery =
                    transferControlRepository.FindTransferControls(new TransferControlSearchCriteria()
                    {
                        Processed = false,
                        JobId = 5
                    });

                // assert
                var transferControls = transferControlQuery as Models.TransferControl[] ?? transferControlQuery.ToArray();

                Assert.IsTrue(transferControls.Count() == 1);
                Assert.IsTrue(transferControls.ToList()[0].BatchControlNumber == "124");
            }
        }

        [TestMethod]
        public void FindProcessedBatches()
        {
            // arrange
            using (var ts = new TransactionScope())
            {
                var transferControlRepository = new TransferControlRepository();

                var transferControl = new TransferControl.Models.TransferControl
                {
                    BatchControlNumber = "123",
                    JobId = 5,
                    ProcessedDate = DateTime.Now
                };
                var transferControl2 = new TransferControl.Models.TransferControl
                {
                    BatchControlNumber = "124",
                    JobId = 5
                };

                var transferControlFiles = new List<Models.TransferControlFile>
                {
                    new TransferControlFile() {FileLocation = @"C:\file1.txt"},
                    new TransferControlFile() {FileLocation = @"C:\file2.txt"},
                    new TransferControlFile() {FileLocation = @"C:\file3.txt"}
                };

                transferControl.Files = transferControlFiles;
                transferControl2.Files = transferControlFiles;

                // act
                transferControlRepository.InsertTransferControl(transferControl);
                transferControlRepository.InsertTransferControl(transferControl2);

                var transferControlQuery =
                    transferControlRepository.FindTransferControls(new TransferControlSearchCriteria()
                    {
                        Processed = true
                    });

                // assert
                var transferControls = transferControlQuery as Models.TransferControl[] ?? transferControlQuery.ToArray();

                Assert.IsTrue(transferControls.Count() == 1);
                Assert.IsTrue(transferControls.ToList()[0].BatchControlNumber == "123");
            }
        }

        [TestMethod]
        public void FindAllBatches()
        {
            // arrange
            using (var ts = new TransactionScope())
            {
                var transferControlRepository = new TransferControlRepository();

                var transferControl = new TransferControl.Models.TransferControl
                {
                    BatchControlNumber = "123",
                    JobId = 5,
                    ProcessedDate = DateTime.Now
                };
                var transferControl2 = new TransferControl.Models.TransferControl
                {
                    BatchControlNumber = "124",
                    JobId = 5
                };

                var transferControlFiles = new List<Models.TransferControlFile>
                {
                    new TransferControlFile() {FileLocation = @"C:\file1.txt"},
                    new TransferControlFile() {FileLocation = @"C:\file2.txt"},
                    new TransferControlFile() {FileLocation = @"C:\file3.txt"}
                };

                transferControl.Files = transferControlFiles;
                transferControl2.Files = transferControlFiles;

                // act
                transferControlRepository.InsertTransferControl(transferControl);
                transferControlRepository.InsertTransferControl(transferControl2);

                var transferControlQuery =
                    transferControlRepository.FindTransferControls(new TransferControlSearchCriteria());

                // assert
                var transferControls = transferControlQuery as Models.TransferControl[] ?? transferControlQuery.ToArray();

                Assert.IsTrue(transferControls.Count() == 2);
            }
        }

    }
}
