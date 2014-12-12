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
    public class TripDAOUnitTest
    {
        [TestMethod]
        public void Test_TripDAO_Add_Method_OK()
        {
            var date = new DateTime();
            var list = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.IsNotNull(list);
            var firstShip = Factory.Factory.getInstanse().getDAO<Ship>().GetList().FirstOrDefault();
            if (firstShip == null) { throw new AssertFailedException(); }
            var firstPort = Factory.Factory.getInstanse().getDAO<Port>().GetList().FirstOrDefault();
            if (firstPort == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Trip>().Add(
                new Trip
                {
                    EndDate = new DateTime(), 
                    StartDate = new DateTime(), 
                    PortFromId = firstPort.Id, 
                    PortToId = firstPort.Id, 
                    ShipId = firstPort.Id
                });
            var newList = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
        }

        [TestMethod]
        public void Test_TripDAO_Remove_Entity_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.IsNotNull(list);
            var firstShip = Factory.Factory.getInstanse().getDAO<Ship>().GetList().FirstOrDefault();
            if (firstShip == null) { throw new AssertFailedException(); }
            var firstPort = Factory.Factory.getInstanse().getDAO<Port>().GetList().FirstOrDefault();
            if (firstPort == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Trip>().Add(
                new Trip
                {
                    EndDate = new DateTime(),
                    StartDate = new DateTime(),
                    PortFromId = firstPort.Id,
                    PortToId = firstPort.Id,
                    ShipId = firstPort.Id
                });
            var newList = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            Factory.Factory.getInstanse().getDAO<Trip>().Remove(lastEntity);
            newList = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_TripDAO_RemoveById_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.IsNotNull(list);
            var firstShip = Factory.Factory.getInstanse().getDAO<Ship>().GetList().FirstOrDefault();
            if (firstShip == null) { throw new AssertFailedException(); }
            var firstPort = Factory.Factory.getInstanse().getDAO<Port>().GetList().FirstOrDefault();
            if (firstPort == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Trip>().Add(
                new Trip
                {
                    EndDate = new DateTime(),
                    StartDate = new DateTime(),
                    PortFromId = firstPort.Id,
                    PortToId = firstPort.Id,
                    ShipId = firstPort.Id
                });
            var newList = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            if (lastEntity == null) { throw new AssertFailedException();}
            Factory.Factory.getInstanse().getDAO<Trip>().Remove(lastEntity.Id);
            newList = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_TripDAO_Update_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.IsNotNull(list);
            var firstShip = Factory.Factory.getInstanse().getDAO<Ship>().GetList().FirstOrDefault();
            if (firstShip == null) { throw new AssertFailedException(); }
            var firstPort = Factory.Factory.getInstanse().getDAO<Port>().GetList().FirstOrDefault();
            if (firstPort == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Trip>().Add(
                new Trip
                {
                    EndDate = new DateTime(),
                    StartDate = new DateTime(),
                    PortFromId = firstPort.Id,
                    PortToId = firstPort.Id,
                    ShipId = firstPort.Id
                });
            var newList = Factory.Factory.getInstanse().getDAO<Trip>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var newDate = new DateTime(2020, 12, 12);
            var lastEntity = (Trip)newList.LastOrDefault();
            if (lastEntity != null)
            {
                lastEntity.StartDate = newDate;
                Factory.Factory.getInstanse().getDAO<Trip>().Update(lastEntity);
            }
            lastEntity = (Trip)Factory.Factory.getInstanse().getDAO<Trip>().GetList().LastOrDefault();
            if (lastEntity == null) throw new AssertFailedException();
            Assert.AreEqual(lastEntity.StartDate, newDate);
            Factory.Factory.getInstanse().getDAO<Trip>().Remove(lastEntity);
        }
    }
}