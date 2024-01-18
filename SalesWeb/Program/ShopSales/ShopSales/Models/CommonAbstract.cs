using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSales.Models
{
    public abstract class CommonAbstract
    {
        public DateTime CreateDate { set; get; }
        [StringLength(255, ErrorMessage = "Maximun is 255 characters")]
        public string CreateBy { set; get; }
        public DateTime ModifiedDate { set; get; }
        [StringLength(255, ErrorMessage = "Maximun is 255 characters")]
        public string ModifierBy { set; get; }
    }
}