namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateCreatedvariableChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cvs", "CreatedDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cvs", "CreatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cvs", "CreatedDate", c => c.String());
            DropColumn("dbo.Cvs", "CreatedDateTime");
        }
    }
}
