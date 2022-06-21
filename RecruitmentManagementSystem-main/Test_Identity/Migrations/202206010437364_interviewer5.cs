namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interviewer5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterviewerModels", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InterviewerModels", "Email");
        }
    }
}
