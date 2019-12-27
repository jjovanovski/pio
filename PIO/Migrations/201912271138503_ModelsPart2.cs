namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsPart2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerVotes",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        AnswerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.AnswerId })
                .ForeignKey("dbo.Answers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AnswerId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AnswerId);
            
            AddColumn("dbo.Categories", "ParentCategory_Id", c => c.Int());
            CreateIndex("dbo.Categories", "ParentCategory_Id");
            AddForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropForeignKey("dbo.AnswerVotes", "AnswerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AnswerVotes", "UserId", "dbo.Answers");
            DropIndex("dbo.AnswerVotes", new[] { "AnswerId" });
            DropIndex("dbo.AnswerVotes", new[] { "UserId" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            DropColumn("dbo.Categories", "ParentCategory_Id");
            DropTable("dbo.AnswerVotes");
        }
    }
}
