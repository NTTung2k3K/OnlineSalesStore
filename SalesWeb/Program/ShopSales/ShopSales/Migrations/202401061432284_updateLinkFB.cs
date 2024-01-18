namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLinkFB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_SystemSetting", "LinkFacebook", c => c.String());
            AddColumn("dbo.tb_SystemSetting", "LinkTwitter", c => c.String());
            AddColumn("dbo.tb_SystemSetting", "LinkInstagram", c => c.String());
            AddColumn("dbo.tb_SystemSetting", "LinkSkype", c => c.String());
            AddColumn("dbo.tb_SystemSetting", "LinkPinterest", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_SystemSetting", "LinkPinterest");
            DropColumn("dbo.tb_SystemSetting", "LinkSkype");
            DropColumn("dbo.tb_SystemSetting", "LinkInstagram");
            DropColumn("dbo.tb_SystemSetting", "LinkTwitter");
            DropColumn("dbo.tb_SystemSetting", "LinkFacebook");
        }
    }
}
