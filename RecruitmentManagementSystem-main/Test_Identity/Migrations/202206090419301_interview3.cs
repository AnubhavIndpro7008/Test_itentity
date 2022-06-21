namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interview3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterviewModels", "CandidateName", c => c.String());
            AddColumn("dbo.InterviewModels", "InterviewerName", c => c.String());
            AddColumn("dbo.InterviewModels", "JobDiscription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InterviewModels", "JobDiscription");
            DropColumn("dbo.InterviewModels", "InterviewerName");
            DropColumn("dbo.InterviewModels", "CandidateName");
        }
    }
}
