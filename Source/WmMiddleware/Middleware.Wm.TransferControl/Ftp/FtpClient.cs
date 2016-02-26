using System;
using System.IO;
using System.Net;
using Middleware.Log;
using Middleware.Wm.TransferControl.Models;

namespace Middleware.Wm.TransferControl.Ftp
{
    public class FtpClient : IFtpClient
    {
        private const string PathCharacter = "/";
        private readonly FtpOptions _ftpOptions;
        private readonly ILog _log;

        public FtpClient(FtpOptions options, ILog log)
        {
            _ftpOptions = options;
            _log = log;
        }

        public bool Upload(FileInfo localFile, string remoteFileName)
        {
            if (!localFile.Exists)
                throw new Exception(string.Format("The local file does not exist, the file path:{0}", localFile.FullName));

            try
            {


                string url = _ftpOptions.Host.TrimEnd('/') + PathCharacter + remoteFileName;
                FtpWebRequest request = CreateRequest(url, WebRequestMethods.Ftp.UploadFile, _ftpOptions);

                using (Stream rs = request.GetRequestStream())
                using (FileStream fs = localFile.OpenRead())
                {
                    var buffer = new byte[4096]; //4K
                    // var bufferCount = 0;
                    int count = fs.Read(buffer, 0, buffer.Length);
                    while (count > 0)
                    {
                        rs.Write(buffer, 0, count);
                        // _log.Debug("Writing " + localFile.Name + " part " + bufferCount);
                        count = fs.Read(buffer, 0, buffer.Length);
                        // bufferCount++;
                    }
                }
            }
            catch (WebException e)
            {
                var status = ((FtpWebResponse)e.Response).StatusDescription;
                _log.Warning("Failure of status: " + status);
                throw;
            }

            return true;
        }

        public bool Download(string serverName, string localName)
        {
            using (var fs = new FileStream(localName, FileMode.OpenOrCreate)) //Create or open a local file
            {
                //To establish the connection
                string url = _ftpOptions.Host.TrimEnd('/') + PathCharacter + serverName;
                FtpWebRequest request = CreateRequest(url, WebRequestMethods.Ftp.DownloadFile, _ftpOptions);
                request.ContentOffset = fs.Length;
                using (var response = (FtpWebResponse) request.GetResponse())
                {
                    fs.Position = fs.Length;
                    var buffer = new byte[4096]; //4K
                    Stream responseStream = response.GetResponseStream();
                    if (responseStream != null)
                    {
                        int count = responseStream.Read(buffer, 0, buffer.Length);
                        while (count > 0)
                        {
                            fs.Write(buffer, 0, count);
                            count = responseStream.Read(buffer, 0, buffer.Length);
                        }
                    }
                    Stream stream = response.GetResponseStream();
                    if (stream != null) stream.Close();
                }
            }
            return true;
        }

        public void Append(FileInfo localFile, string remoteFileName)
        {
            if (!localFile.Exists)
                throw new Exception(string.Format("The local file does not exist, the file path:{0}", localFile.FullName));
            
            using (var fileStream = new FileStream(localFile.FullName, FileMode.Open))
            {
                Append(fileStream, remoteFileName, _ftpOptions);
            }
        }

        private static void Append(Stream stream, string remoteFileName, FtpOptions ftpOptions)
        {
            if ((stream == null || !stream.CanRead))
            {
                throw new Exception("Stream does not exist or cannot be read");
            }

            string url = ftpOptions.Host.TrimEnd('/') + PathCharacter + remoteFileName;

            FtpWebRequest request = CreateRequest(url, WebRequestMethods.Ftp.AppendFile, ftpOptions);

            using (Stream rs = request.GetRequestStream())
            {
                //Upload data
                var buffer = new byte[4096]; //4K
                int count = stream.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    rs.Write(buffer, 0, count);
                    count = stream.Read(buffer, 0, buffer.Length);
                }
            }
        }

        private static FtpWebRequest CreateRequest(string url, string method, FtpOptions ftpOptions)
        {
            var request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential(ftpOptions.UserId, ftpOptions.Password);
            request.Proxy = ftpOptions.Proxy;
            request.KeepAlive = false; //Command execution after closing the connection
            request.UseBinary = ftpOptions.UseBinary;
            request.UsePassive = ftpOptions.UsePassive;
            request.EnableSsl = ftpOptions.EnableSsl;
            request.Method = method;
            return request;
        }
    }
}

