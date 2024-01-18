using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopSales
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Pay",
                url: "pay",
                defaults: new { controller = "Pay", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopSales.Controllers" }
            );

            routes.MapRoute(
                name: "ShoppingCart",
                url: "shopping-cart",
                defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopSales.Controllers" }
            );

            //Optional
            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopSales.Controllers" }
            );
            routes.MapRoute(
                name: "Product",
                url: "product",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopSales.Controllers" }
            );

            routes.MapRoute(
                name: "ProductCategory",
                url: "list-of-products/{Alias}-{ProductCategoryId}",
                defaults: new { controller = "Product", action = "ProductCategory", ProductCategoryId = UrlParameter.Optional },
                namespaces: new[] { "ShopSales.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopSales.Controllers" }
            );
            
        }
    }
}
