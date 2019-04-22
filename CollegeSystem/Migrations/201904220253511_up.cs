namespace CollegeSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "TeacherName", c => c.String(nullable: false));
            DropColumn("dbo.Teachers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Teachers", "TeacherName");
        }
    }
}
