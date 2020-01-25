using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.ViewModels
{
	public class QuestionListsViewModel
	{
		public ICollection<Question> AllLatestQuestions { get; set; }
		public ICollection<Question> AllLatestUnansweredQuestions { get; set; }
		public ICollection<Question> AllPopularUnansweredQuestions { get; set; }
	}
}