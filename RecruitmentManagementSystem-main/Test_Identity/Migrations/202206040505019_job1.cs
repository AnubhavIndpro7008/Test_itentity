namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterviewModels", "JobId", c => c.Int(nullable: false));
            AlterColumn("dbo.InterviewModels", "CandidateId", c => c.Int(nullable: false));
            AlterColumn("dbo.InterviewModels", "InterviewerId", c => c.Int(nullable: false));
            DropColumn("dbo.InterviewModels", "To");
            DropColumn("dbo.InterviewModels", "From");
            DropColumn("dbo.InterviewModels", "Subject");
            DropColumn("dbo.InterviewModels", "Body");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterviewModels", "Body", c => c.String());
            AddColumn("dbo.InterviewModels", "Subject", c => c.String());
            AddColumn("dbo.InterviewModels", "From", c => c.String());
            AddColumn("dbo.InterviewModels", "To", c => c.String());
            AlterColumn("dbo.InterviewModels", "InterviewerId", c => c.String());
            AlterColumn("dbo.InterviewModels", "CandidateId", c => c.String());
            DropColumn("dbo.InterviewModels", "JobId");
        }
    }
}
