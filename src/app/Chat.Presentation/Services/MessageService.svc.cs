using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Chat.Service.Core;

namespace Chat.Presentation.UI.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MessageService : IChatService
    {
        [WebInvoke(
            Method = "POST", 
            BodyStyle = WebMessageBodyStyle.WrappedRequest, 
            RequestFormat = WebMessageFormat.Json)]
        public void SendMessage(string text, string userId,string chatRoomId)
        {
            IChatService service = new ChatService();
            service.SendMessage(text, userId, chatRoomId);            
        }

         [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json )]

        public string ReceiveMessages(string userId, string chatRoomId)
        {
            IChatService service = new ChatService();
            return service.ReceiveMessages(userId, chatRoomId);
        }
    }
}
