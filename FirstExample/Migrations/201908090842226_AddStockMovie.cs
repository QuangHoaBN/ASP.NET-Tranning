namespace FirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Stock");
        }
    }
}
