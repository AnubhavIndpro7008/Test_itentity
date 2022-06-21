namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interview5 : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InterviewVMs");
        }
    }
}
