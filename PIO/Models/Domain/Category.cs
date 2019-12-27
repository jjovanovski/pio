using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIO.Models.Domain
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Category name must be between 2 and 255 characters long.")]
        public string Name { get; set; }

        public Category ParentCategory { get; set; }
        public ICollection<Category> Subcategories { get; set; }
    }
}