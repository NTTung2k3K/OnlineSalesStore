using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_ProductCategory")]
    public class ProductCategory : CommonAbstract
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductCategoryId { set; get; }
        public string Title { set; get; }
        [StringLength(500, ErrorMessage = "Maximum is 500 characters")]
        public string Description { set; get; }
        [StringLength(500, ErrorMessage = "Maximum is 500 characters")]
        public string Icon { set; get; }
        [StringLength(500, ErrorMessage = "Maximum is 500 characters")]
        public string SeoTitle { set; get; }
        [StringLength(500, ErrorMessage = "Maximum is 500 characters")]
        public string SeoDescripiton { set; get; }
        [StringLength(255, ErrorMessage = "Maximum is 255 characters")]
        public string SeoKeyword { set; get; }
        public string Alias { set; get; }
        public ICollection<Product> Products { set; get; }
        public string Image { set; get; }


    }
}