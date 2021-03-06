﻿using System;
using System.Collections.Generic;
using Middleware.Jobs.Models;

namespace Middleware.Jobs.Repositories
{
    public interface IJobRepository
    {
        MiddlewareJob GetJob(string jobKey);
        MiddlewareJob GetJobByExecutable(string executableName);
        MiddlewareJob GetLastSuccessfulJobExecution(string jobKey);
        IEnumerable<MiddlewareJob> GetJobs();
        void UpdateJob(MiddlewareJob job);
        void UpdateJobActiveInactive(int jobId, bool isActive);
        void InsertJob(MiddlewareJob job);
        void InsertJobHistory(MiddlewareJobHistory jobHistory);
        int? GetJobIdByFilePrefix(string filePrefix);
        int DeleteJobHistoryByDate(DateTime deleteOlderThanDate);
    }
}
