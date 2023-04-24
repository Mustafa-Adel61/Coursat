namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sasa3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "parent_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "parent_Name");
        }
    }
}
