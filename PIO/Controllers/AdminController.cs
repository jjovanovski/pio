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
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int id)
        {
            var category = _context.Categories.Include(c => c.ParentCategory).SingleOrDefault(c => c.Id == id);
            ViewBag.Categories = _context.Categories;
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories;
                return View(category);
            }
            var categoryInDb = _context.Categories.Include(c => c.ParentCategory).SingleOrDefault(c => c.Id == category.Id);
            TryUpdateModel(categoryInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}