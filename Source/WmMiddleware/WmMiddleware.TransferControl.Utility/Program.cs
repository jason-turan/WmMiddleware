using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

using WmMiddleware.Configuration;
using WmMiddleWare.Log;
using WmMiddleware.TransferControl.Ftp;

namespace WmMiddleware.TransferControl.Utility
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILog log = new Log4Net();
            var configuration = new MiddlewareConfigurationManager(log);

            var server = configuration.GetKey<string>(ConfigurationKey.TransferControlFtpManhattanServer);
            var ftpUser = configuration.GetKey<string>(ConfigurationKey.TransferControlFtpUserName);
            var ftpPass = configuration.GetKey<string>(ConfigurationKey.TransferControlFtpPassword);
            var masterControlPath = configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterFileFtpLocation);
            var masterControlFileName = configuration.GetKey<string>(ConfigurationKey.TransferControlInboundMasterControlFilename);
            var inboundFtpPath = configuration.GetKey<string>(ConfigurationKey.TransferControlInboundFtpLocation);

            var ftpRequest = (FtpWebRequest)WebRequest.Create(@"ftp://" + server + "/" + inboundFtpPath);
            ftpRequest.Credentials = new NetworkCredential("JBAFTP", "cosmo");
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            var response = (FtpWebResponse)ftpRequest.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());

            var directories = new List<string>();
            var directoryList = new StringBuilder();

            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directoryList.AppendLine(line);
                directories.Add(line);
                line = streamReader.ReadLine();
            }

            File.WriteAllText(@"C:\WmMiddleware\utility\" + 
                              inboundFtpPath + 
                              "_DirectoryListing_" + 
                              DateTime.Now.ToString("yyyyMMddHHmmss") + 
                              ".txt", directoryList.ToString());

            var client = new FtpClient(server, ftpUser, ftpPass);

            client.Download(masterControlPath + "/" + masterControlFileName, @"C:\WmMiddleware\utility\" +
                                                                             masterControlFileName +
                                                                             "_Download_" +
                                                                             DateTime.Now.ToString("yyyyMMddHHmmss") +
                                                                             ".txt");
        }
    }
}
