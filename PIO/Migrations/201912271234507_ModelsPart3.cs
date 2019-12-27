namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsPart3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "Content", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Questions", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Questions", "Title", c => c.String());
            AlterColumn("dbo.Answers", "Content", c => c.String());
        }
    }
}
