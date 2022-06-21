namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cand2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CandModels", "Date_Time", c => c.DateTime());
            AlterColumn("dbo.InterviewModels", "Round", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InterviewModels", "Round", c => c.String());
            AlterColumn("dbo.CandModels", "Date_Time", c => c.DateTime(nullable: false));
        }
    }
}
