using System;
using System.Collections.Generic;
using Chat.BusinessLogic.Interfaces;
using Chat.Core.Impl;
using Chat.Core.Interfaces;
using Chat.DataAccess.Data;
using Chat.DataAccess.Interfaces;
using System.Linq;

namespace Chat.BusinessLogic.Data
{
    public class RoomManager : IRoomManager
    {
        private readonly IChatLogger _logger;

        public RoomManager()
        {
            _logger = ChatLoggerService.Instance;
        }

        public int CreateRoom(string roomName, int creatorId)
        {
            if (string.IsNullOrEmpty(roomName))
            {
                _logger.Debug("Create room ArgumentNullException");
                throw new ArgumentNullException();
            }

            Authorization.CheckRoles("Authenticated");

            var roomRepository = ContainerService.Instance.Resolve<IRepository<Room>>();

            Room room = new Room
                            {
                                Name = roomName,
                                CreatorId = creatorId,
                                Id = roomRepository.FindAll().Count() + 1
                            };

            roomRepository.Add(room);
            roomRepository.SaveAll();

            var userRoleRepository = ContainerService.Instance.Resolve<IRepository<User_Role>>();
            var userRole = userRoleRepository.FindOne(u => u.UserId == creatorId);
            userRole.RoleId = 2;
            userRoleRepository.SaveAll();

            return room.Id;
        }

        public string FindRoom(int roomId)
        {
            var roomRepository = ContainerService.Instance.Resolve<IRepository<Room>>();
            var room = roomRepository.FindOne(r => r.Id == roomId);
            return room.Name;
        }

        public Dictionary<int, string> ReceiveRooms()
        {
            var roomRepository = ContainerService.Instance.Resolve<IRepository<Room>>();
            var rooms = roomRepository.FindAll();

            var dictionary = new Dictionary<int, string>();

            foreach (Room room in rooms)
                dictionary.Add(room.Id, room.Name);

            return dictionary;
        }
    }
}
