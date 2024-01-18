namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCountView : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "Viewed", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "Viewed");
        }
    }
}
