using System;
using System.IO;
using Chat.Core.Interfaces;
using log4net;
using log4net.Config;

namespace Chat.Core.Impl
{
    internal class ChatLogger : IChatLogger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LogManager));

        public ChatLogger()
        {
            Initialize();
        }

        private static void Initialize()
        {
            // Set up a simple configuration that logs on the console.
            var fi = new FileInfo("log4net.config");
            XmlConfigurator.Configure(fi);
            log.Info("Entering application.");            
        }

        public void Debug(string message)
        {
            log.Debug(message);
        }

        public void Error(string message, Exception ex)
        {
            log.Error(message, ex);
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Fatal(string message)
        {
            log.Fatal(message);
        }
    }
}
