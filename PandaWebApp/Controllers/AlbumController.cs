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
        [HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult Crop(Guid id)
        {

            var photo = DataAccessLayer.GetById<Photo>(id);
            var user = photo.Album.User;
            var model = new PhotoForm
            {
                Id = photo.Id.ToString(),
                SourceUrl = photo.SourceUrl,
                Controller = user.ControllerNameByUser(),
                UserId = user.Id
            };
            return View(model);
        }

        [HttpPost]
        [BaseAuthorizationReuired]
        public ActionResult Crop(PhotoForm model)
        {
            var photo = DataAccessLayer.GetById<Photo>(Guid.Parse(model.Id));
            ImageCreator.Crop(photo.SourceUrl, model.x1, model.y1, model.x2, model.y2);
            var user = photo.Album.User;
            return Redirect(string.Format(@"\{0}\Edit\{1}", user.ControllerNameByUser(), user.Id));
        }

        [BaseAuthorizationReuired]
        public ActionResult UpdateAvatar(Guid id)
        {
            var photo = DataAccessLayer.GetById<Photo>(id);
            var user = photo.Album.User;
            user.Avatar = photo;
            DataAccessLayer.DbContext.SaveChanges();
            return Edit(user.Id);
        }


        public ActionResult Edit(Guid userId)
        {
            var user = DataAccessLayer.GetById<UserBase>(userId);
            AlbumUnit albumUnit;
            if (user is PromouterUser)
                albumUnit = PromouterForm.Bind(DataAccessLayer, userId).Albums.First();
            else if (user is EmployerUser)
                albumUnit = EmployerForm.Bind(DataAccessLayer, userId).Albums.First();
            else 
                throw new Exception("Incorrect user type");
            return PartialView("Edit", albumUnit);
        }

        [BaseAuthorizationReuired]
        public ActionResult Delete(Guid photoId)
        {
            var userId = DataAccessLayer.GetById<Photo>(photoId).Album.User.Id;
            DataAccessLayer.DeleteById<Photo>(photoId);
            DataAccessLayer.DbContext.SaveChanges();
            return Edit(userId);
        }

        public ActionResult Index(Guid userId)
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
