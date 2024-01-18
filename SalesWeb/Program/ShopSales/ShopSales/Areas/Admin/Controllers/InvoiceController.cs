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
    public class InvoiceController : Controller
    {
        // GET: Admin/Invoice
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            var data = dbContext.Ordes.Include("OrderDetails").ToList();
            var PageNumber = 1;
            var size = 10;
            ViewBag.size = size;
            ViewBag.page = PageNumber;
            return View(data.ToPagedList(PageNumber, size));
        }
        [HttpPost]
        public ActionResult Index(string search, int? page)
        {
            int PageNunber = page ?? 1;
            var data = dbContext.Ordes.ToList();
            if(search!=null && !string.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.Code.Contains(search) || x.CustomerName.Contains(search) || x.Phone.Contains(search)).ToList();
            }
            var size = 10;
            ViewBag.size = size;
            ViewBag.page = PageNunber;
            return View(data.ToPagedList(PageNunber, size));
        }

      
        public ActionResult Detail(int OrderId)
        {
            var categories = dbContext.Ordes.Include("OrderDetails").ToList();
            var item = dbContext.Ordes.Include("OrderDetails").SingleOrDefault(p => p.OrderId == OrderId);
            return View(item);
        }

        [HttpPost]
        public JsonResult UpdateState(int OrderId, string State)
        {
            var code = new { code = -1, success = false };
            var item = dbContext.Ordes.Find(OrderId);
            if (item != null)
            {
                dbContext.Ordes.Attach(item);
                item.OrderState = State;
                item.ModifiedDate = DateTime.Now;
                dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                code = new { code = 1, success = true };

            }
            return Json(code, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Order order, List<string> Image)
        //{
        //    if (ModelState.IsValid)
        //    {
            
        //    }
                
        //}

        [HttpPost]
        public JsonResult Delete(int OrderId)
        {
            var item = dbContext.Ordes.Find(OrderId);
            if (item != null)
            {
                dbContext.Ordes.Remove(item);
                dbContext.SaveChanges();
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
                    var item = dbContext.Ordes.Find(Int32.Parse(i));
                    dbContext.Ordes.Remove(item);
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