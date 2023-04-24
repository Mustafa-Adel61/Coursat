namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profileimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Image_ID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Image_ID");
        }
    }
}
