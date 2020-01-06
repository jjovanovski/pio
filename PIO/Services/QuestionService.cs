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

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
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
    }
}