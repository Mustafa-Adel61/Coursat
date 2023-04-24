namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countryandgender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "country", c => c.String());
            AddColumn("dbo.AspNetUsers", "gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "gender");
            DropColumn("dbo.AspNetUsers", "country");
        }
    }
}
