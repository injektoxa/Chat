using System;
using System.Web.UI;
using Chat.BusinessLogic.Data;
using Chat.Presentation.Controls.Model.Impl;
using Chat.Presentation.Controls.Model.Interfaces;
using Chat.Presentation.Controls.Presenter.Interfaces;
using Chat.Presentation.Controls.View.Interfaces;

namespace Chat.Presentation.Controls.Presenter.Impl
{
    public class LoginControlPresenter : ILoginControlPresenter
    {
        private readonly ILoginControlView _view;
        private UserManager _userManager;

        public LoginControlPresenter(ILoginControlView view)
        {
            _view = view;
            _userManager = new UserManager();
        }

        #region Implementation of ILoginControlPresenter

        public void Login(string userName, string password, Page page)
        {
            ILoginControlModel model = new LoginControlModel(userName, password);

            int userId = model.ValidateUser();
            if (userId != 0)
            {
                page.Session["userId"] = userId.ToString();
                page.Session["userRole"] = "1";
            }
            else
                page.Response.Redirect("Login.aspx");
        }

        public void Logout(Page page)
        {
            page.Session["userRole"] = "0";
            var userId = page.Session["userId"] as string;

            _userManager.LogoutUser(Convert.ToInt16(userId));
        }

        public string GetUserName(Page page)
        {
            string userId = page.Session["userId"] as string;
            var userName = _userManager.GetUserName(Convert.ToInt16(userId));
            return userName;
        }

        #endregion
    }
}