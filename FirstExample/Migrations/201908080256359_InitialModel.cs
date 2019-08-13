namespace FirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryOfProducts",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryOfProduct_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.CategoryOfProducts", t => t.CategoryOfProduct_CategoryId)
                .Index(t => t.CategoryOfProduct_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryOfProduct_CategoryId", "dbo.CategoryOfProducts");
            DropIndex("dbo.Products", new[] { "CategoryOfProduct_CategoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.CategoryOfProducts");
        }
    }
}
