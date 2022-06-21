namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterviewModels", "To", c => c.String());
            AddColumn("dbo.InterviewModels", "From", c => c.String());
            AddColumn("dbo.InterviewModels", "Subject", c => c.String());
            AddColumn("dbo.InterviewModels", "Body", c => c.String());
            DropColumn("dbo.InterviewModels", "Comments");
            DropColumn("dbo.InterviewModels", "Result");
            DropColumn("dbo.InterviewModels", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterviewModels", "Status", c => c.String());
            AddColumn("dbo.InterviewModels", "Result", c => c.String());
            AddColumn("dbo.InterviewModels", "Comments", c => c.String());
            DropColumn("dbo.InterviewModels", "Body");
            DropColumn("dbo.InterviewModels", "Subject");
            DropColumn("dbo.InterviewModels", "From");
            DropColumn("dbo.InterviewModels", "To");
        }
    }
}
