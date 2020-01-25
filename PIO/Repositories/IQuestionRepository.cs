using PIO.Models;
using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Repositories
{
    public interface IQuestionRepository
    {
        ICollection<Question> GetQuestionsSortedById(int page, int pageSize);

        ICollection<Question> GetUnansweredQuestionsSortedByVoteCount(int page, int pageSize);

        ICollection<Question> GetUnansweredQuestionsSortedById(int page, int pageSize);

        ICollection<Question> GetQuestionsByCategorySortedById(int categoryId, int page, int pageSize);

        ICollection<Question> GetQuestionsByUserSortedById(string userId, int page, int pageSize);

        Question InsertQuestion(string title, string description, Category category, ApplicationUser user, DateTime dateCreated);

        Question GetQuestion(int questionId);

		void SaveQuestion(Question question);
	}
}