namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSkillClassName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WorkExperienceSkills", newName: "Skills");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Skills", newName: "WorkExperienceSkills");
        }
    }
}
