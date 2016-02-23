using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiddleWare.Log;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Ftp;
using Middleware.Wm.TransferControl.Models;
using Middleware.Wm.TransferControl.Repositories;
using Rhino.Mocks;

namespace Middleware.Wm.TransferControl.Tests
{
    [TestClass]
    public class ControlTests
    {
        // Methods
        private static ITransferControlRepository CreateMocks(out IMainframeFtp mockFtp, out ITransferControlConfigurationManager mockConfiguration, out ILog mockLog, out IFileIo mockFileIo)
        {
            var repository = MockRepository.GenerateMock<ITransferControlRepository>();
            mockFtp = MockRepository.GenerateMock<IMainframeFtp>();
            mockConfiguration = MockRepository.GenerateMock<ITransferControlConfigurationManager>();
            mockLog = MockRepository.GenerateMock<ILog>();
            mockFileIo = MockRepository.GenerateMock<IFileIo>();
            return repository;
        }

        [TestMethod]
        public void ExceptionShouldLogAndReturnFailure()
        {
            IMainframeFtp ftp;
            ITransferControlConfigurationManager manager;
            ILog log;
            IFileIo io;
            ITransferControlRepository mock = CreateMocks(out ftp, out manager, out log, out io);
            var list2 = new List<Middleware.Wm.TransferControl.Models.TransferControl>();
            var item = new Middleware.Wm.TransferControl.Models.TransferControl
            {
                BatchControlNumber = "1"
            };
            list2.Add(item);
            List<Middleware.Wm.TransferControl.Models.TransferControl> objToReturn = list2;
            mock.Stub(r => r.FindTransferControls(new TransferControlSearchCriteria())).IgnoreArguments().Return(objToReturn);
            log.Expect(l => l.Exception(Arg<string>.Is.Equal("Inbound : Fatal exception processing batch 1"), Arg<Exception>.Is.Anything));
            ITransferControlInbound inbound = new TransferControlInbound(mock, ftp, manager, log, io);
            Assert.IsFalse(inbound.Process());
            log.VerifyAllExpectations();
        }

        //[TestMethod]
        //public void InboundProcessingCallsFtp()
        //{
        //    IManhattanFtp ftp;
        //    ITransferControlConfigurationManager manager;
        //    ILog log;
        //    IFileIo io;
        //    ITransferControlRepository mockRepository = CreateMocks(out ftp, out manager, out log, out io);
        //    MockConfiguration(manager, true);
        //    MockUnprocessedTransferControl(mockRepository);
        //    ftp.Expect(f => f.UploadInboundFile(new FileInfo("mock"))).Repeat.Once().IgnoreArguments();
        //    ITransferControlInbound inbound = new TransferControlInbound(mockRepository, ftp, manager, log, io);
        //    inbound.Process();
        //    ftp.VerifyAllExpectations();
        //}

        //[TestMethod]
        //public void InboundProcessingDoesNotCallFtp()
        //{
        //    IManhattanFtp ftp;
        //    ITransferControlConfigurationManager manager;
        //    ILog log;
        //    IFileIo io;
        //    ITransferControlRepository mockRepository = CreateMocks(out ftp, out manager, out log, out io);
        //    MockConfiguration(manager, false);
        //    MockUnprocessedTransferControl(mockRepository);
        //    ftp.Expect(f => f.UploadInboundFile(new FileInfo("mock"))).Repeat.Never().IgnoreArguments();
        //    ITransferControlInbound inbound = new TransferControlInbound(mockRepository, ftp, manager, log, io);
        //    inbound.Process();
        //    ftp.VerifyAllExpectations();
        //}

        private static void MockConfiguration(ITransferControlConfigurationManager mockConfiguration, bool enableFtp)
        {
            mockConfiguration.Expect(c => c.IsFtpEnabled()).Return(enableFtp);
            mockConfiguration.Expect(c => c.GetInboundFileProcessedDirectory()).Return("mock");
            mockConfiguration.Expect(c => c.GetInboundMasterControlFilename()).Return("mock");
            mockConfiguration.Expect(c => c.GetInboundFileDirectory()).Return("mock");
        }

        private static void MockUnprocessedTransferControl(ITransferControlRepository mockRepository)
        {
            var objToReturn = new List<Middleware.Wm.TransferControl.Models.TransferControl>();
            var item = new Middleware.Wm.TransferControl.Models.TransferControl();
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
            IMainframeFtp ftp;
            ITransferControlConfigurationManager manager;
            ILog log;
            IFileIo io;
            ITransferControlRepository mock = CreateMocks(out ftp, out manager, out log, out io);
            MockConfiguration(manager, true);
            mock.Stub(r => r.FindTransferControls(new TransferControlSearchCriteria())).IgnoreArguments().Return(new List<Middleware.Wm.TransferControl.Models.TransferControl>());
            log.Expect(l => l.Info("Inbound: No records to process"));
            Assert.IsTrue(new TransferControlInbound(mock, ftp, manager, log, io).Process());
            log.VerifyAllExpectations();
        }
    }
}


