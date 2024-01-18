using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_Contact")]
    public class Contact : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ContactId { set; get; }
        [StringLength(255, ErrorMessage = "Maximun is 255 characters")]
        public string Name { set; get; }
        [StringLength(255, ErrorMessage = "Maximun is 255 characters")]
        public string Email { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Message { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Website { set; get; }
        public bool isRead { set; get; }
    }
}