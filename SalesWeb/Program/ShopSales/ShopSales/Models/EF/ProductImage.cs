using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_ProductImage")]
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductImageId { set; get; }
        public int ProductId { set; get; }
        [StringLength(500,ErrorMessage ="Maximum is 500 characters")]
        public string Image { set; get; }
        public bool isDefault { set; get; }
        public virtual Product Product { set; get; }
    }
}