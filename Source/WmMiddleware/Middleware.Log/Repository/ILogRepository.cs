using System;

namespace Middleware.Log.Repository
{
    public interface ILogRepository
    {
        int DeleteLogByDate(DateTime deleteOlderThanDate); 
    }
}
