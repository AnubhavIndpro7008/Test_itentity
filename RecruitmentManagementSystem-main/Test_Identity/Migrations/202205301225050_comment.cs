namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterviewModels", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InterviewModels", "Comments");
        }
    }
}
