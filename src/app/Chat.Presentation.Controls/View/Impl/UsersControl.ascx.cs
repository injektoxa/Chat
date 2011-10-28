using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Chat.BusinessLogic.Data;

namespace Chat.Presentation.Controls.View.Impl
{
    public partial class DeletUserFromRoomControl : System.Web.UI.UserControl
    {
        protected Dictionary<int, string> Users;
        private string _roomId;
        private UserManager _userManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            _userManager = new UserManager();
            
           
           var s= Request.Form.AllKeys;
  

            for (int i = 0; i < check1.Items.Count; i++)
            {
                if(check1.Items[i].Selected)
                {
                    Response.Write(check1.Items[i].Text);
                }
            }  
        }

        protected void Menu()
        {
            GetUsers();

            var userRole = Session["userRole"] as string;
            var userId = Session["userId"] as string;

            bool creator = _userManager.IsCreator(Convert.ToInt16(userId), Convert.ToInt16(_roomId));

            if (userRole == "2" && creator)
                MenuForCreator();

            if (userRole == "1" || userRole == "2" && !creator)
                MenuForAuthenticated();

            if (userRole == "0")
                MenuForAll();
        }

        private void MenuForCreator()
        {
            foreach (var user in Users)
            {
                ListItem listItem = new ListItem(user.Value,user.Key.ToString());
                check1.Items.Add(listItem);
            }

            DeleteBtn.Visible = true;
            Response.Write(string.Format("There are {0} users in the room", Users.Count()));
        }

        private void MenuForAuthenticated()
        {
            foreach (var user in Users)
            {
                Response.Write(user.Value);
                Response.Write("<BR/>");
            }

            DeleteBtn.Visible = false;
            Response.Write(string.Format("There are {0} users in the room", Users.Count()));
        }

        private void MenuForAll()
        {
            Response.Write(string.Format("There are {0} users in the room", Users.Count()));
            DeleteBtn.Visible = false;
        }

        private void GetUsers()
        {
            _roomId = Request.QueryString["roomId"] ?? "0";
            int roomId = Convert.ToInt16(_roomId);

            if (_userManager.GetUsersInRoom(roomId) != null)
                Users = _userManager.GetUsersInRoom(roomId);

            if (Users == null)
                Users = new Dictionary<int, string>();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            //todo add logic here and ability to delete user from chat
        }
    }
}