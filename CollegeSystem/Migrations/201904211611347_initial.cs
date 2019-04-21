namespace CollegeSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.StudantGrades",
                c => new
                    {
                        StudantGradeId = c.Int(nullable: false, identity: true),
                        Grade = c.Single(nullable: false),
                        StudantId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudantGradeId)
                .ForeignKey("dbo.Studants", t => t.StudantId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudantId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Studants",
                c => new
                    {
                        StudantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDay = c.String(nullable: false),
                        RegistrationNumber = c.Long(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudantId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDay = c.String(nullable: false),
                        Salary = c.Single(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudantGrades", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudantGrades", "StudantId", "dbo.Studants");
            DropForeignKey("dbo.Studants", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Studants", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "CourseId", "dbo.Courses");
            DropIndex("dbo.Subjects", new[] { "CourseId" });
            DropIndex("dbo.Teachers", new[] { "SubjectId" });
            DropIndex("dbo.Studants", new[] { "SubjectId" });
            DropIndex("dbo.Studants", new[] { "TeacherId" });
            DropIndex("dbo.StudantGrades", new[] { "SubjectId" });
            DropIndex("dbo.StudantGrades", new[] { "StudantId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Teachers");
            DropTable("dbo.Studants");
            DropTable("dbo.StudantGrades");
            DropTable("dbo.Courses");
        }
    }
}
