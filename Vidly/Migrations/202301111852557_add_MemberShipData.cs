namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_MemberShipData : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes VALUES (1,0,0,0) ");
            Sql("insert into MembershipTypes VALUES (2,30,1,10) ");
            Sql("insert into MembershipTypes VALUES (3,90,3,15) ");
            Sql("insert into MembershipTypes VALUES (4,300,12,20) ");
        }
        
        public override void Down()
        {
        }
    }
}
