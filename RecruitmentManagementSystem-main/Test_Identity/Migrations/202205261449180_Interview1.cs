namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Interview1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoundInterviewModels", newName: "InterviewModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.InterviewModels", newName: "RoundInterviewModels");
        }
    }
}
