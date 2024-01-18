using ShopSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext dBContext = new ApplicationDbContext();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial_Home()
        {
            var data = dBContext.Categories.OrderBy(x => x.Position).ToList();
            return PartialView(data);
        }

    }
}