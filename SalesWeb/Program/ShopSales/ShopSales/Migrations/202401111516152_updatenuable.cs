namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenuable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "DiscountStart", c => c.DateTime());
            AlterColumn("dbo.tb_Product", "DiscountEnd", c => c.DateTime());
            AlterColumn("dbo.tb_Product", "PriceSale", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "PriceSale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.tb_Product", "DiscountEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_Product", "DiscountStart", c => c.DateTime(nullable: false));
        }
    }
}
