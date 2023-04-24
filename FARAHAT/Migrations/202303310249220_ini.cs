namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TrainerName", c => c.String());
            AddColumn("dbo.Courses", "CategoryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CategoryName");
            DropColumn("dbo.Courses", "TrainerName");
        }
    }
}
