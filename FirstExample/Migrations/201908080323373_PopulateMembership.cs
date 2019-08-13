namespace FirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembership : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes(Id, SignUpfee, DurationInMonth, DiscountRate) values (1,0,0,0)");
            Sql("insert into MembershipTypes(Id, SignUpfee, DurationInMonth, DiscountRate) values (2,30,1,10)");
            Sql("insert into MembershipTypes(Id, SignUpfee, DurationInMonth, DiscountRate) values (3,90,3,15)");
            Sql("insert into MembershipTypes(Id, SignUpfee, DurationInMonth, DiscountRate) values (4,300,12,20)");

        }

        public override void Down()
        {
        }
    }
}
