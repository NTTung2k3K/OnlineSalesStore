namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFixB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "Title", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "Title", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
