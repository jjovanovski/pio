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
        private static ApplicationDbContext _dbContext;

        public static IQuestionRepository QuestionRepository { get; set; }
        public static IAnswerRepository AnswerRepository { get; set; }
        public static ICategoryRepository CategoryRepository { get; set; }
        public static IUserRepository UserRepository { get; set; }

        public static QuestionService QuestionService { get; set; }
        public static AnswerService AnswerService { get; set; }
        public static CategoryService CategoryService { get; set; }

        public static void Init()
        {
            _dbContext = new ApplicationDbContext();

            QuestionRepository = new QuestionRepository(_dbContext);
            AnswerRepository = new AnswerRepository(_dbContext);
            CategoryRepository = new CategoryRepository(_dbContext);
            UserRepository = new UserRepository(_dbContext);

            QuestionService = new QuestionService(QuestionRepository, CategoryRepository, UserRepository);
            AnswerService = new AnswerService(AnswerRepository, QuestionRepository, UserRepository);
            CategoryService = new CategoryService(CategoryRepository);
        }
    }
}