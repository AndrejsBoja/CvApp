namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CvIdAddedToEducationCore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educations", "Cv_Id", "dbo.Cvs");
            DropIndex("dbo.Educations", new[] { "Cv_Id" });
            RenameColumn(table: "dbo.Educations", name: "Cv_Id", newName: "CvId");
            AlterColumn("dbo.Educations", "CvId", c => c.Int(nullable: false));
            CreateIndex("dbo.Educations", "CvId");
            AddForeignKey("dbo.Educations", "CvId", "dbo.Cvs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "CvId", "dbo.Cvs");
            DropIndex("dbo.Educations", new[] { "CvId" });
            AlterColumn("dbo.Educations", "CvId", c => c.Int());
            RenameColumn(table: "dbo.Educations", name: "CvId", newName: "Cv_Id");
            CreateIndex("dbo.Educations", "Cv_Id");
            AddForeignKey("dbo.Educations", "Cv_Id", "dbo.Cvs", "Id");
        }
    }
}
