using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIO.Models.Domain;

namespace PIO.Repositories.AnswerRepository
{
    public class AnswerRepository : IAnswerRepository
    {
        public ICollection<Answer> GetAnswersByQuestionSortedByVoteCount(int questionId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ICollection<Answer> GetAnswersByUserSortedById(int userId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}