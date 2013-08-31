﻿using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Controllers
{
    public class HomeController : ModelCareController
    {
        public int OnlineUsersCount = 10;
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PandaPulse() 
        {
            var pandaPulse = new PandaPulse
            {
                Online = DataAccessLayer.OnlineUsers<UserBase>(),
                Items = DataAccessLayer.TopRandom<UserBase>(OnlineUsersCount)
                    .Select(x => new PandaPulse.Entry
                        {
                            //TODO: default avatar  for new users
                            Image = (x.Avatar != null ?  x.Avatar.SourceUrl : string.Empty),
                            Name = x.FirstName
                        })
            };
            return PartialView(pandaPulse);
        }
    }
}