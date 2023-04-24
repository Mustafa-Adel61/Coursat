namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sasasasa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Image_ID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Image_ID");
        }
    }
}
