using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSales.Models
{
    public class OrderViewModel
    {

        [Required(ErrorMessage = "Name is not empty")]
        public string name { set; get; }
        [Required(ErrorMessage = "PhoneNumber is not empty")]
        public string phoneNumber { set; get; }
        [Required(ErrorMessage = "Email is not empty")]
        public string email { set; get; }
        [Required(ErrorMessage = "Address is not empty")]
        public string address { set; get; }
        [Required(ErrorMessage = "Payment is not empty")]
        public string payment { set; get; }
    }
}