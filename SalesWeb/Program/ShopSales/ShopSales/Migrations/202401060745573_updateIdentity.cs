namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateIdentity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_SystemSetting");
            AlterColumn("dbo.tb_SystemSetting", "SettingTitle", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.tb_SystemSetting", "SettingTitle");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_SystemSetting");
            AlterColumn("dbo.tb_SystemSetting", "SettingTitle", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.tb_SystemSetting", "SettingTitle");
        }
    }
}
