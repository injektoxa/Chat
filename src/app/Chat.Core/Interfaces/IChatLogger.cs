using System;

namespace Chat.Core.Interfaces
{
    public interface IChatLogger
    {
        void Debug(string message);
        void Error(string message, Exception ex);
        void Info(string message);
        void Fatal(string message);
    }
}