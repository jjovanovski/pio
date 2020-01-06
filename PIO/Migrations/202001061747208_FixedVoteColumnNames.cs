namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedVoteColumnNames : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.QuestionVotes", new[] { "UserId" });
            DropIndex("dbo.QuestionVotes", new[] { "QuestionId" });
            DropIndex("dbo.AnswerVotes", new[] { "UserId" });
            DropIndex("dbo.AnswerVotes", new[] { "AnswerId" });
            RenameColumn(table: "dbo.AnswerVotes", name: "UserId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AnswerVotes", name: "AnswerId", newName: "UserId");
            RenameColumn(table: "dbo.QuestionVotes", name: "UserId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.QuestionVotes", name: "QuestionId", newName: "UserId");
            RenameColumn(table: "dbo.AnswerVotes", name: "__mig_tmp__0", newName: "AnswerId");
            RenameColumn(table: "dbo.QuestionVotes", name: "__mig_tmp__1", newName: "QuestionId");
            DropPrimaryKey("dbo.AnswerVotes");
            DropPrimaryKey("dbo.QuestionVotes");
            AlterColumn("dbo.AnswerVotes", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AnswerVotes", "AnswerId", c => c.Int(nullable: false));
            AlterColumn("dbo.QuestionVotes", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.QuestionVotes", "QuestionId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AnswerVotes", new[] { "AnswerId", "UserId" });
            AddPrimaryKey("dbo.QuestionVotes", new[] { "QuestionId", "UserId" });
            CreateIndex("dbo.QuestionVotes", "QuestionId");
            CreateIndex("dbo.QuestionVotes", "UserId");
            CreateIndex("dbo.AnswerVotes", "AnswerId");
            CreateIndex("dbo.AnswerVotes", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AnswerVotes", new[] { "UserId" });
            DropIndex("dbo.AnswerVotes", new[] { "AnswerId" });
            DropIndex("dbo.QuestionVotes", new[] { "UserId" });
            DropIndex("dbo.QuestionVotes", new[] { "QuestionId" });
            DropPrimaryKey("dbo.QuestionVotes");
            DropPrimaryKey("dbo.AnswerVotes");
            AlterColumn("dbo.QuestionVotes", "QuestionId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.QuestionVotes", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AnswerVotes", "AnswerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AnswerVotes", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.QuestionVotes", new[] { "UserId", "QuestionId" });
            AddPrimaryKey("dbo.AnswerVotes", new[] { "UserId", "AnswerId" });
            RenameColumn(table: "dbo.QuestionVotes", name: "QuestionId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.AnswerVotes", name: "AnswerId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.QuestionVotes", name: "UserId", newName: "QuestionId");
            RenameColumn(table: "dbo.QuestionVotes", name: "__mig_tmp__1", newName: "UserId");
            RenameColumn(table: "dbo.AnswerVotes", name: "UserId", newName: "AnswerId");
            RenameColumn(table: "dbo.AnswerVotes", name: "__mig_tmp__0", newName: "UserId");
            CreateIndex("dbo.AnswerVotes", "AnswerId");
            CreateIndex("dbo.AnswerVotes", "UserId");
            CreateIndex("dbo.QuestionVotes", "QuestionId");
            CreateIndex("dbo.QuestionVotes", "UserId");
        }
    }
}
