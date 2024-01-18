using ShopSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        private ApplicationDbContext dBContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial_Home_Arrival()
        {
            var data = dBContext.productCategories.ToList();
            return PartialView(data);
        }
        public ActionResult Partial_Home_Categories()
        {
            var data = dBContext.productCategories.ToList();
            return PartialView(data);
        }
        
    }
}