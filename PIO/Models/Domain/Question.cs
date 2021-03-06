﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIO.Models.Domain
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Question title must be between 8 and 255 characters long.")]
        [Display(Name = "Наслов")]
        public string Title { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Категорија")]
        public Category Category { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ApplicationUser AskedBy { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateLastModified { get; set; }

        public ICollection<ApplicationUser> Votes { get; set; }
    }
}