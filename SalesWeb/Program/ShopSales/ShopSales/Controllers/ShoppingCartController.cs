using ShopSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private ApplicationDbContext dBContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            ShopSales.Models.ShoppingCart exitingCart = (ShoppingCart)Session["Cart"];

            if (exitingCart == null)
            {
                exitingCart = new ShoppingCart();
                return View(new ShopSales.Models.ShoppingCart { }.shoppingCarts);

            }
            return View(exitingCart.shoppingCarts.ToList());
        }

        [HttpPost]
        public JsonResult AddToCart(int ProductId, int Quantity)
        {
            var code = new { success = false, meg = "Add to cart is fail", coode = -1, Count = 0 };
            var exitingProduct = dBContext.Products.Find(ProductId);
            if (exitingProduct != null)
            {
                ShopSales.Models.ShoppingCart exitingCart = (ShoppingCart)Session["Cart"];
                if (exitingCart == null)
                {
                    exitingCart = new ShopSales.Models.ShoppingCart();
                }
                ShopSales.Models.ShoppingCartItem item = new ShopSales.Models.ShoppingCartItem();
                var primaryPrice = exitingProduct.PriceSale == null ? exitingProduct.Price : exitingProduct.PriceSale;
                item.ProductId = ProductId;
                item.ProductImage = exitingProduct.Image;
                item.ProductName = exitingProduct.Title;
                item.Quantity = Quantity;
                if (exitingProduct.PriceSale != null)
                {
                    item.PriceSale = (decimal)exitingProduct.PriceSale;
                }

                item.Price = exitingProduct.Price;
                item.TotalAmount = Quantity * (decimal)primaryPrice;
                exitingCart.shoppingCarts.Add(item);
                code = new { success = true, meg = "Add to cart is succesfully", coode = 1, Count = exitingCart.shoppingCarts.Count };
                Session["Cart"] = exitingCart;
            }
            return Json(code, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveItem(int ProductId)
        {
            var code = new { success = false, meg = "Delete item is fail", coode = -1, Count = 0 };
            ShopSales.Models.ShoppingCart exitingCart = (ShoppingCart)Session["Cart"];
            if (exitingCart != null)
            {
                var exitingProduct = dBContext.Products.Find(ProductId);
                if (exitingProduct != null)
                {
                    var exitingItem = exitingCart.shoppingCarts.FirstOrDefault(x => x.ProductId == ProductId);
                    if (exitingItem != null)
                    {
                        exitingCart.shoppingCarts.Remove(exitingItem);
                        code = new { success = true, meg = " Delete item is succesfully", coode = 1, Count = exitingCart.shoppingCarts.Count };
                    }

                }
            }

            return Json(code, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(int ProductId, int Quantity)
        {
            var code = new { success = false, meg = "Update to cart is fail", coode = -1, Count = 0 };
            var exitingProduct = dBContext.Products.Find(ProductId);
            if (exitingProduct != null)
            {
                ShopSales.Models.ShoppingCart Cart = (ShoppingCart)Session["Cart"];
                if (Cart != null)
                {
                    var item = Cart.shoppingCarts.FirstOrDefault(x => x.ProductId == ProductId);
                    if (item != null)
                    {
                        var primaryPrice = exitingProduct.PriceSale == null ? exitingProduct.Price : exitingProduct.PriceSale;

                        item.Quantity = Quantity;
                        item.TotalAmount = Quantity * (decimal)primaryPrice;
                        Session["Cart"] = Cart;
                        code = new { success = true, meg = "Update to cart is succesfully", coode = 1, Count = Cart.shoppingCarts.Count };

                    }
                }
            }
            return Json(code, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            var code = new { success = false, meg = "Delete cart is fail", coode = -1, Count = 0 };
            ShopSales.Models.ShoppingCart Cart = (ShoppingCart)Session["Cart"];
            if (Cart != null)
            {
                Cart.shoppingCarts.Clear();
                code = new { success = true, meg = "Delete cart is succesfully", coode = 1, Count = 0 };
            }
            return Json(code, JsonRequestBehavior.AllowGet);
        }


    }
}