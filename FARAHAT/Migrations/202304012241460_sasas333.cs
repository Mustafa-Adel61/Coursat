namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sasas333 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "picture_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "picture_ID", c => c.String());
        }
    }
}
