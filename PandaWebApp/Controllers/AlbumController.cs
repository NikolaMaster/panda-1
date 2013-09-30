using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Filters;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class AlbumController : ModelCareController
    {
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

        [BaseAuthorizationReuired]
        public ActionResult Delete(Guid photoId)
        {
            var userId = DataAccessLayer.GetById<Photo>(photoId).Album.User.Id;
            DataAccessLayer.DeleteById<Photo>(photoId);
            DataAccessLayer.DbContext.SaveChanges();
            return Index(userId);
        }

        [HttpGet]
        public ActionResult Album(Guid userId)
        {
            var user = DataAccessLayer.GetById<UserBase>(userId);
            AlbumUnit albumUnit;
            if (user is PromouterUser)
                albumUnit = PromouterForm.Bind(DataAccessLayer, userId).Albums.First();
            else if (user is EmployerUser)
                albumUnit = EmployerForm.Bind(DataAccessLayer, userId).Albums.First();
            else
                throw new Exception("Incorrect user type");
            return View(albumUnit);
        }


        public ActionResult Album2(Guid userId)
        {
            var startFromStr = Request["photosFrom"];
            var startFrom = 0;
            if (!string.IsNullOrEmpty(startFromStr))
                int.TryParse(startFromStr, out startFrom);
            var endAt = startFrom + (startFrom == 0 ? 2 * WebConstants.PhotoPerRow : WebConstants.PhotoPerRow);

            var user = DataAccessLayer.GetById<UserBase>(userId);
            AlbumUnit albumUnit;
            if (user is PromouterUser)
                albumUnit = PromouterForm.Bind(DataAccessLayer, userId).Albums.First();
            else if (user is EmployerUser)
                albumUnit = EmployerForm.Bind(DataAccessLayer, userId).Albums.First();
            else
                throw new Exception("Incorrect user type");
            albumUnit.Photos = albumUnit.Photos.Skip(startFrom).Take(endAt - startFrom).ToList();
            return PartialView(albumUnit);
        }
    }
}
