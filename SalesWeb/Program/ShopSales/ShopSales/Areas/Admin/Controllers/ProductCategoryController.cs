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
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext dBContext = new ApplicationDbContext();
        // GET: Admin/ProductCategory
        public ActionResult Index(String Search, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var data = dBContext.productCategories.OrderByDescending(x => x.ProductCategoryId);
            if (!string.IsNullOrEmpty(Search))
            {
                data = (IOrderedQueryable<Models.EF.ProductCategory>)data.Where(x => x.Title.Contains(Search) ||
                                    x.SeoTitle.Contains(Search));
            }
            var size = 3;

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.size = size;
            ViewBag.page = pageIndex;
            return View(data.ToPagedList(pageIndex, size));
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                productCategory.CreateDate = DateTime.Now;
                productCategory.ModifiedDate = DateTime.Now;
                productCategory.Alias = ShopSales.Models.Common.FillerAlias.FilterChar(productCategory.Title);
                dBContext.productCategories.Add(productCategory);
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productCategory);
        }


        public ActionResult Edit(int productCategoryId)
        {
            var data = dBContext.productCategories.Find(productCategoryId);
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
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                dBContext.productCategories.Attach(productCategory);
                productCategory.ModifiedDate = DateTime.Now;
                productCategory.Alias = ShopSales.Models.Common.FillerAlias.FilterChar(productCategory.Title);

                dBContext.Entry(productCategory).State = System.Data.Entity.EntityState.Modified;
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public JsonResult Delete(int ProductCategoryId)
        {
            var data = dBContext.productCategories.Find(ProductCategoryId);
            if (data != null)
            {
                dBContext.productCategories.Remove(data);
                dBContext.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }

        }
        

        [HttpPost]
        public JsonResult DeleteOption(string stringId)
        {
            if (stringId != null)
            {
                var listId = stringId.Split(',');
                foreach (var i in listId)
                {
                    var item = dBContext.productCategories.Find(Int32.Parse(i));
                    dBContext.productCategories.Remove(item);
                    dBContext.SaveChanges();
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