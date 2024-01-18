namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_SystemSetting",
                c => new
                    {
                        SettingTitle = c.String(nullable: false, maxLength: 50),
                        SettingLogo = c.String(maxLength: 50),
                        SettingEmail = c.String(maxLength: 50),
                        SettingHotline = c.String(maxLength: 50),
                        SettingTitleSeo = c.String(maxLength: 50),
                        SettingDesSeo = c.String(maxLength: 50),
                        SettingKeySeo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SettingTitle);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_SystemSetting");
        }
    }
}
