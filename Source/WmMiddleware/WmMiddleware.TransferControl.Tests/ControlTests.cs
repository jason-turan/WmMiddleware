using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiddleWare.Log;
using Rhino.Mocks;
using WmMiddleware.TransferControl.Configuration;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Ftp;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.TransferControl.Tests
{
    [TestClass]
    public class ControlTests
    {
        // Methods
        private static ITransferControlRepository CreateMocks(out IManhattanFtp mockFtp, out ITransferControlConfigurationManager mockConfiguration, out ILog mockLog, out IFileIo mockFileIo)
        {
            var repository = MockRepository.GenerateMock<ITransferControlRepository>();
            mockFtp = MockRepository.GenerateMock<IManhattanFtp>();
            mockConfiguration = MockRepository.GenerateMock<ITransferControlConfigurationManager>();
            mockLog = MockRepository.GenerateMock<ILog>();
            mockFileIo = MockRepository.GenerateMock<IFileIo>();
            return repository;
        }

        [TestMethod]
        public void ExceptionShouldLogAndReturnFailure()
        {
            IManhattanFtp ftp;
            ITransferControlConfigurationManager manager;
            ILog log;
            IFileIo io;
            ITransferControlRepository mock = CreateMocks(out ftp, out manager, out log, out io);
            var list2 = new List<Models.TransferControl>();
            var item = new Models.TransferControl
            {
                BatchControlNumber = "1"
            };
            list2.Add(item);
            List<Models.TransferControl> objToReturn = list2;
            mock.Stub(r => r.FindTransferControls(new TransferControlSearchCriteria())).IgnoreArguments().Return(objToReturn);
            log.Expect(l => l.Exception(Arg<string>.Is.Equal("Inbound : Fatal exception processing batch 1"), Arg<Exception>.Is.Anything));
            ITransferControlInbound inbound = new TransferControlInbound(mock, ftp, manager, log, io);
            Assert.IsFalse(inbound.Process());
            log.VerifyAllExpectations();
        }

        [TestMethod]
        public void InboundProcessingCallsFtp()
        {
            IManhattanFtp ftp;
            ITransferControlConfigurationManager manager;
            ILog log;
            IFileIo io;
            ITransferControlRepository mockRepository = CreateMocks(out ftp, out manager, out log, out io);
            MockConfiguration(manager, true);
            MockUnprocessedTransferControl(mockRepository);
            ftp.Expect(f => f.UploadInboundFile(new FileInfo("mock"))).Repeat.Once().IgnoreArguments();
            ITransferControlInbound inbound = new TransferControlInbound(mockRepository, ftp, manager, log, io);
            inbound.Process();
            ftp.VerifyAllExpectations();
        }

        [TestMethod]
        public void InboundProcessingDoesNotCallFtp()
        {
            IManhattanFtp ftp;
            ITransferControlConfigurationManager manager;
            ILog log;
            IFileIo io;
            ITransferControlRepository mockRepository = CreateMocks(out ftp, out manager, out log, out io);
            MockConfiguration(manager, false);
            MockUnprocessedTransferControl(mockRepository);
            ftp.Expect(f => f.UploadInboundFile(new FileInfo("mock"))).Repeat.Never().IgnoreArguments();
            ITransferControlInbound inbound = new TransferControlInbound(mockRepository, ftp, manager, log, io);
            inbound.Process();
            ftp.VerifyAllExpectations();
        }

        private static void MockConfiguration(ITransferControlConfigurationManager mockConfiguration, bool enableFtp)
        {
            mockConfiguration.Expect(c => c.IsFtpEnabled()).Return(enableFtp);
            mockConfiguration.Expect(c => c.GetInboundFileProcessedDirectory()).Return("mock");
            mockConfiguration.Expect(c => c.GetInboundMasterControlFilename()).Return("mock");
            mockConfiguration.Expect(c => c.GetInboundFileDirectory()).Return("mock");
        }

        private static void MockUnprocessedTransferControl(ITransferControlRepository mockRepository)
        {
            var objToReturn = new List<Models.TransferControl>();
            var item = new Models.TransferControl();
            var file = new TransferControlFile
            {
                FileLocation = "mock"
            };
            var list2 = new List<TransferControlFile> {
                file
            };
            item.Files = list2;
            objToReturn.Add(item);
            mockRepository.Expect(r => r.FindTransferControls(new TransferControlSearchCriteria())).IgnoreArguments().Return(objToReturn).Repeat.Once();
        }

        [TestMethod]
        public void NoRecordsShouldReturnSuccessAndLog()
        {
            IManhattanFtp ftp;
            ITransferControlConfigurationManager manager;
            ILog log;
            IFileIo io;
            ITransferControlRepository mock = CreateMocks(out ftp, out manager, out log, out io);
            MockConfiguration(manager, true);
            mock.Stub(r => r.FindTransferControls(new TransferControlSearchCriteria())).IgnoreArguments().Return(new List<Models.TransferControl>());
            log.Expect(l => l.Info("Inbound: No records to process"));
            Assert.IsTrue(new TransferControlInbound(mock, ftp, manager, log, io).Process());
            log.VerifyAllExpectations();
        }
    }
}


