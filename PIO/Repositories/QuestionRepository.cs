using PIO.Models;
using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PIO.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Question> GetQuestionsSortedById(int page, int pageSize)
        {
            var numberOfRowsToSkip = (page - 1) * pageSize;

            var questions = _context.Questions
                .Include(q => q.Answers)
                .Include(q => q.Votes)
                .Include(q => q.AskedBy)
                .Include(q => q.Category);
            var query = (from q in questions
                         orderby q.Id descending
                         select q
                         ).Skip(numberOfRowsToSkip)
                         .Take(pageSize);
            return query.ToList();
        }

        public ICollection<Question> GetUnansweredQuestionsSortedByVoteCount(int page, int pageSize)
        {
            var numberOfRowsToSkip = (page - 1) * pageSize;

            var questions = _context.Questions
                .Include(q => q.Answers)
                .Include(q => q.Votes)
                .Include(q => q.AskedBy)
                .Include(q => q.Category);
            var query = (from q in questions
                         where q.Answers.Count == 0
                         orderby q.Votes.Count descending
                         select q
                         ).Skip(numberOfRowsToSkip)
                         .Take(pageSize);

            return query.ToList();
        }

        public ICollection<Question> GetUnansweredQuestionsSortedById(int page, int pageSize)
        {
            var numberOfRowsToSkip = (page - 1) * pageSize;

            var questions = _context.Questions
                .Include(q => q.Answers)
                .Include(q => q.Votes)
                .Include(q => q.AskedBy)
                .Include(q => q.Category); ;
            var query = (from q in questions
                         where q.Answers.Count == 0
                         orderby q.Id descending
                         select q
                         ).Skip(numberOfRowsToSkip)
                         .Take(pageSize);

            return query.ToList();
        }

        public ICollection<Question> GetQuestionsByCategorySortedById(int categoryId, int page, int pageSize)
        {
            var numberOfRowsToSkip = (page - 1) * pageSize;

            var questions = _context.Questions
                .Include(q => q.Answers)
                .Include(q => q.Votes)
                .Include(q => q.AskedBy)
                .Include(q => q.Category); ;
            var query = (from q in questions
                         where q.Category.Id == categoryId
                         orderby q.Id descending
                         select q
                         ).Skip(numberOfRowsToSkip)
                         .Take(pageSize);
            return query.ToList();
        }

        public ICollection<Question> GetQuestionsByUserSortedById(string userId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Question InsertQuestion(string title, string description, Category category, ApplicationUser user, DateTime dateCreated)
        {
            var question = new Question()
            {
                Title = title,
                Description = description,
                Category = category,
                AskedBy = user,
                DateCreated = dateCreated,
                DateLastModified = dateCreated
            };

            var insertedQuestion = _context.Questions.Add(question);
            _context.SaveChanges();
            return insertedQuestion;
        }
		public Question GetQuestion(int questionId)
		{
			var questions = _context.Questions
				.Include(q => q.Answers)
				.Include(q => q.Votes)
				.Include(q => q.AskedBy)
				.Include(q => q.Category); ;
			var query = (from q in questions
						 where q.Category.Id == questionId
						 select q
						 );

			return questions.SingleOrDefault(q => q.Id == questionId);
		}
	}
}