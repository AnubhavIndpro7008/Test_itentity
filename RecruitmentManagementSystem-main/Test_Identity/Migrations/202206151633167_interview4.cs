namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interview4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InterviewModels", "CandidateName");
            DropColumn("dbo.InterviewModels", "InterviewerName");
            DropColumn("dbo.InterviewModels", "JobDiscription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterviewModels", "JobDiscription", c => c.String());
            AddColumn("dbo.InterviewModels", "InterviewerName", c => c.String());
            AddColumn("dbo.InterviewModels", "CandidateName", c => c.String());
        }
    }
}
