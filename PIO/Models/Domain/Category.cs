using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Models.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category ParentCategory { get; set; }
        public ICollection<Category> Subcategories { get; set; }
    }
}