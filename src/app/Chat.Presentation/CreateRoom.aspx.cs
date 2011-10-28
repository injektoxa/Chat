using System;
using Chat.BusinessLogic.Data;

namespace Chat.Presentation.UI
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string roomName = RoomNameTb.Text;
            var creatorId = Session["userId"] as string;

            RoomManager roomManager = new RoomManager();
            var roomId = roomManager.CreateRoom(roomName, Convert.ToInt16(creatorId));
            Session["userRole"] = "2";
            string url = "Login.aspx?roomId=" + roomId;
            Response.Redirect(url);
        }
    }
}