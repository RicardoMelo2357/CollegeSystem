namespace CollegeSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Studants", "StudantName", c => c.String(nullable: false));
            DropColumn("dbo.Studants", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Studants", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Studants", "StudantName");
        }
    }
}
