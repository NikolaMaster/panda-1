using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class BlogController : ModelCareController
    {
        [HttpGet]
        public ActionResult Index()
        {
            //TODO: get list of blogs by UserId
            //Guid id = new Guid("428efc0e-27a8-4cf7-a036-88228253a2cd");
            var listOfPosts = DataAccessLayer.TopRandom<BlogPost>(200);
            if (listOfPosts == null)
            {
                return HttpNotFound("Posts not found");
            }

            var posts = new List<Blog.Entry>();
            foreach (var blogPost in listOfPosts)
            {
                var binder = new CreateBlogToBlogPost();
                var entry = new Blog.Entry();
                binder.InverseLoad(blogPost, entry);
                posts.Add(entry);
            }
            return View(posts);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Blog.Entry model)
        {
            /*var model = new Blog.Entry();
            model.CreatedDate = DateTime.Now;
            model.ModifyDate = DateTime.Now;
            model.Title = title;
            model.FullText = fullText;
            var binder = new CreateBlogToBlogPost();
            var entry = new BlogPost();
            binder.Load(model, entry);
            DataAccessLayer.Create<BlogPost>(entry);
            DataAccessLayer.DbContext.SaveChanges();
            return RedirectToAction("Index");
            */

            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifyDate = DateTime.Now;

                var binder = new CreateBlogToBlogPost();
                var entry = new BlogPost();
                binder.Load(model, entry);
                DataAccessLayer.Create<BlogPost>(entry);
                DataAccessLayer.DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult ViewPost(Guid id)
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
        public ActionResult Update(Guid id)
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
        public ActionResult Update(Blog model)
        {
            //DataAccessLayer.UpdateById<BlogPost>(model.Id,null);
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
            return RedirectToAction("Index");
        }
    }
}
