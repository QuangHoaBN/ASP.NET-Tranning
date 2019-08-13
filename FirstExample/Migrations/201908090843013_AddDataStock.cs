namespace FirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataStock : DbMigration
    {
        public override void Up()
        {
            Sql("update Movies set Stock=8 where Id=1");
            Sql("update Movies set Stock=45 where Id=2");
        }
        
        public override void Down()
        {
        }
    }
}
