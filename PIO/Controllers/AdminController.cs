using PIO.Models;
using PIO.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;

namespace PIO.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = Container.DbContext;
        }

        public ActionResult Index()
        {
            ViewBag.Categories = _context.Categories;
            return View();
        }

        public ActionResult AddCategory()
        {
            ViewBag.Categories = GetSelectableCategories();

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category, int ParentCategoryId)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Categories = GetSelectableCategories();
                return View(category);
            }

            if (ParentCategoryId > 0)
            {
                category.ParentCategory = _context.Categories.SingleOrDefault(c => c.Id == ParentCategoryId);
            }
            else
            {
                category.ParentCategory = null;
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int id)
        {
            ViewBag.Categories = GetSelectableCategories();

            var category = _context.Categories.Include(c => c.ParentCategory).SingleOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category, int ParentCategoryId)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Categories = GetSelectableCategories();
                return View(category);
            }
            var categoryInDb = _context.Categories.Include(c => c.ParentCategory).SingleOrDefault(c => c.Id == category.Id);
            if(ParentCategoryId > 0)
            {
                categoryInDb.ParentCategory = _context.Categories.SingleOrDefault(c => c.Id == ParentCategoryId);
            }
            else
            {
                categoryInDb.ParentCategory = null;
            }
            TryUpdateModel(categoryInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<Category> GetSelectableCategories()
        {
            var categories = new List<Category>();
            categories.Add(new Category()
            {
                Id = -1,
                Name = "Нема надкатегорија"
            });
            categories.AddRange(_context.Categories.ToList());

            return categories;
        }
    }
}