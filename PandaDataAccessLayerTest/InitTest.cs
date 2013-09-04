using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaDataAccessLayer;
using System.Data.Entity;
using System.Linq;
using EntityFramework.Extensions;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System.Collections.Generic;


namespace PandaDataAccessLayerTest
{
    [TestClass]
    public class InitTest
    {
        [TestInitialize]
        public void InitTests() 
        {
            Database.SetInitializer<MainDbContext>(new MainInitializer());
        }

        [TestMethod]
        public void DefaultAttribTypesExistsTest()
        {
            using (var dal = new DataAccessLayerBase<MainDbContext>())
            {
                Assert.IsTrue(dal.DbContext.AttribTypes.Count() > 0);
            }
        }

        [TestMethod]
        public void DefaultChecklistTypesExistsTest()
        {
            using (var dal = new DataAccessLayerBase<MainDbContext>())
            {
                Assert.IsTrue(dal.DbContext.ChecklistTypes.Count() > 0);
            }
        }
    }
}
