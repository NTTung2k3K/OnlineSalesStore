namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ProductCategory", "Image", c => c.String());
            DropColumn("dbo.tb_Category", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Category", "Image", c => c.String());
            DropColumn("dbo.tb_ProductCategory", "Image");
        }
    }
}
