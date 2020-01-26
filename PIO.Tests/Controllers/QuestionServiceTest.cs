using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIO.Models;
using PIO.Models.Domain;
using PIO.Repositories;
using PIO.Services;

namespace PIO.Tests.Controllers
{
    [TestClass]
    public class QuestionServiceTest
    {
        private Mock<IQuestionRepository> _questionRepositoryMock;
        private Mock<IAnswerRepository> _answerRepositoryMock;
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;

        public QuestionServiceTest()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _answerRepositoryMock = new Mock<IAnswerRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();

            Container.QuestionService = new QuestionService(_questionRepositoryMock.Object, _categoryRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(-1, -1)]
        [DataTestMethod]
        public void GetLatestQuestionsThrowsArgumentException(int page, int pageSize)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Container.QuestionService.GetLatestQuestions(page, pageSize);
            });
        }

        [TestMethod]
        public void GetLatestQuestionsCallsRepository()
        {
            var list = new List<Question>();
            _questionRepositoryMock.Setup(q => q.GetQuestionsSortedById(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(list);

            var returnedList = Container.QuestionService.GetLatestQuestions(1, 1);
            Assert.AreSame(list, returnedList);
        }

        [TestMethod]
        public void AddQuestionThrowsArgumentExceptionWhenCategoryDoesntExist()
        {
            _categoryRepositoryMock.Setup(c => c.GetCategory(It.IsAny<int>()))
                .Returns<Category>(null);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Container.QuestionService.AddQuestion("", "", 1, "", DateTime.Now);
            }, message: "Category doesn't exist");
        }

        [TestMethod]
        public void AddQuestionThrowsArgumentExceptionWhenUserDoesntExist()
        {
            var categoryDummy = new Category();
            _categoryRepositoryMock.Setup(c => c.GetCategory(It.IsAny<int>()))
                .Returns(categoryDummy);

            _userRepositoryMock.Setup(u => u.GetUser(It.IsAny<string>()))
                .Returns<ApplicationUser>(null);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Container.QuestionService.AddQuestion("", "", 1, "", DateTime.Now);
            });
        }

        [TestMethod]
        public void AddQuestionCallsRepository()
        {
            var categoryDummy = new Category();
            var userDummy = new ApplicationUser();
            var questionDummy = new Question();

            _categoryRepositoryMock.Setup(c => c.GetCategory(It.IsAny<int>()))
                .Returns(categoryDummy);

            _userRepositoryMock.Setup(u => u.GetUser(It.IsAny<string>()))
                .Returns(userDummy);

            _questionRepositoryMock.Setup(q => q.InsertQuestion(It.IsAny<string>(), It.IsAny<string>(), categoryDummy, userDummy, It.IsAny<DateTime>()))
                .Returns(questionDummy);

           
            Assert.AreSame(questionDummy, Container.QuestionService.AddQuestion("", "", 1, "", DateTime.Now));
        }
        [TestMethod]
        public void GetQuestionThrowsArgumentExceptionWhenUserDoesntExist()
        {
            _questionRepositoryMock.Setup(q => q.GetQuestion(It.IsAny<int>()))
                .Returns<Question>(null);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Container.QuestionService.GetQuestion(1);
            });
        }
        [TestMethod]
        public void GetQuestionReturnsQuestion()
        {
            var questionDummy = new Question();
            _questionRepositoryMock.Setup(q => q.GetQuestion(It.IsAny<int>()))
               .Returns(questionDummy);

            var returnedQuestion= Container.QuestionService.GetQuestion(1);
            Assert.AreSame(questionDummy, returnedQuestion);
        }

        [TestMethod]
        public void ToggleVoteThrowsArgumentExceptionWhenQuestionDoesntExist()
        {
            _questionRepositoryMock.Setup(q => q.GetQuestion(It.IsAny<int>()))
                .Returns<Question>(null);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Container.QuestionService.ToggleVote("", 1);
            });
        }
        [TestMethod]
        public void ToggleVoteThrowsArgumentExceptionWhenUserDoesntExist()
        {
            var questionDummy = new Question();
            _questionRepositoryMock.Setup(q => q.GetQuestion(It.IsAny<int>()))
                .Returns(questionDummy);

            _userRepositoryMock.Setup(u => u.GetUser(It.IsAny<string>()))
                .Returns<ApplicationUser>(null);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Container.QuestionService.ToggleVote("", 1);
            });
        }
        [TestMethod]
        public void ToggleVoteReturnsFalseWhenQuestionVotesContainsUser()
        {
            var questionDummy = new Question(); 
            _questionRepositoryMock.Setup(q => q.GetQuestion(It.IsAny<int>()))
                .Returns(questionDummy);

            var userDummy = new ApplicationUser();
            _userRepositoryMock.Setup(u => u.GetUser(It.IsAny<string>()))
                .Returns(userDummy);
            questionDummy.Votes = new List<ApplicationUser>();
            questionDummy.Votes.Add(userDummy);
           
            Assert.IsFalse(Container.QuestionService.ToggleVote("",1));
            
        }
        [TestMethod]
        public void ToggleVoteReturnsTrueWhenQuestionVotesNotContainsUser()
        {
            var questionDummy = new Question();
            _questionRepositoryMock.Setup(q => q.GetQuestion(It.IsAny<int>()))
                .Returns(questionDummy);

            var userDummy = new ApplicationUser();
            _userRepositoryMock.Setup(u => u.GetUser(It.IsAny<string>()))
                .Returns(userDummy);
            questionDummy.Votes = new List<ApplicationUser>();

            Assert.IsTrue(Container.QuestionService.ToggleVote("", 1));

        }
        [TestMethod]
        public void ToggleVoteCallsSaveQuestion()
        {
            var questionDummy = new Question();
            _questionRepositoryMock.Setup(q => q.GetQuestion(It.IsAny<int>()))
                .Returns(questionDummy);

            var userDummy = new ApplicationUser();
            _userRepositoryMock.Setup(u => u.GetUser(It.IsAny<string>()))
                .Returns(userDummy);
            questionDummy.Votes = new List<ApplicationUser>();
           // questionDummy.Votes.Add(userDummy);

            Container.QuestionService.ToggleVote("", 1);
            _questionRepositoryMock.Verify(q => q.SaveQuestion(questionDummy), Times.Once);

        }

    }
}
