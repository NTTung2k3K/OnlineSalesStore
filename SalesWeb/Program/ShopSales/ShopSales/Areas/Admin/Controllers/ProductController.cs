using PagedList;
using ShopSales.Models;
using ShopSales.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShopSales.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public ActionResult Index(string Search, int? page)
        {
            if (dbContext.Products.ToList() != null)
            {
                if (page == null)
                {
                    page = 1;
                }
                var size = 10;
                ViewBag.size = size;
                ViewBag.page = page;
                var PageQuantity = page.HasValue ? Convert.ToInt32(page) : 1;
                var data = dbContext.Products.OrderByDescending(x => x.ProductId);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = (IOrderedQueryable<Product>)data.Where(x => x.Alias.Contains(Search) || x.Title.Contains(Search));
                }

                return View(data.ToPagedList(PageQuantity, size));
            }
            else
            {
                return View(new { });
            }
        }

        public ActionResult Add()
        {
            var categories = dbContext.productCategories.ToList();
            var selectList = new SelectList(categories, "ProductCategoryId", "Title");
            ViewBag.listProductCategory = selectList;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product, List<string> Image, List<int> isDefault)
        {
            var categories = dbContext.productCategories.ToList();
            var selectList = new SelectList(categories, "ProductCategoryId", "Title");
            ViewBag.listProductCategory = selectList;
            if (ModelState.IsValid)
            {
                if (Image != null && Image.Count > 0)
                {
                    for (int i = 0; i < Image.Count; i++)
                    {
                        if (i + 1 == isDefault[0])
                        {
                            product.ProductImages.Add(new ProductImage { ProductId = product.ProductId, Product = product, Image = Image[i], isDefault = true });
                            product.Image = Image[i];
                        }
                        else
                        {
                            product.ProductImages.Add(new ProductImage { ProductId = product.ProductId, Product = product, Image = Image[i], isDefault = false });
                        }
                    }
                }
                else
                {
                    product.Image = "";
                }



                if (product.Alias == null)
                {
                    product.Alias = Models.Common.FillerAlias.FilterChar(product.Title);
                }

                if (product.DiscountStart != null && product.DiscountEnd == null)
                {
                    ModelState.AddModelError("Discount End is required", new Exception());
                    return View(product);
                }
                if (product.DiscountStart <= DateTime.Now &&  product.DiscountEnd>= DateTime.Now)
                {
                    product.isSale = true;
                }
               

                product.ProductCategory = dbContext.productCategories.Find(product.ProductCategoryId);
                product.CreateDate = DateTime.Now;
                product.ModifiedDate = DateTime.Now;
                product.Viewed = 0;
                product.Alias = ShopSales.Models.Common.FillerAlias.FilterChar(product.Title);
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                
                return View(product);
            }
        }
        public ActionResult Edit(int ProductId)
        {
            var categories = dbContext.productCategories.ToList();
            var selectList = new SelectList(categories, "ProductCategoryId", "Title");
            ViewBag.listProductCategory = selectList;
            var item = dbContext.Products.Include("ProductImages").SingleOrDefault(p => p.ProductId == ProductId);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, List<string> Image, List<int> isDefault)
        {
            if (ModelState.IsValid)
            {
                if (Image != null && Image.Count > 0)
                {

                    var existingImages = dbContext.productImages.Where(pi => pi.ProductId == product.ProductId);
                    dbContext.productImages.RemoveRange(existingImages);

                    for (int i = 0; i < Image.Count; i++)
                    {
                        var productImage = new ProductImage { ProductId = product.ProductId, Product = product, Image = Image[i], isDefault = i + 1 == isDefault[0] };
                        if (dbContext.productImages.Any(pi => pi.ProductId == productImage.ProductId))
                        {
                            dbContext.productImages.AddOrUpdate(productImage);
                        }
                        else
                        {
                            dbContext.productImages.Add(productImage);
                        }
                        if (i + 1 == isDefault[0])
                        {
                            product.Image = Image[i];
                        }
                    }

                }
                else
                {
                    product.Image = "";
                }

                if (product.DiscountStart != null && product.DiscountEnd == null)
                {
                    ModelState.AddModelError("Discount End is required", new Exception());
                    return View(product);
                }
                if (product.DiscountStart <= DateTime.Now && product.DiscountEnd >= DateTime.Now)
                {
                    product.isSale = true;
                }

                product.ProductCategory = dbContext.productCategories.Find(product.ProductCategoryId);
                product.ModifiedDate = DateTime.Now;


                //dbContext.Products.Attach(product);
                dbContext.Entry(product).State = EntityState.Modified;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                var categories = dbContext.productCategories.ToList();
                var selectList = new SelectList(categories, "ProductCategoryId", "Title");
                ViewBag.listProductCategory = selectList;
                var data = dbContext.Products.Include("ProductImages").SingleOrDefault(x => x.ProductId == product.ProductId);
                return View(data);
            }
        }
        [HttpPost]
        public JsonResult IsActive(int ProductId)
        {
            var item = dbContext.Products.Find(ProductId);

            item.isActive = !item.isActive;
            dbContext.SaveChanges();
            if (item.isActive)
            {
                return Json(new { success = false });
            }
            else
            {
                return Json(new { success = true });
            }
        }
        [HttpPost]
        public JsonResult Delete(int ProductId)
        {
            var item = dbContext.Products.Find(ProductId);
            if (item != null)
            {
                dbContext.Products.Remove(item);
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
                    var item = dbContext.Products.Find(Int32.Parse(i));
                    dbContext.Products.Remove(item);
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