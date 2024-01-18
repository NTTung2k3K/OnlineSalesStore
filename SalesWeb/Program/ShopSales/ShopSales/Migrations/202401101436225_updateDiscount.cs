namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "DiscountStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Product", "DiscountEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "DiscountEnd");
            DropColumn("dbo.tb_Product", "DiscountStart");
        }
    }
}
