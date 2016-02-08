using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using MiddleWare.Log.Repository;
using Middleware.Wm.LoggingAndFileMaintenance.Repository;

namespace Middleware.Wm.LoggingAndFileMaintenance
{
    public class LogAndFileMaintenanceJob : IUnitOfWork
    {
        private readonly ILog _log;
        private readonly IJobRepository _jobRepository;
        private readonly ILogRepository _logRepository;
        private readonly ILoggingAndFileMaintenanceRepository _loggingAndFileMaintenanceRepository;

        public LogAndFileMaintenanceJob(ILog log, 
                                        IJobRepository jobRepository, 
                                        ILogRepository logRepository, 
                                        ILoggingAndFileMaintenanceRepository loggingAndFileMaintenanceRepository)
        {
            _log = log;
            _jobRepository = jobRepository;
            _logRepository = logRepository;
            _loggingAndFileMaintenanceRepository = loggingAndFileMaintenanceRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            var maintenanceConfiguration = _loggingAndFileMaintenanceRepository.GetLoggingAndFileMaintenance();

            TrimJobHistory(maintenanceConfiguration.JobHistoryTrimOlderThanDays);
            TrimLogDatabase(maintenanceConfiguration.DatabaseLogTrimOlderThanDays);

            foreach (var directory in maintenanceConfiguration.RollingFileDirectories.Split(','))
            {
                ZipLogFiles(new DirectoryInfo(directory), 
                            maintenanceConfiguration.RollingFileZipOlderThanDays);
            }
        }

        private void ZipLogFiles(DirectoryInfo directory, int numberOfDays)
        {
            Debug.Assert(directory != null, "directory != null");
            if (!directory.Exists) return;

            var files = directory.GetFiles().Where(f => f.Extension != ".zip" &&
                                                        f.LastWriteTime < DateTime.Now.AddDays(-1*numberOfDays));

            Compress(files.ToList(), directory.FullName);
        }

        private void TrimLogDatabase(int daysBack)
        {
            var trimDate = DateTime.Now.AddDays(-1 * daysBack);
            var deletedCount = _logRepository.DeleteLogByDate(trimDate);
            _log.Info("Deleted " + deletedCount + " records from dbo.log.  Trim date was configured as " + trimDate);
        }

        private void TrimJobHistory(int daysBack)
        {
            var trimDate = DateTime.Now.AddDays(-1 * daysBack);
            var deletedCount = _jobRepository.DeleteJobHistoryByDate(trimDate);
            _log.Info("Deleted " + deletedCount + " records from dbo.job_history.  Trim date was configured as " + trimDate);
        }

        private void Compress(IList<FileInfo> files, string directory)
        {
            foreach (var fileToCompress in files.ToList())
            {
                var zipFileName = fileToCompress.LastWriteTime.ToString("yyyyMM") + "_MiddlewareArchive.zip";

                using (var archive = ZipFile.Open(directory + "/" + zipFileName, ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(fileToCompress.FullName, fileToCompress.Name);
                }
            }

            foreach (var file in files.ToList())
            {
                File.Delete(file.FullName);
                _log.Info("Compressed and deleted " + file.FullName);
            }
        }
    }
}
