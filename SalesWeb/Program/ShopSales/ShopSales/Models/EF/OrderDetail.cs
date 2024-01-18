using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        [StringLength(500, ErrorMessage = "Maximum is 500 characters")]
        public string Node { set; get; }
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public virtual Product Product { set; get; }
        public virtual Order Order { set; get; }
    }
}