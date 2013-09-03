using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayerTest
{
    [TestClass]
    public class ChecklistDALTest
    {
        [TestInitialize]
        public void InitTests()
        {
            Database.SetInitializer<MainDbContext>(new MainInitializer());
        }

        [TestMethod]
        public void CreateAndDeleteChecklistTest() 
        {
            using (var dal = new DataAccessLayer<MainDbContext>())
            {
                var checklistCount = dal.DbContext.Checklists.Count();
                var promouter = dal.Create<PrivateEmployer>(
                    new PrivateEmployer
                    {
                        Email = "email@domain.com"
                    },
                    new SeoEntry
                    {
                        Keyword = "email domain",
                        Title = "Mail",
                        Description = "Send mail to some gays =))"
                    });
                var checklist = dal.CreateChecklist(promouter, new List<AttribValue>());
                dal.DbContext.SaveChanges();

                Assert.AreEqual(checklistCount + 2, dal.DbContext.Checklists.Count());

                dal.DeleteById<Checklist>(dal.DbContext.Entry(checklist).Entity.Id);
                dal.DbContext.SaveChanges();

                Assert.AreEqual(checklistCount+1, dal.DbContext.Checklists.Count());
            }
        } 
    }
}
