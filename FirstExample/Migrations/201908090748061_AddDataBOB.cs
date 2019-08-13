namespace FirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataBOB : DbMigration
    {
        public override void Up()
        {
            Sql("update Customers set DOB='1998-11-18' where Id=1");
            Sql("update Customers set DOB='1998-08-25' where Id=2");
            Sql("update Customers set DOB='1997-08-10' where Id=3");
        }
        
        public override void Down()
        {
        }
    }
}
