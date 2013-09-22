using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{
    public class CurrentUserToUserInfo : BaseBinder<object, UserInfo>
    {
        public override void Load(object source, UserInfo dest)
        {
            //throw new NotImplementedException();
            var core = AuthorizationCore.StaticCreate();
            dest.Coins = core.User.Coins;
            dest.FavoritesCount = core.FavoritesCount;
            dest.UserController = core.User.ControllerNameByUser();
            dest.UserId = core.User.Id;
        }

        public override void InverseLoad(UserInfo source, object dest)
        {
            throw new NotImplementedException();
        }
    }
}