using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.ViewModels
{
	public class CategoryViewModel
	{
		public ICollection<Question> Questions { get; set; }
	}
}