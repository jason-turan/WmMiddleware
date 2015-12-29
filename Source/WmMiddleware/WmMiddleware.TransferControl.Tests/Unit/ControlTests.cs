using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using WmMiddleware.Configuration;
using MiddleWare.Log;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Ftp;
using WmMiddleware.TransferControl.Models;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.TransferControl.Tests.Unit
{
    [TestClass]
    public class ControlTests
    {
        [TestMethod]
        public void InboundProcessingDoesNotCallFtp()
        {
            // arrange
            IManhattanFtp mockFtp;
            IConfigurationManager mockConfiguration;
            ILog mockLog;
            IFileIo mockFileIo;

            var mockRepository = CreateMocks(out mockFtp, out mockConfiguration, out mockLog, out mockFileIo);

            MockConfiguration(mockConfiguration, false);

            // expect that we query for unprocessed transfer control inbound files, and mock one back
            MockUnprocessedTransferControl(mockRepository);

            // expect ftp is called since it is enabled
            mockFtp.Expect(ftp => ftp.UploadInboundFile(new FileInfo("mock"))).Repeat
                                                                              .Never()
                                                                              .IgnoreArguments();



            // act
            ITransferControlInbound concrete = new TransferControlInbound(mockRepository,
                                                                          mockFtp,
                                                                          mockConfiguration,
                                                                          mockLog,
                                                                          mockFileIo);


            concrete.Process();

            // assert
            mockFtp.VerifyAllExpectations();
        }

        [TestMethod]
        public void InboundProcessingCallsFtp()
        {
            // arrange
            IManhattanFtp mockFtp;
            IConfigurationManager mockConfiguration;
            ILog mockLog;
            IFileIo mockFileIo;

            var mockRepository = CreateMocks(out mockFtp, out mockConfiguration, out mockLog, out mockFileIo);

            MockConfiguration(mockConfiguration, true);

            // expect that we query for unprocessed transfer control inbound files, and mock one back
            MockUnprocessedTransferControl(mockRepository);

            // expect ftp is called since it is enabled
            mockFtp.Expect(ftp => ftp.UploadInboundFile(new FileInfo("mock"))).Repeat
                                                                              .Once()
                                                                              .IgnoreArguments();



            // act
            ITransferControlInbound concrete = new TransferControlInbound(mockRepository,
                                                                          mockFtp,
                                                                          mockConfiguration,
                                                                          mockLog,
                                                                          mockFileIo);


            concrete.Process();

            // assert
            mockFtp.VerifyAllExpectations();
        }

        private static ITransferControlRepository CreateMocks(out IManhattanFtp mockFtp,
            out IConfigurationManager mockConfiguration, out ILog mockLog, out IFileIo mockFileIo)
        {
            var mockRepository = MockRepository.GenerateMock<ITransferControlRepository>();
            mockFtp = MockRepository.GenerateMock<IManhattanFtp>();
            mockConfiguration = MockRepository.GenerateMock<IConfigurationManager>();
            mockLog = MockRepository.GenerateMock<ILog>();
            mockFileIo = MockRepository.GenerateMock<IFileIo>();
            return mockRepository;
        }

        private static void MockUnprocessedTransferControl(ITransferControlRepository mockRepository)
        {
            var mockInboundTransferControlList = new List<Models.TransferControl>();
            var transferControl = new Models.TransferControl();
            var transferControlFile = new TransferControlFile() {FileLocation = "mock"};
            transferControl.Files = new List<TransferControlFile> {transferControlFile};
            mockInboundTransferControlList.Add(transferControl);
            mockRepository.Expect(r => r.FindTransferControls(new TransferControlSearchCriteria())).IgnoreArguments()
                .Return(mockInboundTransferControlList)
                .Repeat.Once();
        }

        private static void MockConfiguration(IConfigurationManager mockConfiguration, bool enableFtp)
        {
            // expect that we get ftp enable key
            mockConfiguration.Expect(c => c.GetKey<bool>(ConfigurationKey.TransferControlFtpEnable)).Return(enableFtp);

            // expect that we get the processed folder path
            mockConfiguration.Expect(c => c.GetKey<string>(ConfigurationKey.TransferControlInboundFileProcessedDirectory)).Return("mock");

            // expect that we get the tranfer control file name from config
            mockConfiguration.Expect(c => c.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename)).Return("mock");

            // expect that we get the inbound file directory from config
            mockConfiguration.Expect(c => c.GetKey<string>(ConfigurationKey.TransferControlInboundFileDirectory)).Return("mock");
        }
    }
}
