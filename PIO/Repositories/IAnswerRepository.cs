using PIO.Models;
using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Repositories
{
    public interface IAnswerRepository
    {
        ICollection<Answer> GetAnswersByQuestionSortedByVoteCount(int questionId, int page, int pageSize);

        ICollection<Answer> GetAnswersByUserSortedById(string userId, int page, int pageSize);

		Answer InsertAnswer(string content,Question question, ApplicationUser user, DateTime dateCreated);

        Answer GetAnswer(int answerId);

        void SaveAnswer(Answer answer);

        void DeleteAnswer(Answer answer);

	}
}