using ShopSales.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSales.Models.Common
{
    public static class SystemHelper
    {
        private static ApplicationDbContext dbContext = new ApplicationDbContext();
        public static SystemSetting GetValue()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var data = dbContext.SystemSettings.Find(1);
                return data;
            }
        }
    }
}