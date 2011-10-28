using Chat.BusinessLogic.Data;

namespace Chat.Service.Core
{
    public class ChatService : IChatService
    {
        private ChatManager _mychat;

        public ChatService()
        {
            _mychat = new ChatManager();
        }

        public void SendMessage(string text, string userId, string chatRoomId)
        {
            _mychat.SendMessage(text, userId, chatRoomId);
        }

        public string ReceiveMessages(string userId, string chatRoomId)
        {
            return _mychat.ReceiveMessages(chatRoomId, userId);
        }
    }
}



 
