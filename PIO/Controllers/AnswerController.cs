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
		private IQuestionRepository _questionRepository;
		private IUserRepository _userRepository;
		private IAnswerRepository _answerRepository;

		private AnswerService _answerService;

		public AnswerController()
		{
			_questionRepository = new QuestionRepository();
			_userRepository = new UserRepository();
			_answerRepository = new AnswerRepository();

			_answerService = new AnswerService(_answerRepository, _questionRepository, _userRepository);
		}
		

		public ActionResult Add()
        {
            return View();
        }


		[HttpPost]
		public ActionResult Add(Answer answer,int id)
		{
			int questionId = id;

			_answerService.AddAnswer(answer.Content, questionId, User.Identity.GetUserId(), DateTime.Now);
			return RedirectToAction("Index", "Question");
	
		}
	}
}