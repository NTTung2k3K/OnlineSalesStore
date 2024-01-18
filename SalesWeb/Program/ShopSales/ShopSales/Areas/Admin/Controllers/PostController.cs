using ShopSales.Models;
using ShopSales.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            var data = dbContext.Posts.ToList();
            return View(data);
        }
        public ActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreateDate = DateTime.Now;
                post.ModifiedDate = DateTime.Now;
                post.Alias = ShopSales.Models.Common.FillerAlias.FilterChar(post.Title);
                post.Category = dbContext.Categories.Find(19);
                post.CategoryId = 19;

                dbContext.Posts.Add(post);

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }
        public ActionResult Edit(int PostId)
        {
            var data = dbContext.Posts.Find(PostId);
            if (data != null)
            {
                return View(data);

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("NULL");
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                dbContext.Posts.Attach(post);
                post.ModifiedDate = DateTime.Now;
                dbContext.Entry(post).State = System.Data.Entity.EntityState.Modified;
                post.Category = dbContext.Categories.Find(19);

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }
        [HttpPost]
        public JsonResult Delete(int PostId)
        {
            var data = dbContext.Posts.Find(PostId);
            if (data != null)
            {
                dbContext.Posts.Remove(data);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }

        }
        [HttpPost]
        public JsonResult IsActive(int PostId)
        {
            var data = dbContext.Posts.Find(PostId);
            if (data != null)
            {
                data.isActive = !data.isActive;
                dbContext.SaveChanges();
                return Json(new { success = true, IsActive = data.isActive });
            }
            else
            {
                return Json(new { success = false, IsActive = data.isActive });
            }
        }
    }
}