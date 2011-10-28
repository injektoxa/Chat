using System.Collections.Generic;
using Chat.BusinessLogic.Data.Model;

namespace Chat.BusinessLogic.Interfaces
{
    interface IUserManager
    {
        bool RegisterUser(string name, string password,int userId);
        void DeleteUser(int userId);
        UserInfo FindUser(string name, string password);
        void LoginUser(int userId);
        void EnterToRoom(int roomId, int userId);
        void LeaveRoom(int userId);
        Dictionary<int,string> GetUsersInRoom(int roomId);
        void LogoutUser(int userId);
        int AddAnonimUser();
        bool IsCreator(int userId, int roomId);
        string GetUserName(int userId);
    }
}
