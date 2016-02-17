using System;
using System.IO;

namespace WmMiddleware.TransferControl.Ftp
{
    public class SftpClient : IFtpClient
    {
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;

        public SftpClient(string host, string username, string password)
        {
            _host = host;
            _username = username;
            _password = password;
        }

        public bool Upload(FileInfo localFile, string remoteFileName)
        {
            if (!localFile.Exists)
            {
                throw new Exception(string.Format("The local file does not exist, the file path: {0}", localFile.FullName));
            }

            using (var inputStream = localFile.OpenRead())
            using (var client = new Renci.SshNet.SftpClient(_host, _username, _password))
            {
                client.Connect();
                client.UploadFile(inputStream, remoteFileName);
            }

            return true;
        }

        public bool Download(string serverName, string localName)
        {
            throw new NotImplementedException();
        }

        public void Append(FileInfo localFile, string remoteFileName)
        {
            throw new NotImplementedException();
        }
    }
}
