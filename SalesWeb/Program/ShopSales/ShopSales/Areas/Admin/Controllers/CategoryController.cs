using ShopSales.Models;
using ShopSales.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {

            var data = dbContext.Categories.ToList();
            return View(data);
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreateDate = DateTime.Now;
                category.ModifiedDate = DateTime.Now;
                category.Alias = ShopSales.Models.Common.FillerAlias.FilterChar(category.Title);
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
        public ActionResult Edit(int CategoryId)
        {
            var category = dbContext.Categories.Find(CategoryId);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Attach(category);
                category.ModifiedDate = DateTime.Now;
                dbContext.Entry(category).Property(x => x.Title).IsModified = true;
                dbContext.Entry(category).Property(x => x.Description).IsModified = true;
                dbContext.Entry(category).Property(x => x.Position).IsModified = true;
                dbContext.Entry(category).Property(x => x.SeoTitle).IsModified = true;
                dbContext.Entry(category).Property(x => x.SeoDescription).IsModified = true;
                dbContext.Entry(category).Property(x => x.SeoKeyword).IsModified = true;
                dbContext.Entry(category).Property(x => x.ModifiedDate).IsModified = true;
                dbContext.Entry(category).Property(x => x.ModifierBy).IsModified = true;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
        [HttpPost]
        public JsonResult Delete(int CategoryId)
        {
            var category = dbContext.Categories.Find(CategoryId);
            if (category != null)
            {
                dbContext.Categories.Remove(category);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}