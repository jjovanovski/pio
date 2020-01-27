namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryIdForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Questions", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Questions", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "CategoryId");
            AddForeignKey("dbo.Questions", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            AlterColumn("dbo.Questions", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Questions", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Questions", "Category_Id");
            AddForeignKey("dbo.Questions", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
