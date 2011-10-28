using System;
using Chat.BusinessLogic.Data;

namespace Chat.Presentation.UI
{
    public partial class Login : System.Web.UI.Page
    {
        public string RoomName { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            const string messageControlPath = "~/Controls/MessagesControl.ascx";
            var createdMessageControl = LoadControl(messageControlPath);
            MessageControlHolder.Controls.Add(createdMessageControl);

            string deleteControlPath = "~/Controls/UsersControl.ascx";
            var createdUserControl = LoadControl(deleteControlPath);
            MessageControlHolder.Controls.Add(createdUserControl);

            string roomId = Request.QueryString["roomId"] ?? "0";
            string leave = Request.QueryString["leave"];

            if (leave == "true")
            {
                string userId = Session["userId"] as string;
                UserManager userManager = new UserManager();
                userManager.LeaveRoom(Convert.ToInt16(userId));
            }

            if (Session["userId"] == null)
            {
                UserManager userManager = new UserManager();
                var userId = userManager.AddAnonimUser();
                Session.Add("userId", userId.ToString());
                Session.Add("userRole", "0");
            }

            if (roomId != "0")
            {
                string userId = Session["userId"] as string;
                UserManager userManager = new UserManager();
                userManager.EnterToRoom(Convert.ToInt16(roomId), Convert.ToInt16(userId));
            }

            RoomManager roomManager = new RoomManager();
            var room = roomManager.FindRoom(Convert.ToInt16(roomId));
            RoomNameLbl.Text = string.Format("Room {0}", room);
        }
    }
}