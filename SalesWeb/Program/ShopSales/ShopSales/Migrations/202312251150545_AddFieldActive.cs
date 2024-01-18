namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Post", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_News", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Order", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "isActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tb_News", "Description", c => c.String());
            AlterColumn("dbo.tb_News", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_News", "Detail", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_News", "Description", c => c.String(maxLength: 500));
            DropColumn("dbo.tb_Product", "isActive");
            DropColumn("dbo.tb_Order", "isActive");
            DropColumn("dbo.tb_News", "isActive");
            DropColumn("dbo.tb_Post", "isActive");
        }
    }
}
