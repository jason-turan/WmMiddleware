using System;

namespace MiddleWare.Log.Repository
{
    public interface ILogRepository
    {
        int DeleteLogByDate(DateTime deleteOlderThanDate); 
    }
}
