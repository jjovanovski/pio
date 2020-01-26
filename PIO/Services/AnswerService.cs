using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIO.Models.Domain;
using PIO.Repositories;

namespace PIO.Services
{
	public class AnswerService
	{
		private IAnswerRepository _answerRepository;
		private IQuestionRepository _questionRepository;
		private IUserRepository _userRepository;
        
		public AnswerService(IAnswerRepository answerRepository, IQuestionRepository questionRepository, IUserRepository userRepository)
		{
			_answerRepository = answerRepository;
			_questionRepository = questionRepository;
			_userRepository = userRepository;
		}

		public ICollection<Answer> GetPopularAnswers(int questionId, int page, int pageSize)
		{
			var question = _questionRepository.GetQuestion(questionId);
			if (question == null)
			{
				throw new ArgumentException("Question doesn't exist");
			}
			return _answerRepository.GetAnswersByQuestionSortedByVoteCount(questionId, page, pageSize);
		}

        public ICollection<Answer> GetAnswersByUser(string userId, int page, int pageSize)
        {
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentException("User doesn't exist");
            }
            return _answerRepository.GetAnswersByUserSortedById(userId, page, pageSize);
        }

		public Answer AddAnswer(string content, int questionId, string userId, DateTime dateCreated)
		{
			var question = _questionRepository.GetQuestion(questionId);
			if (question == null)
			{
				throw new ArgumentException("Question doesn't exist");
			}

			var user = _userRepository.GetUser(userId);
			if (user == null)
			{
				throw new ArgumentException("User doesn't exist");
			}

			return _answerRepository.InsertAnswer(content, question, user, dateCreated);
		}

        public Answer GetAnswer(int answerId)
        {
            var answer = _answerRepository.GetAnswer(answerId);
            if(answer == null)
            {
                throw new ArgumentException("Answer doesn't exist");
            }

            return answer;
        }

        public void DeleteAnswer(int answerId)
        {
            var answer = _answerRepository.GetAnswer(answerId);
            _answerRepository.DeleteAnswer(answer);
        }

        public bool ToggleVote(string userId, int answerId)
        {
            var answer = _answerRepository.GetAnswer(answerId);
            var user = _userRepository.GetUser(userId);

            if (answer == null)
            {
                throw new ArgumentException("Answer doesn't exist");
            }

            if (user == null)
            {
                throw new ArgumentException("User doesn't exist");
            }

            if (answer.Votes.Contains(user))
            {
                answer.Votes.Remove(user);
                _answerRepository.SaveAnswer(answer);
                return false;
            }
            else
            {
                answer.Votes.Add(user);
                _answerRepository.SaveAnswer(answer);
                return true;
            }
        }
    }
}
