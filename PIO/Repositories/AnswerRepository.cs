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

		public AnswerRepository()
		{
			_context = new ApplicationDbContext();
		}

		public ICollection<Answer> GetAnswersByQuestionSortedByVoteCount(int questionId, int page, int pageSize)
		{
			var numberOfRowsToSkip = (page - 1) * pageSize;

			var answers = _context.Answers
				.Include(a => a.Question)
				.Include(a => a.AnsweredBy)
				.Include(a => a.Votes); ;
			var query = (from a in answers
						 where a.Question.Id == questionId
						 orderby a.Votes.Count descending
						 select a
						 ).Skip(numberOfRowsToSkip)
						 .Take(pageSize);
			return query.ToList();

		}

		public ICollection<Answer> GetAnswersByUserSortedById(int userId, int page, int pageSize)
		{
			throw new NotImplementedException();
		}
	}
}