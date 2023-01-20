namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editreleasedate : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Movies.RelaseDate', 'ReleaseDate', 'COLUMN' "); 

        
        }
        
        public override void Down()
        {
            Sql("sp_rename 'Movies.RelaseDate', 'ReleaseDate', 'COLUMN' ");
        }
    }
}
