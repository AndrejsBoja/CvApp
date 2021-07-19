namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPersonInfoModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonInfoes", "FirstName", c => c.String());
            DropColumn("dbo.PersonInfoes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonInfoes", "Name", c => c.String());
            DropColumn("dbo.PersonInfoes", "FirstName");
        }
    }
}
