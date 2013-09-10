using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class AlbumController : ModelCareController
    {
        //
        // GET: /Album/

        public ActionResult Index(Guid userId)
        {
            var user = DataAccessLayer.GetById<UserBase>(userId);
            AlbumUnit albumUnit;
            if (user is PromouterUser)
                albumUnit = PromouterForm.Bind(DataAccessLayer, userId).Albums.First();
            else if (user is EmployerUser)
                albumUnit = EmployerForm.Bind(DataAccessLayer, userId).Albums.First();
            else 
                throw new Exception("Incorrect user type");
            return PartialView("Index", albumUnit);
        }

        public ActionResult Delete(Guid photoId)
        {
            var userId = DataAccessLayer.GetById<Photo>(photoId).Album.User.Id;
            DataAccessLayer.DeleteById<Photo>(photoId);
            DataAccessLayer.DbContext.SaveChanges();
            return Index(userId);
        }
    }
}
