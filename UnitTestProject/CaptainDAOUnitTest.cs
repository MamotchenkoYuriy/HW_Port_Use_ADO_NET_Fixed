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
    public class CaptainDAOUnitTest
    {
        [TestMethod]
        public void Test_CaptainDAO_Add_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<Captain>().Add(new Captain() { FirstName = "Test", LastName = "Test" });
            var newList = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
        }

        [TestMethod]
        public void Test_CaptainDAO_Remove_Entity_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<Captain>().Add(new Captain() { FirstName = "Test", LastName = "Test" });
            var newList = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = newList.LastOrDefault();
            Factory.Factory.getInstanse().getDAO<Captain>().Remove(lastEntity);
            newList = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_CaptainDAO_RemoveById_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<Captain>().Add(new Captain() { FirstName = "Test", LastName = "Test" });
            var newList = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastId = newList.LastOrDefault().Id;
            Factory.Factory.getInstanse().getDAO<Captain>().Remove(lastId);
            newList = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void Test_CaptainDAO_Update_Method_OK()
        {
            var list = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.IsNotNull(list);
            Factory.Factory.getInstanse().getDAO<Captain>().Add(new Captain() { FirstName = "Test", LastName = "Test" });
            var newList = Factory.Factory.getInstanse().getDAO<Captain>().GetList();
            Assert.AreEqual(list.Count + 1, newList.Count);
            var lastEntity = (Captain)newList.LastOrDefault();
            if (lastEntity == null) { throw new AssertFailedException(); }
            lastEntity.FirstName = "Changed FirstName";
            Factory.Factory.getInstanse().getDAO<Captain>().Update(lastEntity);
            lastEntity = (Captain)Factory.Factory.getInstanse().getDAO<Captain>().GetList().LastOrDefault();
            if (lastEntity == null) { throw new AssertFailedException(); }
            Assert.AreEqual(lastEntity.FirstName, "Changed FirstName");
            Factory.Factory.getInstanse().getDAO<City>().Remove(lastEntity);
        }

    }
}