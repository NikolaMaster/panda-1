using System;
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
        public const int BlogsCount = 3;

        [HttpGet]
        public ActionResult TopPosts()
        {
            var listOfPosts = DataAccessLayer.TopRandom<BlogPost>(BlogsCount);
            if (listOfPosts == null)
            {
                return HttpNotFound("Posts not found");
            }

            var blog = new Blog {Posts = new List<Blog.Entry>()};

            foreach (var blogPost in listOfPosts)
            {
                var binder = new BlogToBlogPost(DataAccessLayer);
                var entry = new Blog.Entry();
                binder.InverseLoad(blogPost, entry);
                blog.Posts.Add(entry);
            }

            return PartialView(blog);
        }

        [HttpGet]
        public ActionResult Posts()
        {
            var listOfPosts = DataAccessLayer.TopRandom<BlogPost>(BlogsCount);
            if (listOfPosts == null)
            {
                return HttpNotFound("Posts not found");
            }

            var blog = new Blog { Posts = new List<Blog.Entry>() };

            foreach (var blogPost in listOfPosts)
            {
                var binder = new BlogToBlogPost(DataAccessLayer);
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
        
        //TODO: replace, because very dangerous =)
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Blog.Entry model,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.UtcNow;
                model.ModifyDate = DateTime.UtcNow;
                

                //if user not selected a photo , we'll using default photo
                //sorry for spike boys
                if (photo != null)
                {
                    var pict = new Photo
                    {
                        SourceUrl = ImageCreator.SavePhoto(photo)
                    };
                    DataAccessLayer.Create(pict);
                    DataAccessLayer.Refresh(pict);

                    model.Image = pict.SourceUrl;
                }
                else
                {
                    model.Image = "~/Content/img/del-1.png";
                }

                var binder = new BlogToBlogPost(DataAccessLayer);
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

            var binder = new BlogToBlogPost(DataAccessLayer);
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
            var binder = new BlogToBlogPost(DataAccessLayer);
            var entry = new Blog.Entry();
            binder.InverseLoad(post, entry);
            return View(entry);
        }

        [HttpGet]
        public ActionResult Post(Guid id)
        {
            var post = DataAccessLayer.GetById<BlogPost>(id);
            if (post == null)
            {
                return HttpNotFound("Post not found");
            }
            var binder = new BlogToBlogPost(DataAccessLayer);
            var entry = new Blog.Entry();
            binder.InverseLoad(post, entry);
            return PartialView(entry);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Blog.Entry model)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayer.UpdateById<BlogPost>(model.Id, x =>
                    {
                        x.Title = model.Title;
                        x.FullText = model.FullText;
                        x.ModifyDate = DateTime.UtcNow;
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
