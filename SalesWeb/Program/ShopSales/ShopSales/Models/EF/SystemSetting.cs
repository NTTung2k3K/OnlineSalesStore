using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopSales.Models.EF
{
    [Table("tb_SystemSetting")]
    public class SystemSetting
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SystemSettingId { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string SettingTitle { set; get; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string SettingLogo { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string SettingEmail{ set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string SettingHotline { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string SettingTitleSeo { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string SettingDesSeo { set; get; }
        [StringLength(50, ErrorMessage = "Maximun is 50 characters")]
        public string SettingKeySeo { set; get; }
        public string LinkFacebook { set; get; }
        public string LinkTwitter { set; get; }
        public string LinkInstagram { set; get; }
        public string LinkSkype { set; get; }
        public string LinkPinterest { set; get; }

    }
}