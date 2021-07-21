namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCvPropertiesAndChangeVariableName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cvs", "Address_Id", c => c.Int());
            AddColumn("dbo.Cvs", "Education_Id", c => c.Int());
            AddColumn("dbo.Cvs", "Interest_Id", c => c.Int());
            AddColumn("dbo.Cvs", "PersonInfo_Id", c => c.Int());
            AddColumn("dbo.Cvs", "Skill_Id", c => c.Int());
            AddColumn("dbo.Cvs", "WorkExperience_Id", c => c.Int());
            CreateIndex("dbo.Cvs", "Address_Id");
            CreateIndex("dbo.Cvs", "Education_Id");
            CreateIndex("dbo.Cvs", "Interest_Id");
            CreateIndex("dbo.Cvs", "PersonInfo_Id");
            CreateIndex("dbo.Cvs", "Skill_Id");
            CreateIndex("dbo.Cvs", "WorkExperience_Id");
            AddForeignKey("dbo.Cvs", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Cvs", "Education_Id", "dbo.Educations", "Id");
            AddForeignKey("dbo.Cvs", "Interest_Id", "dbo.Interests", "Id");
            AddForeignKey("dbo.Cvs", "PersonInfo_Id", "dbo.PersonInfoes", "Id");
            AddForeignKey("dbo.Cvs", "Skill_Id", "dbo.Skill", "Id");
            AddForeignKey("dbo.Cvs", "WorkExperience_Id", "dbo.WorkExperiences", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cvs", "WorkExperience_Id", "dbo.WorkExperiences");
            DropForeignKey("dbo.Cvs", "Skill_Id", "dbo.Skill");
            DropForeignKey("dbo.Cvs", "PersonInfo_Id", "dbo.PersonInfoes");
            DropForeignKey("dbo.Cvs", "Interest_Id", "dbo.Interests");
            DropForeignKey("dbo.Cvs", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.Cvs", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Cvs", new[] { "WorkExperience_Id" });
            DropIndex("dbo.Cvs", new[] { "Skill_Id" });
            DropIndex("dbo.Cvs", new[] { "PersonInfo_Id" });
            DropIndex("dbo.Cvs", new[] { "Interest_Id" });
            DropIndex("dbo.Cvs", new[] { "Education_Id" });
            DropIndex("dbo.Cvs", new[] { "Address_Id" });
            DropColumn("dbo.Cvs", "WorkExperience_Id");
            DropColumn("dbo.Cvs", "Skill_Id");
            DropColumn("dbo.Cvs", "PersonInfo_Id");
            DropColumn("dbo.Cvs", "Interest_Id");
            DropColumn("dbo.Cvs", "Education_Id");
            DropColumn("dbo.Cvs", "Address_Id");
        }
    }
}
