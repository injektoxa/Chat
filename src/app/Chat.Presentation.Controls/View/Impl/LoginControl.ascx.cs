using System;
using System.Web.UI;
using Chat.Presentation.Controls.Presenter.Impl;
using Chat.Presentation.Controls.Presenter.Interfaces;
using Chat.Presentation.Controls.View.Interfaces;

namespace Chat.Presentation.Controls.View.Impl
{
    public partial class LoginControl : UserControl, ILoginControlView
    {
        private ILoginControlPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Button1.Text == "")
            {
                Button1.Text = "Login";
            }
            var userRole = Session["userRole"] as string;
            _presenter = new LoginControlPresenter(this);

            if (userRole != "0")
            {
                Button1.Text = "Logout";
                string userName = _presenter.GetUserName(Page);
                loginLbl.Text = string.Format("Wellcome, {0}", userName);
                LoginTb.Visible = false;
                PasswordLbl.Visible = false;
                PasswordTb.Visible = false;
            }     
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CheckPermission();
        }

        #region Implementation of ILoginControlView

        public string UserName
        {
            get { return LoginTb.Text; }
            set { LoginTb.Text = value; }
        }

        public string Password
        {
            get { return PasswordTb.Text; }
            set { PasswordTb.Text = value; }
        }

        #endregion

        private void CheckPermission()
        {
            if (Button1.Text == "Logout")
            {
                _presenter.Logout(Page);
                loginLbl.Text = "Login:";
                LoginTb.Visible = true;
                PasswordLbl.Visible = true;
                PasswordTb.Visible = true;
                Button1.Text = "Login";
            }
            else
            {
                try
                {
                    _presenter.Login(UserName, Password, Page);
                    string userName = _presenter.GetUserName(Page);
                    Button1.Text = "Logout";
                    loginLbl.Text = string.Format("Wellcome, {0}", userName);
                    LoginTb.Visible = false;
                    PasswordLbl.Visible = false;
                    PasswordTb.Visible = false;
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}