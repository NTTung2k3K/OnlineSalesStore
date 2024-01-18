using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using ShopSales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopSales.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index(string Search, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var size = 3;
            ViewBag.size = size;
            ViewBag.page = page;
            var PageQuantity = page.HasValue ? Convert.ToInt32(page) : 1;
            var data = dbContext.Roles.OrderByDescending(x => x.Id);

            if (!string.IsNullOrEmpty(Search))
            {
                data = (IOrderedQueryable<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>)data.Where(x => x.Name.ToLower().Contains(Search.ToLower()));
            }

            return View(data.ToPagedList(PageQuantity, size));

        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IdentityRole roles)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
                roleManager.Create(roles);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(roles);
            }
        }
        public ActionResult Edit(string RoleId)
        {

            var data = dbContext.Roles.Find(RoleId);
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole roles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Your existing code
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
                    var exitingRole = dbContext.Roles.Find(roles.Id);

                    if (exitingRole != null)
                    {
                        exitingRole.Name = roles.Name;

                        // Save changes to the database
                        roleManager.Update(exitingRole);
                        dbContext.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(roles);
                    }
                }
                catch (OptimisticConcurrencyException ex)
                {
                    // Handle concurrency conflict, e.g., reload the data or show an error message
                    ModelState.AddModelError("", "Concurrency conflict. Please reload the data and try again.");
                    return View(roles); // Return the view to allow the user to resolve the conflict
                }
            }
            else
            {
                return View(roles);
            }
        }
        [HttpPost]
        public JsonResult Delete(string RoleId)
        {
            var data = dbContext.Roles.Find(RoleId);
            if (data != null)
            {
                dbContext.Roles.Remove(data);
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
                    var data = dbContext.Roles.Find(i);
                    dbContext.Roles.Remove(data);
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