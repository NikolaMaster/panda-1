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
        private UserBase _mCachedUser;
        protected UserBase CurrentUser
        {
            get
            {
                if (_mCachedUser == null)
                {
                    _mCachedUser = AuthorizationCore.StaticCreate().User;
                }
                return _mCachedUser;
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