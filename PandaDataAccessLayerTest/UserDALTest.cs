using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer;
using PandaDataAccessLayer.Entities;
using System.Data.Entity;

namespace PandaDataAccessLayerTest
{
    [TestClass]
    public class UserDALTest
    {
        [TestInitialize]
        public void InitTests()
        {
            Database.SetInitializer<MainDbContext>(new MainInitializer());
        }

        [TestMethod]
        public void CreateUserWithSeo()
        {
      /*      using (var dal = new DataAccessLayer<MainDbContext>())
            {
                var userCount = dal.DbContext.Users.Count();
                var user = dal.Create<PromouterUser>();
                user.SeoEntry = dal.Create<SeoEntry>(new SeoEntry{
                    Title = "Some sheet",
                    Keyword = "Some Sheet",
                });
                dal.DbContext.SaveChanges();
                Assert.AreEqual(userCount + 1, dal.DbContext.Users.Count());
                dal.Delete(user);
                dal.DbContext.SaveChanges();
                Assert.AreEqual(userCount, dal.DbContext.Users.Count());

            }
            */
        }
    }
}
