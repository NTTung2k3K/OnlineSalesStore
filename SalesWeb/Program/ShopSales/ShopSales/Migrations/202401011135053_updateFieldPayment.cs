namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFieldPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "Payment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "Payment");
        }
    }
}
