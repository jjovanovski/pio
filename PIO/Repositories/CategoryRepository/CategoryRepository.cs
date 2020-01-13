﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PIO.Models;
using PIO.Models.Domain;

namespace PIO.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository()
        {
            _context = new ApplicationDbContext();
        }

        public ICollection<Category> GetCategoryTree()
        {
            var categories = _context.Categories;
            var query = (from c in categories
                         select c);
            var list = query.ToList()
                .Where(c => c.ParentCategory == null).ToList();
            return list;
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.SingleOrDefault(c => c.Id == id);
        }
    }
}