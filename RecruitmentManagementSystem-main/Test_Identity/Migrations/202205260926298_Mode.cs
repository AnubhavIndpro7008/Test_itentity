namespace Test_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModeOfInterviewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModeOfInterviewModels");
        }
    }
}
