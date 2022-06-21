namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InterviewModels", "ModeOfInterview");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterviewModels", "ModeOfInterview", c => c.String());
        }
    }
}
