using System.ServiceModel;

namespace Chat.Service.Core
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        void SendMessage(string text, string userId, string chatRoomId);

        [OperationContract]
        string ReceiveMessages(string userId, string chatRoomId);
    }
}
