using System;
using System.IO;
using Middleware.Log;

namespace Middleware.Wm.TransferControl.Control
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
                var destination = toLocation.FullName;

                if (File.Exists(destination))
                {
                   destination = destination.Replace(toLocation.Name, toLocation.Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                }

                File.Move(fromLocation.FullName, destination);

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
