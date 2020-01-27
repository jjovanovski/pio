namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryId1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Questions", name: "CategoryId", newName: "Category_Id1");
            AddColumn("dbo.Questions", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Category_Id1", c => c.Int());
            CreateIndex("dbo.Questions", "Category_Id1");
            AddForeignKey("dbo.Questions", "Category_Id1", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "Category_Id1" });
            AlterColumn("dbo.Questions", "Category_Id1", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Category_Id");
            RenameColumn(table: "dbo.Questions", name: "Category_Id1", newName: "CategoryId");
            CreateIndex("dbo.Questions", "CategoryId");
            AddForeignKey("dbo.Questions", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
