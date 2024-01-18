using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_Category")]
    public class Category : CommonAbstract
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CategoryId { set; get; }
        [Required(ErrorMessage = "Cannot empty")]
        [StringLength(50,ErrorMessage ="Maximun is 50 characters")]
        public string Title { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string Description { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string Alias { set; get; }
        public int Position { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string SeoTitle { set; get; }
        [StringLength(500, ErrorMessage = "Maximun is 500 characters")]
        public string SeoDescription { set; get; }
        [StringLength(255, ErrorMessage = "Maximun is 255 characters")]
        public string SeoKeyword { set; get; }
        public ICollection<Post> Posts { set; get; }

    }
}