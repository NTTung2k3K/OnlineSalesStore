namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_ProductCategory", "Product_ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_Product", "ProductCategory_ProductCategoryId1", "dbo.tb_ProductCategory");
            DropForeignKey("dbo.tb_Product", "ProductCategory_ProductCategoryId", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_Product", new[] { "ProductCategory_ProductCategoryId" });
            DropIndex("dbo.tb_Product", new[] { "ProductCategory_ProductCategoryId1" });
            DropIndex("dbo.tb_ProductCategory", new[] { "Product_ProductId" });
            DropColumn("dbo.tb_Product", "ProductCategoryId");
            RenameColumn(table: "dbo.tb_Product", name: "ProductCategory_ProductCategoryId1", newName: "ProductCategoryId");
            // Commented out the line below
            // RenameColumn(table: "dbo.tb_Product", name: "ProductCategory_ProductCategoryId", newName: "ProductCategoryId");
            AlterColumn("dbo.tb_Product", "ProductCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Product", "ProductCategoryId");
            AddForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategory", "ProductCategoryId", cascadeDelete: true);
            DropColumn("dbo.tb_ProductCategory", "Product_ProductId");
        }


        public override void Down()
        {
            AddColumn("dbo.tb_ProductCategory", "Product_ProductId", c => c.Int());
            DropForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_Product", new[] { "ProductCategoryId" });
            AlterColumn("dbo.tb_Product", "ProductCategoryId", c => c.Int());
            AlterColumn("dbo.tb_Product", "ProductCategoryId", c => c.Int());
            RenameColumn(table: "dbo.tb_Product", name: "ProductCategoryId", newName: "ProductCategory_ProductCategoryId");
            RenameColumn(table: "dbo.tb_Product", name: "ProductCategoryId", newName: "ProductCategory_ProductCategoryId1");
            AddColumn("dbo.tb_Product", "ProductCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Product", "ProductCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_ProductCategory", "Product_ProductId");
            CreateIndex("dbo.tb_Product", "ProductCategory_ProductCategoryId1");
            CreateIndex("dbo.tb_Product", "ProductCategory_ProductCategoryId");
            AddForeignKey("dbo.tb_Product", "ProductCategory_ProductCategoryId", "dbo.tb_ProductCategory", "ProductCategoryId");
            AddForeignKey("dbo.tb_Product", "ProductCategory_ProductCategoryId1", "dbo.tb_ProductCategory", "ProductCategoryId");
            AddForeignKey("dbo.tb_ProductCategory", "Product_ProductId", "dbo.tb_Product", "ProductId");
        }
    }
}
