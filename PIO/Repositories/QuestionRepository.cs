﻿using PIO.Models;
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

        public QuestionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public ICollection<Question> GetQuestionsSortedById(int page, int pageSize)
        {
            var numberOfRowsToSkip = (page - 1) * pageSize;

            var questions = _context.Questions;
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

            var questions = _context.Questions;
            var query = (from q in questions
                         where q.Votes.Count == 0
                         orderby q.Id descending
                         select q
                         ).Skip(numberOfRowsToSkip)
                         .Take(pageSize);

            return query.ToList();
        }

        public ICollection<Question> GetUnansweredQuestionsSortedById(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ICollection<Question> GetQuestionsByCategorySortedById(int categoryId, int page, int pageSize)
        {
            var numberOfRowsToSkip = (page - 1) * pageSize;

            var questions = _context.Questions;
            var query = (from q in questions
                         where q.Category.Id == categoryId
                         orderby q.Id descending
                         select q
                         ).Skip(numberOfRowsToSkip)
                         .Take(pageSize);
            return query.ToList();
        }

        public ICollection<Question> GetQuestionsByUserSortedById(int userId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}