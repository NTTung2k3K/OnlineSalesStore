namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatene : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_SystemSetting", "SettingLogo", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_SystemSetting", "SettingLogo", c => c.String(maxLength: 50));
        }
    }
}
