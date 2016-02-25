using System;

namespace MiddleWare.Log
{
    public interface ILog
    {
        void Debug(string message);
        void Info(string message);
        void Warning(string message);
        void Exception(Exception exception);
        void Exception(string message, Exception exception);
    }
}
