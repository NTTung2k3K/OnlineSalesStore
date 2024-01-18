using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.ProductImages = new HashSet<ProductImage>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductId { set; get; }
        [StringLength(500,ErrorMessage ="Maximun is 500 characters")]
        [Required(ErrorMessage = "Field is required")]
        public String ProductCode { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string Title { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Description { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Detail { set; get; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { set; get; }
        public DateTime? DiscountStart { set; get; }
        public DateTime? DiscountEnd { set; get; }
        public decimal? PriceSale { set; get; }
        public int Quantity { set; get; }
        public string Image { set; get; }
        public bool isHot { set; get; }
        public bool isNew { set; get; }
        public bool isFuture { set; get; }
        public bool isSale { set; get; }
        public bool isHome { set; get; }
        public bool isSold { set; get; }
        public bool isSell { set; get; }
        public long Viewed { set; get; }

        public int ProductCategoryId { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string Alias { set; get; }
        public string SeoTitle { set; get; }
        [StringLength(500, ErrorMessage = "Maximum is 500 characters")]
        public string SeoDescripiton { set; get; }
        [StringLength(255, ErrorMessage = "Maximum is 255 characters")]
        public string SeoKeyword { set; get; }

        public virtual ProductCategory ProductCategory { set; get; }
        public ICollection<OrderDetail> OrderDetails { set; get; }
        public ICollection<ProductImage> ProductImages { set; get; }
        public bool isActive { set; get; }

    }
}