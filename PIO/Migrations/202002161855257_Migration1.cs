namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "Category_Id1" });
            DropColumn("dbo.Questions", "Category_Id");
            RenameColumn(table: "dbo.Questions", name: "Category_Id1", newName: "Category_Id");
            AlterColumn("dbo.Questions", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "Category_Id");
            AddForeignKey("dbo.Questions", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            AlterColumn("dbo.Questions", "Category_Id", c => c.Int());
            RenameColumn(table: "dbo.Questions", name: "Category_Id", newName: "Category_Id1");
            AddColumn("dbo.Questions", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "Category_Id1");
            AddForeignKey("dbo.Questions", "Category_Id1", "dbo.Categories", "Id");
        }
    }
}
