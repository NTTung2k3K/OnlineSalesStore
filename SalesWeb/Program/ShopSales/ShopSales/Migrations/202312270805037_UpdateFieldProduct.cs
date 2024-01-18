namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFieldProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategoryProducts", "ProductCategory_ProductCategoryId", "dbo.tb_ProductCategory");
            DropForeignKey("dbo.ProductCategoryProducts", "Product_ProductId", "dbo.tb_Product");
            DropIndex("dbo.ProductCategoryProducts", new[] { "ProductCategory_ProductCategoryId" });
            DropIndex("dbo.ProductCategoryProducts", new[] { "Product_ProductId" });
            AddColumn("dbo.tb_Product", "ProductCategory_ProductCategoryId", c => c.Int());
            AddColumn("dbo.tb_Product", "ProductCategory_ProductCategoryId1", c => c.Int());
            AddColumn("dbo.tb_ProductCategory", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.tb_Product", "ProductCategory_ProductCategoryId");
            CreateIndex("dbo.tb_Product", "ProductCategory_ProductCategoryId1");
            CreateIndex("dbo.tb_ProductCategory", "Product_ProductId");
            AddForeignKey("dbo.tb_Product", "ProductCategory_ProductCategoryId", "dbo.tb_ProductCategory", "ProductCategoryId");
            AddForeignKey("dbo.tb_Product", "ProductCategory_ProductCategoryId1", "dbo.tb_ProductCategory", "ProductCategoryId");
            AddForeignKey("dbo.tb_ProductCategory", "Product_ProductId", "dbo.tb_Product", "ProductId");
            DropTable("dbo.ProductCategoryProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCategoryProducts",
                c => new
                    {
                        ProductCategory_ProductCategoryId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductCategory_ProductCategoryId, t.Product_ProductId });
            
            DropForeignKey("dbo.tb_ProductCategory", "Product_ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_Product", "ProductCategory_ProductCategoryId1", "dbo.tb_ProductCategory");
            DropForeignKey("dbo.tb_Product", "ProductCategory_ProductCategoryId", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_ProductCategory", new[] { "Product_ProductId" });
            DropIndex("dbo.tb_Product", new[] { "ProductCategory_ProductCategoryId1" });
            DropIndex("dbo.tb_Product", new[] { "ProductCategory_ProductCategoryId" });
            DropColumn("dbo.tb_ProductCategory", "Product_ProductId");
            DropColumn("dbo.tb_Product", "ProductCategory_ProductCategoryId1");
            DropColumn("dbo.tb_Product", "ProductCategory_ProductCategoryId");
            CreateIndex("dbo.ProductCategoryProducts", "Product_ProductId");
            CreateIndex("dbo.ProductCategoryProducts", "ProductCategory_ProductCategoryId");
            AddForeignKey("dbo.ProductCategoryProducts", "Product_ProductId", "dbo.tb_Product", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategoryProducts", "ProductCategory_ProductCategoryId", "dbo.tb_ProductCategory", "ProductCategoryId", cascadeDelete: true);
        }
    }
}
