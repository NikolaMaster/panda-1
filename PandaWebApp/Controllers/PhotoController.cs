using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Filters;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class PhotoController : ModelCareController
    {
        [HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult Edit(Guid id)
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
        public ActionResult Edit(PhotoForm model)
        {
            var photo = DataAccessLayer.GetById<Photo>(Guid.Parse(model.Id));
            ImageCreator.Create(photo.SourceUrl, new Rectangle(model.x1, model.y1, model.x2 - model.x1, model.y2 - model.y1));
            var user = photo.Album.User;
            return Redirect(string.Format(@"\{0}\Edit\{1}", user.ControllerNameByUser(), user.Id));
        }

    }
}
