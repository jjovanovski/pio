using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using PIO.Models;

namespace PIO.Controllers.Api
{
    public class VoteController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Question(int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                var questionService = Container.QuestionService;
                var votedByUser = questionService.ToggleVote(User.Identity.GetUserId(), id);
                var voteCount = questionService.GetQuestion(id).Votes.Count;

                var voteResult = new VoteResult()
                {
                    VotedByUser = votedByUser,
                    VoteCount = voteCount
                };

                return Ok(voteResult);
            }
            else
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        public IHttpActionResult Answer(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var answerService = Container.AnswerService;
                var votedByUser = answerService.ToggleVote(User.Identity.GetUserId(), id);
                var voteCount = answerService.GetAnswer(id).Votes.Count;

                var voteResult = new VoteResult()
                {
                    VotedByUser = votedByUser,
                    VoteCount = voteCount
                };

                return Ok(voteResult);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
