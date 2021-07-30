namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        PostCode = c.String(),
                        StreetNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Faculty = c.String(),
                        StudyProgram = c.String(),
                        EducationLevel = c.String(),
                        Period = c.Int(nullable: false),
                        EducationStatus = c.String(),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.CvId, cascadeDelete: true)
                .Index(t => t.CvId);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hobby = c.String(),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.CvId, cascadeDelete: true)
                .Index(t => t.CvId);
            
            CreateTable(
                "dbo.PersonInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        ProfileInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Achievement = c.String(),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.CvId, cascadeDelete: true)
                .Index(t => t.CvId);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        Schedule = c.String(),
                        WorkStart = c.String(),
                        WorkFinished = c.String(),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cvs", t => t.CvId, cascadeDelete: true)
                .Index(t => t.CvId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "CvId", "dbo.Cvs");
            DropForeignKey("dbo.Skills", "CvId", "dbo.Cvs");
            DropForeignKey("dbo.PersonInfoes", "Id", "dbo.Cvs");
            DropForeignKey("dbo.Interests", "CvId", "dbo.Cvs");
            DropForeignKey("dbo.Educations", "CvId", "dbo.Cvs");
            DropForeignKey("dbo.Addresses", "Id", "dbo.Cvs");
            DropIndex("dbo.WorkExperiences", new[] { "CvId" });
            DropIndex("dbo.Skills", new[] { "CvId" });
            DropIndex("dbo.PersonInfoes", new[] { "Id" });
            DropIndex("dbo.Interests", new[] { "CvId" });
            DropIndex("dbo.Educations", new[] { "CvId" });
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.Skills");
            DropTable("dbo.PersonInfoes");
            DropTable("dbo.Interests");
            DropTable("dbo.Educations");
            DropTable("dbo.Cvs");
            DropTable("dbo.Addresses");
        }
    }
}
