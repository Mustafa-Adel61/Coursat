namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sasa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "parent_Name", c => c.String());
            
        }

        public override void Down()
        {
            AddColumn("dbo.Categories", "parent_Name", c => c.Long(nullable: false));

        }
    }
}
