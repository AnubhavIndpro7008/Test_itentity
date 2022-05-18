namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cand : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CandModels", "Date_Time", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CandModels", "Date_Time", c => c.DateTime());
        }
    }
}
