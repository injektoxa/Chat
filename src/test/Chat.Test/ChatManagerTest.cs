using System;
using System.Linq;
using Chat.BusinessLogic.Data;
using Chat.BusinessLogic.Interfaces;
using Chat.Core.Impl;
using Chat.Core.Interfaces;
using Chat.DataAccess.Data;
using Chat.DataAccess.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chat.Test
{
    [TestClass]
    public class ChatManagerTest
    {
        private static IContainer _container;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _container = ContainerService.Instance;
            _container.Register(typeof(IChatManager),typeof(ChatManager));
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            _container.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ReceiveMessagesTestException()
        {
            IChatManager target = ContainerService.Instance.Resolve<ChatManager>();
            const string chatRoomId = "100";

            target.ReceiveMessages("0", chatRoomId);
        }

        [TestMethod]
        public void ReceiveMessagesTest()
        {
            IChatManager target = ContainerService.Instance.Resolve<ChatManager>();
            const string userId = "100";
            const string chatRoomId = "100";

            IRepository<User> userRepository = ContainerService.Instance.Resolve<IRepository<User>>();

            var user = new User
                           {
                               Id = Convert.ToInt16(userId),
                               Name = "Kiril",
                               Password = "123",
                               TimeLogIn = DateTime.Now
                           };

            userRepository.Add(user);
            userRepository.SaveAll();

            IRepository<Room> roomRepository = ContainerService.Instance.Resolve<IRepository<Room>>();

            var room = new Room
                           {
                               Id = Convert.ToInt16(chatRoomId),
                               Name = "test"
                           };

            roomRepository.Add(room);
            roomRepository.SaveAll();

            IRepository<Message> messageRepository = ContainerService.Instance.Resolve<IRepository<Message>>();

            Message message = new Message
                              {
                                  Date = DateTime.Now,
                                  Id = messageRepository.FindAll().Count() + 1,
                                  RoomId = 100,
                                  UserId = 100,
                                  Text = "testMessage"
                              };

            messageRepository.Add(message);
            messageRepository.SaveAll();

            string str = target.ReceiveMessages(userId, chatRoomId);

            var s = str.Split(new[]{"Date"},StringSplitOptions.None);

            messageRepository.Delete(message);
            messageRepository.SaveAll();

            userRepository.Delete(user);
            userRepository.SaveAll();

            roomRepository.Delete(room);
            roomRepository.SaveAll();

            Assert.AreEqual(1, s.Length);
        }

        [TestMethod]
        public void SendMessageTest()
        {
            IRepository<User> userRepository = ContainerService.Instance.Resolve<IRepository<User>>();
            User user = new User
                            {
                                Id = 100,
                                Name = "Kiril",
                                Password = "123",
                                TimeLogIn = DateTime.Now
                            };
            userRepository.Add(user);
            userRepository.SaveAll();

            IRepository<Room> roomRepository = ContainerService.Instance.Resolve<IRepository<Room>>();

            Room room = new Room
                            {
                                Id = 100,
                                Name = "test"
                            };

            roomRepository.Add(room);
            roomRepository.SaveAll();

            var target = new ChatManager();
            const string text = "Hello";
            string userId = "100";
            string chatRoomId = "100";

            target.SendMessage(text, userId, chatRoomId);

            IRepository<Message> messageRepository = ContainerService.Instance.Resolve<IRepository<Message>>();

            var actual = messageRepository.FindAll(
                m => m.Text == text &&
                    m.UserId == Convert.ToInt16(userId) &&
                    m.RoomId == Convert.ToInt16(chatRoomId)).Count();

            var messageId = messageRepository.FindAll().Count();
            var message = messageRepository.FindOne(m => m.Id == messageId);
            messageRepository.Delete(message);

            userRepository.Delete(user);
            userRepository.SaveAll();

            roomRepository.Delete(room);
            roomRepository.SaveAll();

            Assert.AreEqual(1, actual);
        }
    }
}
