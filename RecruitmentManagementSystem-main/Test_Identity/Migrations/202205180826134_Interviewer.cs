namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Interviewer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterviewerModels", "SelectedSkillName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InterviewerModels", "SelectedSkillName");
        }
    }
}
