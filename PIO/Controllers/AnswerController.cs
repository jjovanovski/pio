using PIO.Models.Domain;
using PIO.Repositories;
using PIO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PIO.Controllers
{
    public class AnswerController : Controller
    {
		private AnswerService _answerService;

		public AnswerController()
		{
			_answerService = Container.AnswerService;
		}
		
        [Authorize]
		public ActionResult Add()
        {
            return View();
        }
        
		[HttpPost]
        [Authorize]
        public ActionResult Add(Answer answer, int id)
		{
			if(!ModelState.IsValid)
            {
                return View("Add", answer);
            }

			_answerService.AddAnswer(answer.Content, id, User.Identity.GetUserId(), DateTime.Now);
			return RedirectToAction("Index", "Question", new { id = id });
	
		}
	}
}