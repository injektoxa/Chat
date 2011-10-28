using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Chat.BusinessLogic.Data;
using Chat.Core.Impl;
using Chat.Core.Interfaces;

namespace Chat.Presentation.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private IChatLogger logger = ChatLoggerService.Instance;
        public Dictionary<int, string > Rooms { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Info("Home page was called");

            RoomManager manager = new RoomManager();
            
            Rooms = manager.ReceiveRooms();
        }
    }
}