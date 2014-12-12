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
    public class CargoDAOUnitTest
    {
        [TestMethod]
        public void Test_CargoDAO_Add_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.IsNotNull(list);
            var firstCargoType = Factory.Factory.getInstanse().getDAO<CargoType>().GetList().FirstOrDefault();
            if (firstCargoType == null) { throw new AssertFailedException(); }
            var firstTrip = Factory.Factory.getInstanse().getDAO<Trip>().GetList().FirstOrDefault();
            if (firstTrip == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Cargo>().Add(
                new Cargo()
                {
                    CargoTypeId = firstCargoType.Id,
                    Number = 100500,
                    InsurancePrice = 100500,
                    Price = 100500,
                    TripId = firstTrip.Id,
                    Weight = 100500
                });
            var newList = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
        }

        [TestMethod]
        public void Test_PortDAO_Remove_Entity_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.IsNotNull(list);
            var firstCargoType = Factory.Factory.getInstanse().getDAO<CargoType>().GetList().FirstOrDefault();
            if (firstCargoType == null) { throw new AssertFailedException(); }
            var firstTrip = Factory.Factory.getInstanse().getDAO<Trip>().GetList().FirstOrDefault();
            if (firstTrip == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Cargo>().Add(
                new Cargo()
                {
                    CargoTypeId = firstCargoType.Id,
                    Number = 100500,
                    InsurancePrice = 100500,
                    Price = 100500,
                    TripId = firstTrip.Id,
                    Weight = 100500
                });
            var newList = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            Factory.Factory.getInstanse().getDAO<Cargo>().Remove(lastEntity);
            newList = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_PortDAO_RemoveById_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.IsNotNull(list);
            var firstCargoType = Factory.Factory.getInstanse().getDAO<CargoType>().GetList().FirstOrDefault();
            if (firstCargoType == null) { throw new AssertFailedException(); }
            var firstTrip = Factory.Factory.getInstanse().getDAO<Trip>().GetList().FirstOrDefault();
            if (firstTrip == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Cargo>().Add(
                new Cargo()
                {
                    CargoTypeId = firstCargoType.Id,
                    Number = 100500,
                    InsurancePrice = 100500,
                    Price = 100500,
                    TripId = firstTrip.Id,
                    Weight = 100500
                });
            var newList = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            if (lastEntity == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Cargo>().Remove(lastEntity.Id);
            newList = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_PortDAO_Update_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.IsNotNull(list);
            var firstCargoType = Factory.Factory.getInstanse().getDAO<CargoType>().GetList().FirstOrDefault();
            if (firstCargoType == null) { throw new AssertFailedException(); }
            var firstTrip = Factory.Factory.getInstanse().getDAO<Trip>().GetList().FirstOrDefault();
            if (firstTrip == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Cargo>().Add(
                new Cargo()
                {
                    CargoTypeId = firstCargoType.Id,
                    Number = 100500,
                    InsurancePrice = 100500,
                    Price = 100500,
                    TripId = firstTrip.Id,
                    Weight = 100500
                });
            var newList = Factory.Factory.getInstanse().getDAO<Cargo>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = (Cargo)newList.LastOrDefault();
            if (lastEntity == null) { throw new AssertFailedException(); }
            lastEntity.Number = 11111;
            Factory.Factory.getInstanse().getDAO<Cargo>().Update(lastEntity);
            lastEntity = (Cargo)Factory.Factory.getInstanse().getDAO<Cargo>().GetList().LastOrDefault();
            if (lastEntity == null) throw new AssertFailedException();
            Assert.AreEqual(lastEntity.Number, 11111);
            Factory.Factory.getInstanse().getDAO<Cargo>().Remove(lastEntity);
        }
    }
}