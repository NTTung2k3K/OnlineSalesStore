namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Advertisement",
                c => new
                    {
                        AdvertisementId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Type = c.String(maxLength: 50),
                        Link = c.String(maxLength: 500),
                        Image = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifierBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.AdvertisementId);
            
            CreateTable(
                "dbo.tb_Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Position = c.Int(nullable: false),
                        SeoTitle = c.String(maxLength: 50),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeyword = c.String(maxLength: 255),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifierBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.tb_Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Detail = c.String(maxLength: 500),
                        Image = c.String(maxLength: 500),
                        SeoTitle = c.String(maxLength: 50),
                        SeoDescripiton = c.String(maxLength: 500),
                        SeoKeyword = c.String(maxLength: 255),
                        CategoryId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifierBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.tb_Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tb_Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Message = c.String(maxLength: 500),
                        Website = c.String(maxLength: 500),
                        isRead = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifierBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.tb_News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Detail = c.String(maxLength: 500),
                        Image = c.String(maxLength: 500),
                        SeoTitle = c.String(maxLength: 50),
                        SeoDescripiton = c.String(maxLength: 500),
                        SeoKeyword = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.tb_OrderDetail",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Node = c.String(maxLength: 500),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.tb_Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tb_Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        CustomerName = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        Address = c.String(maxLength: 500),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifierBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.tb_Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Detail = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(maxLength: 500),
                        isHot = c.Boolean(nullable: false),
                        isFuture = c.Boolean(nullable: false),
                        isHome = c.Boolean(nullable: false),
                        isSold = c.Boolean(nullable: false),
                        isSell = c.Boolean(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifierBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.tb_ProductCategory",
                c => new
                    {
                        ProductCategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(maxLength: 500),
                        Icon = c.String(maxLength: 500),
                        SeoTitle = c.String(maxLength: 500),
                        SeoDescripiton = c.String(maxLength: 500),
                        SeoKeyword = c.String(maxLength: 255),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifierBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.tb_ProductImage",
                c => new
                    {
                        ProductImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Image = c.String(maxLength: 500),
                        isDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductImageId)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tb_Setting",
                c => new
                    {
                        SettingKey = c.String(nullable: false, maxLength: 500),
                        SettingValue = c.String(maxLength: 500),
                        SettingDescription = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.SettingKey);
            
            CreateTable(
                "dbo.tb_Subcrite",
                c => new
                    {
                        SubcribeId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubcribeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductCategoryProducts",
                c => new
                    {
                        ProductCategory_ProductCategoryId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductCategory_ProductCategoryId, t.Product_ProductId })
                .ForeignKey("dbo.tb_ProductCategory", t => t.ProductCategory_ProductCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.ProductCategory_ProductCategoryId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.ProductCategoryProducts", "Product_ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.ProductCategoryProducts", "ProductCategory_ProductCategoryId", "dbo.tb_ProductCategory");
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.ProductCategoryProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductCategoryProducts", new[] { "ProductCategory_ProductCategoryId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.tb_Post", new[] { "CategoryId" });
            DropTable("dbo.ProductCategoryProducts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.tb_Subcrite");
            DropTable("dbo.tb_Setting");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tb_ProductImage");
            DropTable("dbo.tb_ProductCategory");
            DropTable("dbo.tb_Product");
            DropTable("dbo.tb_Order");
            DropTable("dbo.tb_OrderDetail");
            DropTable("dbo.tb_News");
            DropTable("dbo.tb_Contact");
            DropTable("dbo.tb_Post");
            DropTable("dbo.tb_Category");
            DropTable("dbo.tb_Advertisement");
        }
    }
}
