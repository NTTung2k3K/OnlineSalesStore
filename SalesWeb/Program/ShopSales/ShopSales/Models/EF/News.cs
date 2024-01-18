using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSales.Models.EF
{
    [Table("tb_News")]
    public class News : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NewsId { set; get; }
        [StringLength(50,ErrorMessage ="Maximum is 50 characters")]
        public string Title { set; get; }
        [StringLength(5000, ErrorMessage = "Maximum is 5000 characters")]
        public string Description { set; get; }
        [AllowHtml]
        public string Detail { set; get; }
        [StringLength(500, ErrorMessage = "Maximum is 500 characters")]
        public string Image { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string Alias { set; get; }
        [StringLength(50, ErrorMessage = "Maximum is 50 characters")]
        public string SeoTitle { set; get; }
        [StringLength(500, ErrorMessage = "Maximum is 500 characters")]
        public string SeoDescripiton { set; get; }
        [StringLength(255, ErrorMessage = "Maximum is 255 characters")]
        public string SeoKeyword { set; get; }
        public bool IsActive { set; get; }

    }
}