namespace PIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseSeeding1 : DbMigration
    {
        public override void Up()
        {
            SeedCategories();
            SeedQuestions();
            SeedAnswers();
        }
        
        public override void Down()
        {
        }

        private void SeedCategories()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('Математика')");
            Sql("INSERT INTO Categories (Name, ParentCategory_Id) VALUES ('Геометрија', '1')");
            Sql("INSERT INTO Categories (Name, ParentCategory_Id) VALUES ('Алгебра', '1')");
            Sql("INSERT INTO Categories (Name, ParentCategory_Id) VALUES ('Калкулус', '1')");

            Sql("INSERT INTO Categories (Name) VALUES ('Каде можам да најдам')");

            Sql("INSERT INTO Categories (Name) VALUES ('Економија')");
            Sql("INSERT INTO Categories (Name, ParentCategory_Id) VALUES ('Микроекономија', '6')");
            Sql("INSERT INTO Categories (Name, ParentCategory_Id) VALUES ('Макроекономија', '6')");
        }

        private void SeedQuestions()
        {
        }

        private void SeedAnswers()
        {

        }
    }
}
