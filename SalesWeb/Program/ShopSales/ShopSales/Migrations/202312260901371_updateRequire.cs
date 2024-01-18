namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRequire : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Post", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Post", "Detail", c => c.String(maxLength: 500));
        }
    }
}
