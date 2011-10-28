using System.ServiceModel;
using Chat.Core.Impl;
using Chat.Core.Interfaces;
using Chat.Service.Core;

namespace Chat.Service.Host.Console
{
    class Program
    {
        private static IChatLogger logger = ChatLoggerService.Instance;

        static void Main(string[] args)
        {
            logger.Info("Starting hosting...");
            var serviceHost = new ServiceHost(typeof(ChatService));
            serviceHost.Open();
            logger.Info("Hosting has started");
            logger.Info("Press Enter to shut it down");
            System.Console.ReadLine();
            serviceHost.Close();            
        }
    }
}
