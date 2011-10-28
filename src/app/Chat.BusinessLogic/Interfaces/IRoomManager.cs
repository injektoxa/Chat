using System.Collections.Generic;

namespace Chat.BusinessLogic.Interfaces
{
    interface IRoomManager
    {
        int CreateRoom(string roomName, int creatorId);
        Dictionary<int, string > ReceiveRooms();
        string FindRoom(int roomId);
    }
}
