using PIO.Models;
using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.ViewModels
{
    public class QuestionUserViewModel
    {
        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ApplicationUser User { get; set; }

    }

}