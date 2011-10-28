namespace Chat.BusinessLogic.Interfaces
{
    public interface IChatManager
    {
        void SendMessage(string text, string userId, string chatRoomId);
        string ReceiveMessages(string userId, string chatRoomId);
    }
}
