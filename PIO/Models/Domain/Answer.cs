using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Models.Domain
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ApplicationUser AnsweredBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
        public ICollection<ApplicationUser> Votes { get; set; }
    }
}