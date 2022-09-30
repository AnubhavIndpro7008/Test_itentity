namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interview_round : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.InterviewModels", "CandidateId");
            CreateIndex("dbo.InterviewModels", "InterviewerId");
            CreateIndex("dbo.InterviewModels", "JobId");
            AddForeignKey("dbo.InterviewModels", "CandidateId", "dbo.CandModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InterviewModels", "InterviewerId", "dbo.InterviewerModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.InterviewModels", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            DropTable("dbo.InterviewVMs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InterviewVMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Round = c.Int(nullable: false),
                        CandidateName = c.String(),
                        InterviewerName = c.String(),
                        JobDiscription = c.String(),
                        ModeOfInterview = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.InterviewModels", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.InterviewModels", "InterviewerId", "dbo.InterviewerModels");
            DropForeignKey("dbo.InterviewModels", "CandidateId", "dbo.CandModels");
            DropIndex("dbo.InterviewModels", new[] { "JobId" });
            DropIndex("dbo.InterviewModels", new[] { "InterviewerId" });
            DropIndex("dbo.InterviewModels", new[] { "CandidateId" });
        }
    }
}
