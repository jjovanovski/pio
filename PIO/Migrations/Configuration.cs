namespace PIO.Migrations
{
    using PIO.Models;
    using PIO.Models.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PIO.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PIO.Models.ApplicationDbContext context)
        {
            SeedCategories(context);
            SeedQuestions(context);
            SeedAnswers(context);
        }

        private void SeedCategories(ApplicationDbContext context)
        {
            var categories = context.Categories;
            categories.AddOrUpdate(new Category() { Id = 1, Name = "Математика", ParentCategory = null });
            categories.AddOrUpdate(new Category() { Id = 2, Name = "Економија", ParentCategory = null });
            categories.AddOrUpdate(new Category() { Id = 3, Name = "Каде можам да најдам", ParentCategory = null });
            context.SaveChanges();

            var math = categories.First(c => c.Name == "Математика");
            categories.AddOrUpdate(new Category() { Id = 4, Name = "Геометрија", ParentCategory = math });
            categories.AddOrUpdate(new Category() { Id = 5, Name = "Алгебра", ParentCategory = math });

            var econ = categories.First(c => c.Name == "Економија");
            categories.AddOrUpdate(new Category() { Id = 6, Name = "Микроекономија", ParentCategory = econ });
            categories.AddOrUpdate(new Category() { Id = 7, Name = "Макроекономија", ParentCategory = econ });

            context.SaveChanges();
        }

        private void SeedQuestions(ApplicationDbContext context)
        {
            var kade = context.Categories.First(c => c.Name == "Каде можам да најдам");
            var geo = context.Categories.First(c => c.Name == "Геометрија");
            var alg = context.Categories.First(c => c.Name == "Алгебра");

            var usr = context.Users.First();

            var questions = context.Questions;
            questions.AddOrUpdate(new Question()
            {
                Id = 1,
                Title = "Каде можам да најдам шарени патики?",
                Description = "Каде, о, каде?",
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
                Category = kade,
                AskedBy = usr
            });

            questions.AddOrUpdate(new Question()
            {
                Id = 2,
                Title = "Коку е 2+5?",
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
                Category = alg,
                AskedBy = usr
            });

            questions.AddOrUpdate(new Question()
            {
                Id = 3,
                Title = "Колку е 80*90?",
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
                Category = alg,
                AskedBy = usr
            });

            questions.AddOrUpdate(new Question()
            {
                Id = 4,
                Title = "Како да пресметам волумен на додекахедрон?",
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
                Category = geo,
                AskedBy = usr
            });

            questions.AddOrUpdate(new Question()
            {
                Id = 5,
                Title = "Како да квадрирам круг?",
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
                Category = geo,
                AskedBy = usr
            });
        }

        private void SeedAnswers(ApplicationDbContext context)
        {

        }
    }
}
