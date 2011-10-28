using System;
using System.Web.UI;
using Chat.Presentation.UI.Data;

namespace Chat.Presentation.UI
{
    public partial class Chat : MasterPage
    {
        private string _pathToImage = "Img/logo_chat.gif";

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlLoader controlLoader = new ControlLoader();

            string logoControlPath = "~/Controls/LogoControl.ascx";
            object[] parameters = { _pathToImage, "logo" };
            var createdLogoControl = controlLoader.LoadControl(logoControlPath, Page, parameters);
            ContentPlaceHolder2.Controls.Add(createdLogoControl);

            string navigationControlPath = "~/Controls/NavigationControl.ascx";
            var createdNavigationControl = LoadControl(navigationControlPath);
            ContentPlaceHolder1.Controls.Add(createdNavigationControl);

            string loginControlPath = "~/Controls/LoginControl.ascx";
            var createdLoginControl = LoadControl(loginControlPath);
            ContentPlaceHolder1.Controls.Add(createdLoginControl);

        }
    }
}
