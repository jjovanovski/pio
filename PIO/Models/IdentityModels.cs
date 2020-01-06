using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PIO.Models.Domain;

namespace PIO.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Question> QuestionVotes { get; set; }
        public ICollection<Answer> AnswerVotes { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // create many-to-many relationship representing votes on question between ApplicationUser and Question
            modelBuilder.Entity<Question>()
                .HasMany<ApplicationUser>(question => question.Votes)
                .WithMany(user => user.QuestionVotes)
                .Map(cs =>
                {
                    cs.MapLeftKey("QuestionId");
                    cs.MapRightKey("UserId");
                    cs.ToTable("QuestionVotes");
                });

            // create many-to-many relationship representing votes on answers between ApplicationUser and Answer
            modelBuilder.Entity<Answer>()
                .HasMany<ApplicationUser>(answer => answer.Votes)
                .WithMany(user => user.AnswerVotes)
                .Map(cs =>
                {
                    cs.MapLeftKey("AnswerId");
                    cs.MapRightKey("UserId");
                    cs.ToTable("AnswerVotes");
                });

            // create one-to-many relationship representing the subcategories of a certain category
            modelBuilder.Entity<Category>()
                .HasMany<Category>(category => category.Subcategories)
                .WithOptional(category => category.ParentCategory);
        }
    }
}