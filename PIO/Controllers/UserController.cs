using PIO.Models.Domain;
using PIO.Services;
using PIO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIO.Controllers
{
    public class UserController : Controller
    {
        private QuestionService _questionService;

        public UserController()
        {
            _questionService = Container.QuestionService;
           
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)

        {
            var questions = _questionService.GetQuestionsByUser(id, 1, 10);

            var questionUserViewModel = new QuestionUserViewModel()
            {
                Questions = questions
            };

            return View(questionUserViewModel);
        }
    }
       
}