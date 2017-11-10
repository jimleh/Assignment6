namespace MVC_RelationalDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        TeacherEmail = c.String(),
                        TeacherPhone = c.String(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        StudentEmail = c.String(),
                        StudentPhone = c.String(),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.TeacherClasses",
                c => new
                    {
                        Teacher_TeacherID = c.Int(nullable: false),
                        Class_ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherID, t.Class_ClassID })
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherID, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_ClassID, cascadeDelete: true)
                .Index(t => t.Teacher_TeacherID)
                .Index(t => t.Class_ClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.TeacherClasses", "Class_ClassID", "dbo.Classes");
            DropForeignKey("dbo.TeacherClasses", "Teacher_TeacherID", "dbo.Teachers");
            DropIndex("dbo.TeacherClasses", new[] { "Class_ClassID" });
            DropIndex("dbo.TeacherClasses", new[] { "Teacher_TeacherID" });
            DropIndex("dbo.Students", new[] { "ClassID" });
            DropTable("dbo.TeacherClasses");
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.Classes");
        }
    }
}
