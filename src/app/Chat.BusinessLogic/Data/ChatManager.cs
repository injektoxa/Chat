using System;
using System.Collections.Generic;
using System.Linq;
using Chat.BusinessLogic.Interfaces;
using Chat.Core.Impl;
using Chat.DataAccess.Data;
using Chat.DataAccess.Interfaces;

namespace Chat.BusinessLogic.Data
{
    public class ChatManager : IChatManager
    {
        private readonly DataClassesDataContext _dataContext;

        public ChatManager()
        {
            _dataContext = new DataClassesDataContext();
        }

        public void SendMessage(string text, string userId, string chatRoomId)
        {
            IRepository<Message> messageRepository = ContainerService.Instance.Resolve<IRepository<Message>>();

            var messageId = messageRepository.FindAll().Count() + 1;

            Message message = new Message
                                  {
                                      Date = DateTime.Now,
                                      Id = messageId,
                                      RoomId = Convert.ToInt16(chatRoomId),
                                      UserId = Convert.ToInt16(userId),
                                      Text = text
                                  };

            messageRepository.Add(message);
            messageRepository.SaveAll();
        }

        public string ReceiveMessages(string chatRoomId, string userId)
        {
            IRepository<Message> messagesRepository = new SqlRepository<Message>(_dataContext);
            IRepository<User> userRepository = new SqlRepository<User>(_dataContext);

            string str = "";

            var user = userRepository.FindOne(u => u.Id == Convert.ToInt16(userId));
            List<Message> messages =
                messagesRepository.FindAll(
                    m => m.Date > user.TimeLogIn - new TimeSpan(0, 1, 0) && m.RoomId == Convert.ToInt16(chatRoomId)).
                    ToList();

            for (int i = 0; i < messages.Count(); i++)
            {
                var userName = userRepository.FindOne(u => u.Id == messages[i].UserId);
                str += string.Format("{0}:{1}:{2} <{3}>: {4} \n\r", messages[i].Date.Hour, messages[i].Date.Minute,messages[i].Date.Second, userName.Name, messages[i].Text);
            }

            return str;
        }
    }
}

