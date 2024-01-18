namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateisNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "isNew", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "isNew");
        }
    }
}
