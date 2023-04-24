namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init64 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Email", c => c.String());
        }
    }
}
