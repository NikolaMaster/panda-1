using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System.Data.Entity;

namespace PandaDataAccessLayerTest
{

    [TestClass]
    public class DALTest
    {
        [TestInitialize]
        public void InitTests()
        {
            Database.SetInitializer<MainDbContext>(new MainInitializer());
        }

        [TestMethod]
        public void CreateAndDeleteUsersTest()
        {
            using (var dal = new DataAccessLayer<MainDbContext>())
            {
                var userCount = dal.DbContext.PromouterUsers.Count();
                var promouter = dal.Create<PromouterUser>(new PromouterUser 
                {
                    Email = "sos1g3@gmail.com"
                });
                dal.DbContext.SaveChanges();

                Assert.AreEqual(userCount + 1, dal.DbContext.PromouterUsers.Count());

                dal.Delete<PromouterUser>(dal.DbContext.Entry(promouter).Entity);
                dal.DbContext.SaveChanges();

                Assert.AreEqual(userCount, dal.DbContext.PromouterUsers.Count());
            }
        }
    }
}
