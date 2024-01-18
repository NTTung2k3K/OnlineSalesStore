using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{   
    [Table("tb_Advertisement")]
    public class Advertisement : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AdvertisementId { set; get; }
        [StringLength(50,ErrorMessage = "Maximun is 50 characters")]
        public string Title { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Description { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string Type { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Link { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Image { set; get; }
    }
}