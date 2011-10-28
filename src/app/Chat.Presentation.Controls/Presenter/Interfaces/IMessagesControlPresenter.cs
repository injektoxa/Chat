using System.Web;

namespace Chat.Presentation.Controls.Presenter.Interfaces
{
    interface IMessagesControlPresenter
    {
        string ReceiveMessages(string roomId, string userId);
        void SendMessages(string text, string chatRoomId, HttpRequest request);
    }
}
