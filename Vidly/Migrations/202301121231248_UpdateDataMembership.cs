namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataMembership : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name = 'Pay as You Go' where Id=1 ");
            Sql("update MembershipTypes set Name = 'Monthly' where Id=2 ");
            Sql("update MembershipTypes set Name = 'Quarterly' where Id=3 ");
            Sql("update MembershipTypes set Name = 'Yearly' where Id=4 ");
        }
        
        public override void Down()
        {
        }
    }
}
