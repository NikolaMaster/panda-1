﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Engine.Editors;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class BlogController : ModelCareController
    {
        [HttpGet]
        public ActionResult Posts()
        {
            //var t = DataAccessLayer.DbContext.PromouterUsers;
            //var pr = DataAccessLayer.GetById<UserBase>(new Guid("80fa3949-4b83-4587-b24d-fe140b5743aa"));

            var online = DataAccessLayer.OnlineUsers<UserBase>();
            var listOfPosts = DataAccessLayer.TopRandom<BlogPost>(5);
            if (listOfPosts == null)
            {
                return HttpNotFound("Posts not found");
            }

            var blog = new Blog();
            blog.Posts = new List<Blog.Entry>();
            foreach (var blogPost in listOfPosts)
            {
                var binder = new CreateBlogToBlogPost();
                var entry = new Blog.Entry();
                binder.InverseLoad(blogPost, entry);
                blog.Posts.Add(entry);
            }

            return View(blog);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Blog.Entry model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifyDate = DateTime.Now;

                var binder = new CreateBlogToBlogPost();
                var entry = new BlogPost();
                binder.Load(model, entry);
                DataAccessLayer.Create<BlogPost>(entry);
                DataAccessLayer.DbContext.SaveChanges();
                return RedirectToAction("Posts");
            }
            return View();
        }
       
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var post = DataAccessLayer.GetById<BlogPost>(id);
            if (post == null)
            {
                return HttpNotFound("Post not found");
            }

            var binder = new CreateBlogToBlogPost();
            var entry = new Blog.Entry();
            binder.InverseLoad(post, entry);

            return View(entry);
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            var post = DataAccessLayer.GetById<BlogPost>(id);
            if (post == null)
            {
                return HttpNotFound("Post not found");
            }
            var binder = new CreateBlogToBlogPost();
            var entry = new Blog.Entry();
            binder.InverseLoad(post, entry);
            return View(entry);
        }

        [HttpPost]
        public ActionResult Edit(Blog.Entry model)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayer.UpdateById<BlogPost>(model.Id, x =>
                    {
                        x.Title = model.Title;
                        x.FullText = model.FullText;
                        x.ModifyDate = DateTime.Now;
                    });
                DataAccessLayer.DbContext.SaveChanges();
                return Detail(model.Id);
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var post = DataAccessLayer.GetById<BlogPost>(id);
            if (post == null)
            {
                return HttpNotFound("Post not found");
            }

            DataAccessLayer.DeleteById<BlogPost>(id);
            DataAccessLayer.DbContext.SaveChanges();
            return RedirectToAction("Posts");
        }
    }
}
