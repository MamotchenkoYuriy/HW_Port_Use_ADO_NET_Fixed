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
    public class CityDAOUnitTest
    {
        [TestMethod]
        public void Test_CityDAO_Add_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<City>().Add(new City(){ Name = "Test City" });
            var newList = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
        }

        [TestMethod]
        public void Test_CityDAO_Remove_Entity_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<City>().Add(new City() { Name = "Test City" });
            var newList = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            Factory.Factory.getInstanse().getDAO<City>().Remove(lastEntity);
            newList = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_CityDAO_RemoveById_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<City>().Add(new City() { Name = "Test City" });
            var newList = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastId = newList.LastOrDefault().Id;
            Factory.Factory.getInstanse().getDAO<City>().Remove(lastId);
            newList = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_CityDAO_Update_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<City>().Add(new City() { Name = "Test City" });
            var newList = Factory.Factory.getInstanse().getDAO<City>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            City lastEntity = (City)newList.LastOrDefault();
            lastEntity.Name = "Changed City"; 
            Factory.Factory.getInstanse().getDAO<City>().Update(lastEntity);
            lastEntity = (City)Factory.Factory.getInstanse().getDAO<City>().GetList().LastOrDefault();
            Assert.AreEqual(lastEntity.Name, "Changed City");
            Factory.Factory.getInstanse().getDAO<City>().Remove(lastEntity);
        }
    }
}