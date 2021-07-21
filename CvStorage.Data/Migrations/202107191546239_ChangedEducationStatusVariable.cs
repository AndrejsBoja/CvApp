namespace CvStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEducationStatusVariable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "EducationStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Educations", "EducationStatus");
        }
    }
}
