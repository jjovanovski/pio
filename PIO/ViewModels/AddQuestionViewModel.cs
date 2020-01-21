using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.ViewModels
{
    public class AddQuestionViewModel
    {
        public Question Question { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}