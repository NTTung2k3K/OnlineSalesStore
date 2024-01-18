using ShopSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        private ApplicationDbContext dBContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial_Home_News()
        {
            var data = dBContext.Posts.OrderByDescending(x => x.CategoryId).Where(x => x.isActive == true).Take(3).ToList();
            return PartialView("Partial_Home_News", data);
        }
    }
}