namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAddedList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cvs", "Interest_Id", "dbo.Interests");
            DropIndex("dbo.Cvs", new[] { "Interest_Id" });
            AddColumn("dbo.Interests", "Cv_Id", c => c.Int());
            CreateIndex("dbo.Interests", "Cv_Id");
            AddForeignKey("dbo.Interests", "Cv_Id", "dbo.Cvs", "Id");
            DropColumn("dbo.Cvs", "Interest_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cvs", "Interest_Id", c => c.Int());
            DropForeignKey("dbo.Interests", "Cv_Id", "dbo.Cvs");
            DropIndex("dbo.Interests", new[] { "Cv_Id" });
            DropColumn("dbo.Interests", "Cv_Id");
            CreateIndex("dbo.Cvs", "Interest_Id");
            AddForeignKey("dbo.Cvs", "Interest_Id", "dbo.Interests", "Id");
        }
    }
}
