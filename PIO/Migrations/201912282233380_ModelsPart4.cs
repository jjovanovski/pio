namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsPart4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Question_Id", c => c.Int());
            CreateIndex("dbo.Answers", "Question_Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropColumn("dbo.Answers", "Question_Id");
        }
    }
}
