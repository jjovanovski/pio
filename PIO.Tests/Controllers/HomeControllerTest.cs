using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIO;
using PIO.Controllers;
using PIO.Services;
using Moq;
using PIO.Repositories;

namespace PIO.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IQuestionRepository> _questionRepositoryMock;
        private Mock<IAnswerRepository> _answerRepositoryMock;
        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;

        public HomeControllerTest()
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
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
