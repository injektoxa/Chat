using System;
using System.Linq;
using System.Collections.Generic;
using Chat.BusinessLogic.Data.Model;
using Chat.BusinessLogic.Interfaces;
using Chat.Core.Impl;
using Chat.Core.Interfaces;
using Chat.DataAccess.Data;
using Chat.DataAccess.Interfaces;

namespace Chat.BusinessLogic.Data
{
    public class UserManager : IUserManager
    {
        private readonly IChatLogger _logger;

        public UserManager()
        {
            _logger = ChatLoggerService.Instance;
        }

        public bool RegisterUser(string name, string password, int userId)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                _logger.Info("RegisterUser ArgumentNullException");
                throw new ArgumentNullException();
            }

            try
            {
                var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
                var user = userRepository.FindOne(u => u.Id == userId);

                user.Name = name;
                user.Password = password;

                userRepository.SaveAll();

                var userRoleRepository = ContainerService.Instance.Resolve<IRepository<User_Role>>();

                var userRole = new User_Role
                                         {
                                             Id = userRoleRepository.FindAll().Count() + 1,
                                             UserId = user.Id,
                                             RoleId = 0
                                         };
                userRoleRepository.Add(userRole);
                userRoleRepository.SaveAll();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("Register user", ex);
                return false;
            }
        }

        public UserInfo FindUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                _logger.Info("Find user ArgumentNullException");
                throw new ArgumentNullException();
            }

            var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
            var user = userRepository.FindOne(u => u.Name == name && u.Password == password);

            if (user != null)
            {
                return new UserInfo { Id = user.Id };
            }

            return null;
        }

        public void LoginUser(int userId)
        {
            var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
            var foundUser = userRepository.FindOne(u => u.Id == Convert.ToInt16(userId));
            foundUser.TimeLogIn = DateTime.Now;

            userRepository.SaveAll();

            var userRoleRepository = ContainerService.Instance.Resolve<IRepository<User_Role>>();
            var userRole = userRoleRepository.FindOne(u => u.UserId == Convert.ToInt16(userId));
            userRole.RoleId = 1;

            userRoleRepository.SaveAll();
        }

        public void LogoutUser(int userId)
        {
            var userRoleRepository = ContainerService.Instance.Resolve<IRepository<User_Role>>();
            var userRole = userRoleRepository.FindOne(u => u.UserId == userId);
            userRole.RoleId = 0;
            userRoleRepository.SaveAll();
        }

        public void EnterToRoom(int roomId, int userId)
        {
            var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
            var foundUser = userRepository.FindOne(u => u.Id == userId);
            foundUser.RoomId = roomId;

            userRepository.SaveAll();
        }

        public void LeaveRoom(int userId)
        {
            var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
            var foundUser = userRepository.FindOne(u => u.Id == userId);
            foundUser.RoomId = 0;

            userRepository.SaveAll();
        }

        public Dictionary<int, string> GetUsersInRoom(int roomId)
        {
            var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
            var users = userRepository.FindAll(r => r.RoomId == roomId);

            return users.ToDictionary(user => user.Id, user => user.Name);
        }

        public void DeleteUser(int userId)
        {
            if (userId == 0)
            {
                _logger.Info("DeleteUser ArgumentNullException");
                throw new ArgumentNullException();
            }

            Authorization.CheckRoles("ChatCreator");

            var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
            var user = userRepository.FindOne(u => u.Id == userId);

            user.RoomId = 0;
        }

        public int AddAnonimUser()
        {
            var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();

            User user = new User
                            {
                                Id = userRepository.FindAll().Count() + 1,
                                Name = "anonim",
                                Password = "anonim",
                                RoomId = 0,
                                TimeLogIn = DateTime.Now
                            };
            userRepository.Add(user);
            userRepository.SaveAll();

            return user.Id;
        }

        public bool IsCreator(int userId, int roomId)
        {
            var roomRepository = ContainerService.Instance.Resolve<IRepository<Room>>();
            var room = roomRepository.FindOne(r => r.CreatorId == userId && r.Id == roomId);

            if (room != null)
                return true;
            return false;
        }

        public string GetUserName(int userId)
        {
            var userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
            var userName = userRepository.FindOne(u => u.Id == userId);
            return userName.Name;
        }
    }
}
