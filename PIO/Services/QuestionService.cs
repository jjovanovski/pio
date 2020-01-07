using PIO.Models.Domain;
using PIO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Services
{
    public class QuestionService
    {
        private IQuestionRepository _questionRepository;
        private ICategoryRepository _categoryRepository;
        private IUserRepository _userRepository;

        public QuestionService(IQuestionRepository questionRepository, 
            ICategoryRepository categoryRepository,
            IUserRepository userRepository)
        {
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public ICollection<Question> GetLatestQuestions(int page, int pageSize)
        {
            if(page <= 0)
            {
                throw new ArgumentException("Parameter 'page' must be a positive integer");
            }
            if(pageSize <= 0)
            {
                throw new ArgumentException("Parameter 'page' must be a positive integer");
            }

            return _questionRepository.GetQuestionsSortedById(page, pageSize);
        }

        public ICollection<Question> GetLatestUnansweredQuestions(int page, int pageSize)
        {
            if (page <= 0)
            {
                throw new ArgumentException("Parameter 'page' must be a positive integer");
            }
            if (pageSize <= 0)
            {
                throw new ArgumentException("Parameter 'page' must be a positive integer");
            }

            return _questionRepository.GetUnansweredQuestionsSortedById(page, pageSize);
        }

        public ICollection<Question> GetPopularUnansweredQuestion(int page, int pageSize)
        {
            if (page <= 0)
            {
                throw new ArgumentException("Parameter 'page' must be a positive integer");
            }
            if (pageSize <= 0)
            {
                throw new ArgumentException("Parameter 'page' must be a positive integer");
            }

            return _questionRepository.GetUnansweredQuestionsSortedByVoteCount(page, pageSize);
        }

        public Question AddQuestion(string title, string description, int categoryId, string userId, DateTime dateCreated)
        {
            var category = _categoryRepository.GetCategory(categoryId);
            if(category == null)
            {
                throw new ArgumentException("Category doesn't exist");
            }

            var user = _userRepository.GetUser(userId);
            if(user == null)
            {
                throw new ArgumentException("User doesn't exist");
            }

            return _questionRepository.InsertQuestion(title, description, category, user, dateCreated);
        }
    }
}