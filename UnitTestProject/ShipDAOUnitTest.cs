using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory;
using Factory.Implements;
using Factory.Interfaces;
using Tables;
using System.Linq;
using System.Collections.Generic;


namespace UnitTestProject
{
    [TestClass]
    public class ShipDAOUnitTest
    {
        [TestMethod]
        public void Test_ShipDAO_Add_Method_OK()
        {
            var date = new DateTime();
            var list = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.IsNotNull(list);
            var firstCaptain = Factory.Factory.getInstanse().getDAO<Captain>().GetList().FirstOrDefault();
            if (firstCaptain == null) { throw new AssertFailedException(); }
            var firstPort = Factory.Factory.getInstanse().getDAO<Port>().GetList().FirstOrDefault();
            if (firstPort == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Ship>().Add(
                new Ship()
                {
                    Capacity = 100,
                    CaptainId = firstCaptain.Id,
                    CreateDate = new DateTime(),
                    Number = "100500",
                    MaxDistance = 100500,
                    PortId = firstPort.Id,
                    TeamCount = 100500
                });
            var newList = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
        }

        [TestMethod]
        public void Test_ShipDAO_Remove_Entity_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.IsNotNull(list);
            var firstCaptain = Factory.Factory.getInstanse().getDAO<Captain>().GetList().FirstOrDefault();
            if (firstCaptain == null) { throw new AssertFailedException();}
            var firstPort = Factory.Factory.getInstanse().getDAO<Port>().GetList().FirstOrDefault();
            if (firstPort == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Ship>().Add(
                new Ship
                {
                    Capacity = 100,
                    CaptainId = firstCaptain.Id,
                    CreateDate = new DateTime(),
                    Number = "100500",
                    MaxDistance = 100500,
                    PortId = firstPort.Id,
                    TeamCount = 100500
                });
            var newList = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            Factory.Factory.getInstanse().getDAO<Ship>().Remove(lastEntity);
            newList = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_ShipDAO_RemoveById_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.IsNotNull(list);
            var firstCaptain = Factory.Factory.getInstanse().getDAO<Captain>().GetList().FirstOrDefault();
            if (firstCaptain == null) { throw new AssertFailedException(); }
            var firstPort = Factory.Factory.getInstanse().getDAO<Port>().GetList().FirstOrDefault();
            if (firstPort == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Ship>().Add(
                new Ship
                {
                    Capacity = 100,
                    CaptainId = firstCaptain.Id,
                    CreateDate = new DateTime(),
                    Number = "100500",
                    MaxDistance = 100500,
                    PortId = firstPort.Id,
                    TeamCount = 100500
                });
            var newList = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            Factory.Factory.getInstanse().getDAO<Ship>().Remove(lastEntity);
            newList = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_ShipDAO_Update_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.IsNotNull(list);
            var firstCaptain = Factory.Factory.getInstanse().getDAO<Captain>().GetList().FirstOrDefault();
            if (firstCaptain == null) { throw new AssertFailedException(); }
            var firstPort = Factory.Factory.getInstanse().getDAO<Port>().GetList().FirstOrDefault();
            if (firstPort == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Ship>().Add(
                new Ship
                {
                    Capacity = 100,
                    CaptainId = firstCaptain.Id,
                    CreateDate = new DateTime(),
                    Number = "100500",
                    MaxDistance = 100500,
                    PortId = firstPort.Id,
                    TeamCount = 100500
                });
            var newList = Factory.Factory.getInstanse().getDAO<Ship>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = (Ship)newList.LastOrDefault();
            if (lastEntity != null)
            {
                lastEntity.Number = "Changed Number";
                Factory.Factory.getInstanse().getDAO<Ship>().Update(lastEntity);
            }
            lastEntity = (Ship)Factory.Factory.getInstanse().getDAO<Ship>().GetList().LastOrDefault();
            if (lastEntity == null) throw new AssertFailedException();
            Assert.AreEqual(lastEntity.Number, "Changed Number");
            Factory.Factory.getInstanse().getDAO<Ship>().Remove(lastEntity);
        }
    }
}