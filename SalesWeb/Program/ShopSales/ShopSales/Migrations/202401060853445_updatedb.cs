namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_SystemSetting");
            AddColumn("dbo.tb_SystemSetting", "SystemSettingId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.tb_SystemSetting", "SettingTitle", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.tb_SystemSetting", "SystemSettingId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_SystemSetting");
            AlterColumn("dbo.tb_SystemSetting", "SettingTitle", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.tb_SystemSetting", "SystemSettingId");
            AddPrimaryKey("dbo.tb_SystemSetting", "SettingTitle");
        }
    }
}
