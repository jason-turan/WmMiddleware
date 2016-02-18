﻿namespace Middleware.Wm.Configuration.Mainframe
{
    public interface IMainframeConfiguration : IConfigurationManager
    {
        long GetBatchControlNumber();
        string GetPath(string filePrefix, long batchControlNumber, string configurationKeyPrefix = null);
    }
}
