using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIO.Models.Domain;

namespace PIO.ViewModels
{
	public class QuestionsViewModel
	{
		public Question question { get; set; }
		public ICollection<Answer> PopularAnswers { get; set; }
	}
}