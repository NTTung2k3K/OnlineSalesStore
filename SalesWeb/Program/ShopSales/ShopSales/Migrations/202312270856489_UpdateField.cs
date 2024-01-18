namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "isSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Product", "SeoDescripiton", c => c.String(maxLength: 500));
            AddColumn("dbo.tb_Product", "SeoKeyword", c => c.String(maxLength: 255));
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.tb_Product", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String(maxLength: 500));
            DropColumn("dbo.tb_Product", "SeoKeyword");
            DropColumn("dbo.tb_Product", "SeoDescripiton");
            DropColumn("dbo.tb_Product", "SeoTitle");
            DropColumn("dbo.tb_Product", "isSale");
        }
    }
}
