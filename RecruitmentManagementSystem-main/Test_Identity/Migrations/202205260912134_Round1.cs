namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Round1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundInterviewModels", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoundInterviewModels", "DateTime", c => c.String(nullable: false));
        }
    }
}
