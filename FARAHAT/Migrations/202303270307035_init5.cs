namespace FARAHAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        parent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Creation_Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        category_ID = c.Int(nullable: false),
                        trainer_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.category_ID, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.trainer_ID, cascadeDelete: true)
                .Index(t => t.category_ID)
                .Index(t => t.trainer_ID);
            
            CreateTable(
                "dbo.CourseLessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        OrderNember = c.Int(),
                        course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.course_ID, cascadeDelete: true)
                .Index(t => t.course_ID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Description = c.String(),
                        Website = c.String(),
                        Creation_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicationUserCourses",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Course_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Course_ID);
            
            AddColumn("dbo.AspNetUsers", "Creation_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Is_Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "trainer_ID", "dbo.Trainers");
            DropForeignKey("dbo.CourseLessons", "course_ID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "category_ID", "dbo.Categories");
            DropForeignKey("dbo.ApplicationUserCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCourses", new[] { "Course_ID" });
            DropIndex("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CourseLessons", new[] { "course_ID" });
            DropIndex("dbo.Courses", new[] { "trainer_ID" });
            DropIndex("dbo.Courses", new[] { "category_ID" });
            DropColumn("dbo.AspNetUsers", "Is_Active");
            DropColumn("dbo.AspNetUsers", "Creation_Date");
            DropTable("dbo.ApplicationUserCourses");
            DropTable("dbo.Trainers");
            DropTable("dbo.CourseLessons");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
