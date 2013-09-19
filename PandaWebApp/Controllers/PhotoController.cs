using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class PhotoController : ModelCareController
    {
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            
            var photo = DataAccessLayer.GetById<Photo>(id);
            var model = new PhotoForm
                {
                    Id = photo.Id.ToString(),
                    SourceUrl = photo.SourceUrl,
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PhotoForm model)
        {
            var photo = DataAccessLayer.GetById<Photo>(Guid.Parse(model.Id));
            ImageCreator.Create(photo.SourceUrl, new Rectangle(model.x1, model.y1, model.x2 - model.x1, model.y2 - model.y1));
            var user = photo.Album.User;
            return Redirect(string.Format(@"\{0}\Edit\{1}", user.ControllerNameByUser(), user.Id));
        }

    }
}
