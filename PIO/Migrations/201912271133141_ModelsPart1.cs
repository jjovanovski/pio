namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsPart1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(nullable: false),
                        AnsweredBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AnsweredBy_Id)
                .Index(t => t.AnsweredBy_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(nullable: false),
                        AskedBy_Id = c.String(maxLength: 128),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AskedBy_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.AskedBy_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionVotes",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        QuestionId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.QuestionId })
                .ForeignKey("dbo.Questions", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionVotes", "QuestionId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuestionVotes", "UserId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Questions", "AskedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Answers", "AnsweredBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.QuestionVotes", new[] { "QuestionId" });
            DropIndex("dbo.QuestionVotes", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropIndex("dbo.Questions", new[] { "AskedBy_Id" });
            DropIndex("dbo.Answers", new[] { "AnsweredBy_Id" });
            DropTable("dbo.QuestionVotes");
            DropTable("dbo.Categories");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
