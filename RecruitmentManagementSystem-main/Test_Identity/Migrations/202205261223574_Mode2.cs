namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mode2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoundInterviewModels", "Result", c => c.String());
            AddColumn("dbo.RoundInterviewModels", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoundInterviewModels", "Status");
            DropColumn("dbo.RoundInterviewModels", "Result");
        }
    }
}
