using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_Order")]
    public class Order : CommonAbstract
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderId { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string Code { set; get; }
        [StringLength(255, ErrorMessage = "Maximun is 255 characters")]
        public string CustomerName { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string Phone { set; get; }
        public string Email { set; get; }
        public int Quantity { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Address { set; get; }
        public decimal TotalAmount { set; get; }
        public string Payment { set; get; }
        public string OrderState { set; get; }

        public ICollection<OrderDetail> OrderDetails { set; get; }
        public bool isActive { set; get; }

    }
}