using System.Linq;
using Chat.BusinessLogic.Data;
using Chat.BusinessLogic.Interfaces;
using Chat.Core.Impl;
using Chat.DataAccess.Data;
using Chat.DataAccess.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Chat.Test
{
    [TestClass]
    public class RoomManagerTest
    {
        [TestMethod]
        public void ReceiveRoomsTest()
        {
            var roomRepository = ContainerService.Instance.Resolve<IRepository<Room>>();
            var roomCountBefore = roomRepository.FindAll().Count();

            Room room = new Room
            {
                Id = roomCountBefore + 1,
                Name = "test room"
            };
            roomRepository.Add(room);
            roomRepository.SaveAll();

            //var actualAfter = target.ReceiveRooms().Split(';').Count();

            roomRepository.Delete(room);
            roomRepository.SaveAll();

            //Assert.AreEqual(actualBefore + 1, actualAfter);
        }
    }
}
