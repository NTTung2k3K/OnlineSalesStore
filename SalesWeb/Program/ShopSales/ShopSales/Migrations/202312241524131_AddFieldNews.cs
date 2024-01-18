namespace ShopSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_News", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_News", "CreateBy", c => c.String(maxLength: 255));
            AddColumn("dbo.tb_News", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_News", "ModifierBy", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_News", "ModifierBy");
            DropColumn("dbo.tb_News", "ModifiedDate");
            DropColumn("dbo.tb_News", "CreateBy");
            DropColumn("dbo.tb_News", "CreateDate");
        }
    }
}
