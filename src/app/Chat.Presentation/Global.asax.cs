using System;
using Chat.Core.Impl;
using Chat.Core.Interfaces;
using Chat.DataAccess.Data;

namespace Chat.Presentation.UI
{
    public class Global : System.Web.HttpApplication
    {
        private IChatLogger _logger;
        protected void Application_Start(object sender, EventArgs e)
        {
            DataAccessManager.Initialize();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            _logger = ChatLoggerService.Instance;
            _logger.Info("Ooops" + sender.ToString());
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}