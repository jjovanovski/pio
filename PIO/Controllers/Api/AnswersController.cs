using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PIO.Controllers.Api
{
    public class AnswersController : ApiController
    {
        [HttpDelete]
        public IHttpActionResult DeleteAnswer(int id)
        {
            var answerService = Container.AnswerService;
            answerService.DeleteAnswer(id);
            return Ok();
        }
    }
}