using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Helpers;
using PandaWebApp.Engine;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class SupportController : ModelCareController
    {
        [HttpGet]
        public ActionResult Create()
        {
            var model = new SupportForm();
            if (CurrentUser != null)
            {
                model.Email = CurrentUser.Email;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(SupportForm model)
        {
            if (ModelState.IsValid)
            {
                var message = string.Format("Сообщение отправлено от имени {0}. Текст сообщения: {1}",
                    model.Email, model.Text);
                MailSender.SendMail(Properties.Settings.Default.SupportEmail, "Служба поддержки", message);
                var result = new SupportForm()
                {
                    SuccessMessage = "Ваше сообщение отправлено в службу поддержки"
                };
                return View(result);
            }
            return View(model);
        }
    }
}
