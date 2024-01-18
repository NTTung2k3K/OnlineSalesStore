using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_Subcrite")]
    public class Subcribe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubcribeId { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Email { set; get; }
        public DateTime CreateDate { set; get; }
    }
}