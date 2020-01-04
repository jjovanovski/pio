using PIO.App_Start;
using PIO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIO.Controllers
{
    public class HomeController : Controller
    {
        private IQuestionRepository _questionRepository;

        public HomeController()
        {
            _questionRepository = new QuestionRepository();
        }
        
        [PassCategoryTree]
        public ActionResult Index()
        {
            return View();
        }

        [PassCategoryTree]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [PassCategoryTree]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}