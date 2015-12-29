using System;
using System.IO;
using MiddleWare.Log;

namespace WmMiddleware.TransferControl.Control
{
    public class FileIo : IFileIo
    {
        private readonly ILog _log;

        public FileIo(ILog log)
        {
            _log = log;
        }

        public void Move(FileInfo fromLocation, FileInfo toLocation)
        {
            try
            {
                File.Move(fromLocation.FullName, toLocation.FullName);
                _log.Debug(string.Format("Moved file from {0} to {1}", fromLocation.FullName, toLocation.FullName));
            }
            catch (Exception exception)
            {
                _log.Exception(string.Format("Could not move file from {0} to {1}",fromLocation.FullName, toLocation.FullName), exception);
                throw;
            }
            
        }
    }
}
