using System;
using Chat.BusinessLogic.Data;

namespace Chat.Presentation.UI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager();

            if (string.IsNullOrEmpty(NameTB.Text) || string.IsNullOrEmpty(PasswordTB.Text))
            {
                Response.Redirect("Register.aspx");
            }
            else
            {
                var userId = Session["userId"] as string;

                if (userManager.RegisterUser(NameTB.Text, PasswordTB.Text,Convert.ToInt16(userId)))
                    Response.Redirect("Login.aspx", true);
                else
                    Response.Redirect("Register.aspx");
            }
        }
    }
}