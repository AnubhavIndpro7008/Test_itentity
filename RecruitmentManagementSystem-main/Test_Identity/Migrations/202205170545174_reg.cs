namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InterviewerSkillIDModels", "InterviewerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InterviewerSkillIDModels", "InterviewerID", c => c.String());
        }
    }
}
