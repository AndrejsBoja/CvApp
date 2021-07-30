namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Id", "dbo.Cvs");
            DropForeignKey("dbo.PersonInfoes", "Id", "dbo.Cvs");
            AddForeignKey("dbo.Addresses", "Id", "dbo.Cvs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonInfoes", "Id", "dbo.Cvs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonInfoes", "Id", "dbo.Cvs");
            DropForeignKey("dbo.Addresses", "Id", "dbo.Cvs");
            AddForeignKey("dbo.PersonInfoes", "Id", "dbo.Cvs", "Id");
            AddForeignKey("dbo.Addresses", "Id", "dbo.Cvs", "Id");
        }
    }
}
