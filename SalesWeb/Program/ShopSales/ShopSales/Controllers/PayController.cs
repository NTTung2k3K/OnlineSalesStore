using ShopSales.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Controllers
{
    public class PayController : Controller
    {
        private ApplicationDbContext dBContext = new ApplicationDbContext();

        // GET: Pay
        public ActionResult Index()
        {
            ShopSales.Models.ShoppingCart Cart = (Models.ShoppingCart)Session["Cart"];
            if (Cart != null)
            {
                ViewBag.Cart = Cart.shoppingCarts;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(OrderViewModel order)
        {
            ShopSales.Models.ShoppingCart Cart = (Models.ShoppingCart)Session["Cart"];
            ViewBag.Cart = Cart.shoppingCarts;

            if (ModelState.IsValid)
            {
                ShopSales.Models.EF.Order ord = new Models.EF.Order();
                ord.CustomerName = order.name;
                ord.Address = order.address;
                ord.Phone = order.phoneNumber;
                ord.TotalAmount = Cart.shoppingCarts.Sum(x => x.TotalAmount);
                ord.CreateDate = DateTime.Now;
                ord.ModifiedDate = DateTime.Now;
                ord.ModifierBy = order.phoneNumber;
                ord.CreateBy = order.phoneNumber;

                Random rd = new Random();
                ord.Code = "OD" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                ord.Email = order.email;
                ord.Payment = order.payment;
                ord.OrderState = "Unpaid";
                Cart.shoppingCarts.ForEach(x => ord.OrderDetails.Add(new Models.EF.OrderDetail() {
                    ProductId = x.ProductId,
                    Price = x.Price,
                    Quantity = x.Quantity,
                }));
                dBContext.Ordes.Add(ord);
                dBContext.SaveChanges();
                //gui mai
                decimal total = 0;
                string strProduct = "";
                foreach (var i in Cart.shoppingCarts)
                {
                    strProduct += "<tr>";
                    strProduct += "<td>" + i.ProductName + "</td>";
                    strProduct += "<td>" + i.Quantity + "</td>";
                    strProduct += "<td>" + String.Format("{0:0,0} đ", i.TotalAmount).ToString() + "</td>";
                    strProduct += "</tr>";
                    total += i.TotalAmount;
                }
                string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/Form_Send_Mail/send2.html"));
                contentCustomer = contentCustomer.Replace("{{Code}}", ord.Code);
                contentCustomer = contentCustomer.Replace("{{CustomerName}}", ord.CustomerName);
                contentCustomer = contentCustomer.Replace("{{Date}}", ord.CreateDate.ToString("dd/MM/yyyy"));
                contentCustomer = contentCustomer.Replace("{{Product}}", strProduct);
                contentCustomer = contentCustomer.Replace("{{Total}}", String.Format("{0:0,0} đ", total).ToString());
                contentCustomer = contentCustomer.Replace("{{Payment}}", ord.Payment);
                contentCustomer = contentCustomer.Replace("{{Address}}", ord.Address);
                contentCustomer = contentCustomer.Replace("{{PhoneNumber}}", ord.Phone);
                contentCustomer = contentCustomer.Replace("{{Email}}", ord.Email);
                ShopSales.Models.Common.DoingMail.SendMail("ShopTK", "Order #" + ord.Code, contentCustomer, order.email);
                // mail for Admin
                string contentCustomerForAdmin = System.IO.File.ReadAllText(Server.MapPath("~/Content/Form_Send_Mail/send1.html"));
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{Code}}", ord.Code);
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{CustomerName}}", ord.CustomerName);
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{Date}}", ord.CreateDate.ToString("dd/MM/yyyy"));
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{Product}}", strProduct);
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{Total}}", String.Format("{0:0,0} đ", total).ToString());
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{Payment}}", ord.Payment);
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{Address}}", ord.Address);
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{PhoneNumber}}", ord.Phone);
                contentCustomerForAdmin = contentCustomerForAdmin.Replace("{{Email}}", ord.Email);
                ShopSales.Models.Common.DoingMail.SendMail("ShopTK", "Order #" + ord.Code, contentCustomerForAdmin, ConfigurationManager.AppSettings["Email"]);

                foreach (var i in Cart.shoppingCarts)
                {
                    var product = dBContext.Products.Find(i.ProductId);
                    product.Quantity -= i.Quantity;
                }
                Cart.Clear();


                dBContext.SaveChanges();
                return RedirectToAction("OrderSuccess");
            }
            else
            {
                ViewBag.OrderDetail = new { name = order.name, address = order.address, email = order.email, payment = order.payment, phoneNumber = order.phoneNumber };
                return View();
            }
        }
        public ActionResult OrderSuccess()
        {
            return View();
        }
    }
}