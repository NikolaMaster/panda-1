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
            return PartialView("Index", PromouterForm.Bind(DataAccessLayer, userId).Albums.First());
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
