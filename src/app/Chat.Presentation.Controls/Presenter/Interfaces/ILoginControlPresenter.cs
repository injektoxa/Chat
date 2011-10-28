using System.Web.UI;

namespace Chat.Presentation.Controls.Presenter.Interfaces
{
    /// <summary>
    /// Responsible for the user facing functionality of login
    /// Includes logic for redirecting to the pages
    /// And storing security tokens
    /// </summary>
    public interface ILoginControlPresenter
    {
        void Login(string userName, string password, Page page);
        void Logout(Page page);
        string GetUserName(Page page);
    }
}
