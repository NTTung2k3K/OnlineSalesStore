using PagedList;
using ShopSales.Models;
using ShopSales.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index(string Search,int? page)
        {
            if(page == null)
            {
                page = 1;
            }
            var size = 3;
            ViewBag.size = size;
            ViewBag.page = page;
            var PageQuantity = page.HasValue ? Convert.ToInt32(page) : 1;
            var data = dbContext.News.OrderByDescending(x => x.NewsId);

            if (!string.IsNullOrEmpty(Search))
            {
                data  = (IOrderedQueryable<News>)data.Where(x => x.Alias.Contains(Search) || x.Title.Contains(Search) || x.SeoTitle.Contains(Search));
            }
            
            return View(data.ToPagedList(PageQuantity,size));

        }
        public ActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNews(News news)
        {
            if (ModelState.IsValid)
            {
                news.CreateDate = DateTime.Now;
                news.ModifiedDate = DateTime.Now;
                news.Alias = ShopSales.Models.Common.FillerAlias.FilterChar(news.Title);
                dbContext.News.Add(news);
                dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(news);
            }
        }
        public ActionResult Edit(int NewsId)
        {
            var data = dbContext.News.Find(NewsId);
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
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                dbContext.News.Attach(news);
                news.ModifiedDate = DateTime.Now;
                dbContext.Entry(news).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(news);
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
        public JsonResult IsActive(int NewsId)
        {
            var data = dbContext.Posts.Find(NewsId);
            if (data != null)
            {
                data.isActive = !data.isActive;
                dbContext.SaveChanges();
                return Json(new { success = true , IsActive = data.isActive });
            }
            else
            {
                return Json(new { success = false, IsActive = data.isActive });
            }
        }

        [HttpPost]
        public JsonResult DeleteOption(string stringId)
        {
            if (stringId != null)
            {
                var listId = stringId.Split(',');
                foreach(var i in listId)
                {
                    var item = dbContext.productCategories.Find(Int32.Parse(i));
                    dbContext.productCategories.Remove(item);
                    dbContext.SaveChanges();
                }
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

    }
}