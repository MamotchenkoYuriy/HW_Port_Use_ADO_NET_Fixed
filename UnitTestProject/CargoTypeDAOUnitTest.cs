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
    public class CargoTypeDAOUnitTest
    {
        [TestMethod]
        public void Test_CargoTypeDAO_Add_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<CargoType>().Add(new CargoType() { TypeName = "Test" });
            var newList = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
        }

        [TestMethod]
        public void Test_CargoTypeDAO_Remove_Entity_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<CargoType>().Add(new CargoType() { TypeName = "Test" });
            var newList = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            Factory.Factory.getInstanse().getDAO<CargoType>().Remove(lastEntity);
            newList = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_CargoTypeDAO_RemoveById_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<CargoType>().Add(new CargoType() { TypeName = "Test City" });
            var newList = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastId = newList.LastOrDefault().Id;
            Factory.Factory.getInstanse().getDAO<CargoType>().Remove(lastId);
            newList = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_CargoTypeDAO_Update_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<CargoType>().Add(new CargoType() { TypeName = "Test" });
            var newList = Factory.Factory.getInstanse().getDAO<CargoType>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = (CargoType)newList.LastOrDefault();
            lastEntity.TypeName = "Changed";
            Factory.Factory.getInstanse().getDAO<CargoType>().Update(lastEntity);
            lastEntity = (CargoType)Factory.Factory.getInstanse().getDAO<CargoType>().GetList().LastOrDefault();
            Assert.AreEqual(lastEntity.TypeName, "Changed");
            Factory.Factory.getInstanse().getDAO<CargoType>().Remove(lastEntity);
        }

    }
}