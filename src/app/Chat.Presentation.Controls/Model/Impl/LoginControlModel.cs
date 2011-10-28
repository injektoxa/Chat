using Chat.BusinessLogic.Data;
using Chat.Presentation.Controls.Model.Interfaces;

namespace Chat.Presentation.Controls.Model.Impl
{
    public class LoginControlModel : ILoginControlModel
    {
        private string _userName;
        private string _password;

        public LoginControlModel(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        #region Implementation of ILoginControlModel

        public int ValidateUser()
        {
            var userManager = new UserManager();
           
            var userInfo = userManager.FindUser(_userName, _password);
            if (userInfo != null)
            {
                userManager.LoginUser(userInfo.Id);
                return userInfo.Id;
            }
            return 0;
        }

        #endregion
    }
}