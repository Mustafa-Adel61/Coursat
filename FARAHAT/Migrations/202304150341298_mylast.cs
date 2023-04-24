namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mylast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Image_ID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Image_ID");
        }
    }
}
