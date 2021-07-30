namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateCreatedvariableAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cvs", "CreatedDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cvs", "CreatedDate");
        }
    }
}
