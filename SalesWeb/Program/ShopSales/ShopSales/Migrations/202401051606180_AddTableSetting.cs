namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableSetting : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tb_Setting");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Setting",
                c => new
                    {
                        SettingKey = c.String(nullable: false, maxLength: 500),
                        SettingValue = c.String(maxLength: 500),
                        SettingDescription = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.SettingKey);
            
        }
    }
}
