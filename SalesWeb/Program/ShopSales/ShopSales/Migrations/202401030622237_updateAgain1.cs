namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAgain1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "OrderState", c => c.String());
            DropColumn("dbo.tb_OrderDetail", "OrderState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_OrderDetail", "OrderState", c => c.Int(nullable: false));
            DropColumn("dbo.tb_Order", "OrderState");
        }
    }
}
