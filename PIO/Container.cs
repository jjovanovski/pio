using PIO.Models;
using PIO.Repositories;
using PIO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO
{
    public class Container
    {
        public static ApplicationDbContext DbContext;

        public static IQuestionRepository QuestionRepository { get; set; }
        public static IAnswerRepository AnswerRepository { get; set; }
        public static ICategoryRepository CategoryRepository { get; set; }
        public static IUserRepository UserRepository { get; set; }

        public static QuestionService QuestionService { get; set; }
        public static AnswerService AnswerService { get; set; }
        public static CategoryService CategoryService { get; set; }
        public static UserService UserService { get; set; }

        public static void Init()
        {
            DbContext = new ApplicationDbContext();

            QuestionRepository = new QuestionRepository(DbContext);
            AnswerRepository = new AnswerRepository(DbContext);
            CategoryRepository = new CategoryRepository(DbContext);
            UserRepository = new UserRepository(DbContext);

            QuestionService = new QuestionService(QuestionRepository, CategoryRepository, UserRepository);
            AnswerService = new AnswerService(AnswerRepository, QuestionRepository, UserRepository);
            CategoryService = new CategoryService(CategoryRepository);
            UserService = new UserService(UserRepository);
        }
    }
}