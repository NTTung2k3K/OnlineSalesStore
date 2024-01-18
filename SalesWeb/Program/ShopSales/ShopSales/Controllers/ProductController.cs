using PagedList;
using ShopSales.Models;
using ShopSales.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private ApplicationDbContext dBContext = new ApplicationDbContext();

        public ActionResult Index(int? ProductCategoryId,int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var size = 10;
            ViewBag.size = size;
            ViewBag.page = page;
            var PageQuantity = page.HasValue ? Convert.ToInt32(page) : 1;
            var data = dBContext.Products.ToList();
            if (ProductCategoryId != null)
            {
                data = data.Where(x => x.ProductCategoryId == ProductCategoryId).ToList();
            }
            return View(data.ToPagedList(PageQuantity,size));
        }

        public ActionResult ProductCategory(string Alias,int? ProductCategoryId)
        {
            var data = dBContext.Products.ToList();
            if (ProductCategoryId != null)
            {
                data = data.Where(x => x.ProductCategoryId == ProductCategoryId).ToList();
                ViewBag.ProductCategoryId = ProductCategoryId;
            }
            return View(data);
        }
        public ActionResult Partial_Home()
        {
            var data = dBContext.Products.Include("ProductImages").Where(x=> x.isHome==true && x.isSell==true && x.isActive == true ).Take(20).ToList();
            return PartialView("Partial_Home", data);
        }
        public ActionResult Partial_Home_Sale()
        {
            var data = dBContext.Products.Include("ProductImages").Where(x => x.isHome == true && x.isSell == true && x.isSale==true && x.isActive == true).Take(20).ToList();
            return PartialView("Partial_Home_Sale", data);
        }
        public ActionResult Parial_Product_Nav(int? ProductCategoryId)
        {
            var data = dBContext.productCategories.ToList();
            if (ProductCategoryId != null)
            {
                ViewBag.ProductCategoryId = ProductCategoryId;
            }
            return PartialView("Parial_Product_Nav", data);
        }

        public ActionResult Partial_Product_Breadcrumbs(int? ProductCategoryId)
        {
            ProductCategory item = null;
            if (ProductCategoryId != null)
            {
                item = dBContext.productCategories.Find(ProductCategoryId);
            }
            
            return PartialView("Partial_Product_Breadcrumbs", item);
        }
        public ActionResult DetailProduct(int ProductId)
        {
            var item = dBContext.Products.Include("ProductImages").SingleOrDefault(x => x.ProductId == ProductId);
            item.Viewed += 1;
            dBContext.Products.Attach(item);
            dBContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
            dBContext.SaveChanges();
            return View(item);
        }

    }
}