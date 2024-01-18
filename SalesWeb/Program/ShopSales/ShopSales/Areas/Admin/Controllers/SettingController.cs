using ShopSales.Models;
using ShopSales.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        // GET: Admin/Setting
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            var data = dbContext.SystemSettings.Find(1);
            if (data != null)
            {
                return View(data);

            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SystemSetting setting)
        {
            var existingSetting = dbContext.SystemSettings.Find(1);
            if (ModelState.IsValid)
            {
                if (existingSetting == null)
                {
                    dbContext.SystemSettings.Add(setting);
                    dbContext.SaveChanges();
                    ViewBag.Status = "Save Successfully";
                }
                else
                {
                    dbContext.SystemSettings.Attach(existingSetting);
                    existingSetting.SettingTitle = setting.SettingTitle;
                    existingSetting.SettingLogo = setting.SettingLogo;
                    existingSetting.SettingHotline = setting.SettingHotline;
                    existingSetting.SettingEmail = setting.SettingEmail;
                    existingSetting.SettingDesSeo = setting.SettingDesSeo;
                    existingSetting.SettingKeySeo = setting.SettingKeySeo;
                    existingSetting.SettingTitleSeo = setting.SettingTitleSeo;
                    existingSetting.LinkFacebook = setting.LinkFacebook;
                    existingSetting.LinkInstagram = setting.LinkInstagram;
                    existingSetting.LinkPinterest = setting.LinkPinterest;
                    existingSetting.LinkSkype = setting.LinkSkype;
                    dbContext.Entry(existingSetting).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    ViewBag.Status = "Save Successfully";
                }
            }

            return View(existingSetting);
        }
    }
}