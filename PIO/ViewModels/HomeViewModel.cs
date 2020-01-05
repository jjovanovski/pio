using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Question> LatestQuestions { get; set; }
        public ICollection<Question> LatestUnansweredQuestions { get; set; }
    }
}