namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFieldOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_OrderDetail", "OrderState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_OrderDetail", "OrderState");
        }
    }
}
