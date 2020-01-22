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
        private AnswerService _answerService;
        private UserService _userService;

        public UserController()
        {
            _questionService = Container.QuestionService;
            _answerService = Container.AnswerService;
            _userService = Container.UserService;
           
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)

        {
            var questions = _questionService.GetQuestionsByUser(id, 1, 10);
            var answers = _answerService.GetAnswersByUser(id, 1, 10);
            var user = _userService.GetUser(id);

            var questionUserViewModel = new QuestionUserViewModel()
            {
                Questions = questions,
                Answers = answers,
                User = user
            };

            return View(questionUserViewModel);
        }
    }
       
}