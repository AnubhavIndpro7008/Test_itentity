namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Round : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoundInterviewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Round = c.String(),
                        CandidateId = c.String(),
                        InterviewerId = c.String(),
                        ModeOfInterview = c.String(),
                        DateTime = c.String(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoundInterviewModels");
        }
    }
}
