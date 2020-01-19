﻿using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIO.Repositories
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategoryTree();

        Category GetCategory(int id);
	}
}