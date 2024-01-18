namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFixBug : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
