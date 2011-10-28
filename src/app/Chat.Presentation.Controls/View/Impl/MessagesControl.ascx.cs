using System;

namespace Chat.Presentation.Controls.View.Impl
{
    public partial class MessagesControl : System.Web.UI.UserControl
    {
        public string RoomId { set; get; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            RoomId = Request.QueryString["roomId"] ?? "0";
        }
    }
}