namespace CollegeSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Studants", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Studants", new[] { "SubjectId" });
            DropColumn("dbo.Studants", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Studants", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Studants", "SubjectId");
            AddForeignKey("dbo.Studants", "SubjectId", "dbo.Subjects", "SubjectId");
        }
    }
}
