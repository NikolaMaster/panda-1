using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Engine
{
    public class ModelCareController : Controller
    {
        private AuthorizationCore _mCachedAuthorizationCore;

        public AuthorizationCore Authorization
        {
            get
            {
                if (_mCachedAuthorizationCore == null)
                {
                    _mCachedAuthorizationCore = AuthorizationCore.StaticCreate();
                }
                return _mCachedAuthorizationCore;
            }
        }

        protected UserBase CurrentUser
        {
            get
            {
                return Authorization.User;
            }
        }

        protected DataAccessLayer DataAccessLayer;

        public ModelCareController()
        {
            DataAccessLayer = new DataAccessLayer();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                DataAccessLayer.Dispose();
            }
        }
    }
}