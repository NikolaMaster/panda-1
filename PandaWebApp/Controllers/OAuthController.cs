using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Social;

namespace PandaWebApp.Controllers
{
    public class OAuthController : ModelCareController
    {
        public ActionResult Ok(string social, string code)
        {

            switch (social)
            {
                case "vk":
                    var vkAccessToken = OAuth.Vk.GetAccessToken(code);
                    var vkUserInfo = OAuth.Vk.GetAuthUserInfo(vkAccessToken.UserId, vkAccessToken.Token);
                    //bind the account
                    if (!Authorization.IsGuest)
                    {
                        DataAccessLayer.UpdateById<UserBase>(CurrentUser.Id, x => x.VkId = vkUserInfo.Info.First().UserId);
                        DataAccessLayer.DbContext.SaveChanges();
                    }
                    else
                    {
                        Authorization.LoginVk(vkUserInfo);
                    }
                    break;
                case "mailru":
                    var mailRuAccessToken = OAuth.MailRu.GetAccessToken(code);
                    var mailRuUserInfo = OAuth.MailRu.GetAuthUserInfo(mailRuAccessToken.Token);
                    //bind the account
                    if (!Authorization.IsGuest)
                    {
                        DataAccessLayer.UpdateById<UserBase>(CurrentUser.Id, x => x.MailId = mailRuUserInfo.UserId);
                        DataAccessLayer.DbContext.SaveChanges();
                    }
                    else
                    {
                        Authorization.LoginMail(mailRuUserInfo);
                    }
                    break;
                case "yandex":
                    var yandexAccessToken = OAuth.Yandex.GetAccessToken(code);
                    var yandexUserInfo = OAuth.Yandex.GetAuthUserInfo(yandexAccessToken.Token);
                    //bind the account
                    if (!Authorization.IsGuest)
                    {
                        DataAccessLayer.UpdateById<UserBase>(CurrentUser.Id, x => x.YandexId = yandexUserInfo.UserId);
                        DataAccessLayer.DbContext.SaveChanges();
                    }
                    else
                    {
                        Authorization.LoginYandex(yandexUserInfo);
                    }
                    break;
                case "fb":
                    var fbAccessToken = OAuth.FB.GetAccessToken(code);
                    var fbUserInfo = OAuth.FB.GetAuthUserInfo(fbAccessToken.Token);
                    //bind the account
                    if (!Authorization.IsGuest)
                    {
                        DataAccessLayer.UpdateById<UserBase>(CurrentUser.Id, x => x.FbId = fbUserInfo.UserId);
                        DataAccessLayer.DbContext.SaveChanges();
                    }
                    else
                    {
                        Authorization.LoginFb(fbUserInfo);
                    }
                    break;
                case "google":
                    var googleAccessToken = OAuth.Google.GetAccessToken(code);
                    var googleUserInfo = OAuth.Google.GetAuthUserInfo(googleAccessToken.Token);
                    //bind the account
                    if (!Authorization.IsGuest)
                    {
                        DataAccessLayer.UpdateById<UserBase>(CurrentUser.Id, x => x.GoogleId = googleUserInfo.UserId);
                        DataAccessLayer.DbContext.SaveChanges();
                    }
                    else
                    {
                        Authorization.LoginGoogle(googleUserInfo);
                    }
                    break;
                default:
                    break;
            }

            //TODO - furl
            return Redirect("/");
        }
    }
}
