using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Repositories.AnswerRepository
{
    public interface IAnswerRepository
    {
        ICollection<Answer> GetAnswersByQuestionSortedByVoteCount(int questionId, int page, int pageSize);

        ICollection<Answer> GetAnswersByUserSortedById(int userId, int page, int pageSize);
    }
}