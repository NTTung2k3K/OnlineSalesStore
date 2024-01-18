namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePriceSale : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "Image", c => c.String(maxLength: 500));
        }
    }
}
