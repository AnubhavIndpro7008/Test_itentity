namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class round2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InterviewRound2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Round = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        InterviewerId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        ModeOfInterview = c.String(),
                        Date_Time = c.DateTime(),
                        Comments = c.String(nullable: false),
                        Results = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CandModels", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.InterviewerModels", t => t.InterviewerId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.CandidateId)
                .Index(t => t.InterviewerId)
                .Index(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InterviewRound2", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.InterviewRound2", "InterviewerId", "dbo.InterviewerModels");
            DropForeignKey("dbo.InterviewRound2", "CandidateId", "dbo.CandModels");
            DropIndex("dbo.InterviewRound2", new[] { "JobId" });
            DropIndex("dbo.InterviewRound2", new[] { "InterviewerId" });
            DropIndex("dbo.InterviewRound2", new[] { "CandidateId" });
            DropTable("dbo.InterviewRound2");
        }
    }
}
