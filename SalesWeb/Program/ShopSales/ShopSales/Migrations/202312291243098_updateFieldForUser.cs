namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFieldForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "Image", c => c.String());
            AddColumn("dbo.tb_ProductCategory", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ProductCategory", "Alias");
            DropColumn("dbo.tb_Category", "Image");
        }
    }
}
