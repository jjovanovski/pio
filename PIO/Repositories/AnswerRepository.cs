using PIO.Models;
using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace PIO.Repositories
{
	public class AnswerRepository : IAnswerRepository
	{
		private ApplicationDbContext _context;

		public AnswerRepository(ApplicationDbContext context)
		{
            _context = context;
		}

		public ICollection<Answer> GetAnswersByQuestionSortedByVoteCount(int questionId, int page, int pageSize)
		{
			var numberOfRowsToSkip = (page - 1) * pageSize;

            var answers = _context.Answers
                .Include(a => a.Question)
                .Include(a => a.AnsweredBy)
                .Include(a => a.Votes);
			var query = (from a in answers
						 where a.Question.Id == questionId
						 orderby a.Votes.Count descending
						 select a
						 ).Skip(numberOfRowsToSkip)
						 .Take(pageSize);
			return query.ToList();

		}

		public ICollection<Answer> GetAnswersByUserSortedById(string userId, int page, int pageSize)
		{
			var numberOfRowsToSkip = (page - 1) * pageSize;

			var answers = _context.Answers
				.Include(a => a.Question)
				.Include(a => a.AnsweredBy)
				.Include(a => a.Votes);
			var query = (from a in answers
						 where a.AnsweredBy.Id == userId
						 orderby a.Votes.Count descending
						 select a
						 ).Skip(numberOfRowsToSkip)
						 .Take(pageSize);
			return query.ToList();
		}


        public Answer InsertAnswer(string content, Question question, ApplicationUser user, DateTime dateCreated)
		{
			var answer = new Answer()
			{
				Content = content,
				Question = question,
				AnsweredBy = user,
				DateCreated = dateCreated,
				DateLastModified = dateCreated
			};

			var insertedAnswer = _context.Answers.Add(answer);
			_context.SaveChanges();
			return insertedAnswer;
		}

        public Answer GetAnswer(int answerId)
        {
            var answers = _context.Answers
                .Include(a => a.Question)
                .Include(a => a.AnsweredBy)
                .Include(a => a.Votes);
            var query = (from a in answers
                         where a.Id == answerId
                         select a);

            return query.FirstOrDefault();
        }

        public void SaveAnswer(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}