using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIO.Models.Domain
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Answer content must be between 8 and 255 characters long.")]
        public string Content { get; set; }

        public Question Question { get; set; }

        public ApplicationUser AnsweredBy { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateLastModified { get; set; }

        public ICollection<ApplicationUser> Votes { get; set; }
    }
}