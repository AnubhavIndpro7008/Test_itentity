namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inter : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InterviewerModels", "SelectedSkillName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterviewerModels", "SelectedSkillName", c => c.String());
        }
    }
}
