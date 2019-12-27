using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Models.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public ApplicationUser AskedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
        public ICollection<ApplicationUser> Votes { get; set; }
    }
}