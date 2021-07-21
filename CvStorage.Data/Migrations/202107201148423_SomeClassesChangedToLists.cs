namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeClassesChangedToLists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cvs", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.Cvs", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.Cvs", "WorkExperience_Id", "dbo.WorkExperiences");
            DropIndex("dbo.Cvs", new[] { "Education_Id" });
            DropIndex("dbo.Cvs", new[] { "Skill_Id" });
            DropIndex("dbo.Cvs", new[] { "WorkExperience_Id" });
            AddColumn("dbo.Educations", "Cv_Id", c => c.Int());
            AddColumn("dbo.Skills", "Cv_Id", c => c.Int());
            AddColumn("dbo.WorkExperiences", "Cv_Id", c => c.Int());
            CreateIndex("dbo.Educations", "Cv_Id");
            CreateIndex("dbo.Skills", "Cv_Id");
            CreateIndex("dbo.WorkExperiences", "Cv_Id");
            AddForeignKey("dbo.Educations", "Cv_Id", "dbo.Cvs", "Id");
            AddForeignKey("dbo.Skills", "Cv_Id", "dbo.Cvs", "Id");
            AddForeignKey("dbo.WorkExperiences", "Cv_Id", "dbo.Cvs", "Id");
            DropColumn("dbo.Cvs", "Education_Id");
            DropColumn("dbo.Cvs", "Skill_Id");
            DropColumn("dbo.Cvs", "WorkExperience_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cvs", "WorkExperience_Id", c => c.Int());
            AddColumn("dbo.Cvs", "Skill_Id", c => c.Int());
            AddColumn("dbo.Cvs", "Education_Id", c => c.Int());
            DropForeignKey("dbo.WorkExperiences", "Cv_Id", "dbo.Cvs");
            DropForeignKey("dbo.Skills", "Cv_Id", "dbo.Cvs");
            DropForeignKey("dbo.Educations", "Cv_Id", "dbo.Cvs");
            DropIndex("dbo.WorkExperiences", new[] { "Cv_Id" });
            DropIndex("dbo.Skills", new[] { "Cv_Id" });
            DropIndex("dbo.Educations", new[] { "Cv_Id" });
            DropColumn("dbo.WorkExperiences", "Cv_Id");
            DropColumn("dbo.Skills", "Cv_Id");
            DropColumn("dbo.Educations", "Cv_Id");
            CreateIndex("dbo.Cvs", "WorkExperience_Id");
            CreateIndex("dbo.Cvs", "Skill_Id");
            CreateIndex("dbo.Cvs", "Education_Id");
            AddForeignKey("dbo.Cvs", "WorkExperience_Id", "dbo.WorkExperiences", "Id");
            AddForeignKey("dbo.Cvs", "Skill_Id", "dbo.Skills", "Id");
            AddForeignKey("dbo.Cvs", "Education_Id", "dbo.Educations", "Id");
        }
    }
}
