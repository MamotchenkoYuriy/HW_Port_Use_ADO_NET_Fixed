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
    public class PortDAOUnitTest
    {
        [TestMethod]
        public void Test_PortDAO_Add_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.IsNotNull(list);
            var firstCity = Factory.Factory.getInstanse().getDAO<City>().GetList().FirstOrDefault();
            if (firstCity == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Port>().Add(
                new Port
                {
                    Name = "Test", 
                    CityId = firstCity.Id
                });
            var newList = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
        }

        [TestMethod]
        public void Test_PortDAO_Remove_Entity_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.IsNotNull(list);
            var firstCity = Factory.Factory.getInstanse().getDAO<City>().GetList().FirstOrDefault();
            if (firstCity == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Port>().Add(
                new Port()
                {
                    Name = "Test",
                    CityId = firstCity.Id
                });
            var newList = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            Factory.Factory.getInstanse().getDAO<Port>().Remove(lastEntity);
            newList = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_PortDAO_RemoveById_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.IsNotNull(list);
            var firstCity = Factory.Factory.getInstanse().getDAO<City>().GetList().FirstOrDefault();
            if (firstCity == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Port>().Add(
                new Port()
                {
                    Name = "Test",
                    CityId = firstCity.Id
                });
            var newList = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            if (lastEntity == null) { throw  new AssertFailedException();}
            Factory.Factory.getInstanse().getDAO<Port>().Remove(lastEntity.Id);
            newList = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_PortDAO_Update_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.IsNotNull(list);
            var firstCity = Factory.Factory.getInstanse().getDAO<City>().GetList().FirstOrDefault();
            if (firstCity == null) { throw new AssertFailedException(); }
            Factory.Factory.getInstanse().getDAO<Port>().Add(
                new Port()
                {
                    Name = "Test",
                    CityId = firstCity.Id
                });
            var newList = Factory.Factory.getInstanse().getDAO<Port>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = (Port)newList.LastOrDefault();
            if (lastEntity != null)
            {
                lastEntity.Name = "Changed Port Name";
                Factory.Factory.getInstanse().getDAO<Port>().Update(lastEntity);
            }
            lastEntity = (Port)Factory.Factory.getInstanse().getDAO<Port>().GetList().LastOrDefault();
            if (lastEntity == null) throw new AssertFailedException();
            Assert.AreEqual(lastEntity.Name, "Changed Port Name");
            Factory.Factory.getInstanse().getDAO<Port>().Remove(lastEntity);
        }
    }
}