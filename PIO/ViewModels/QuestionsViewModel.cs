using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIO.Models.Domain;

namespace PIO.ViewModels
{
	public class QuestionsViewModel
	{
		public Question Question { get; set; }
		public ICollection<Answer> PopularAnswers { get; set; }
	}
}