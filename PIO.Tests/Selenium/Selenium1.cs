using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace PIO.Tests.Selenium
{
    /// <summary>
    /// Summary description for Selenium1
    /// </summary>
    [TestClass]
    public class Selenium1
    {
        [TestMethod]
        public void TestLoginAndAuthorizedAccessToAskQuestion()
        {
            using(IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://pio20200126062413.azurewebsites.net/");
                driver.Manage().Window.Size = new System.Drawing.Size(1265, 752);
                driver.FindElement(By.LinkText("Постави прашање")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys("test");
                driver.FindElement(By.Id("Email")).SendKeys(Keys.Down);
                driver.FindElement(By.Id("Email")).SendKeys(Keys.Tab);
                driver.FindElement(By.Id("Password")).SendKeys("Test.123");
                driver.FindElement(By.CssSelector(".btn-default")).Click();
                driver.Close();
            }
        }

        [TestMethod]
        public void TestNewQuestionAppearsInLatestQuestionsScreen()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                driver.Navigate().GoToUrl("https://pio20200126062413.azurewebsites.net/");
                driver.Manage().Window.Size = new System.Drawing.Size(1265, 752);
                driver.FindElement(By.LinkText("Постави прашање")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys("test@test.com");
                driver.FindElement(By.Id("Email")).SendKeys(Keys.Down);
                driver.FindElement(By.Id("Email")).SendKeys(Keys.Tab);
                driver.FindElement(By.Id("Password")).SendKeys("Test.123");
                driver.FindElement(By.Id("Password")).SendKeys(Keys.Enter);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                driver.FindElement(By.Id("Question_Title")).Click();
                driver.FindElement(By.Id("Question_Title")).SendKeys("Prasanje broj 123456789");
                driver.FindElement(By.Id("Question_Description")).SendKeys("Opis na prasanjeto");
                driver.FindElement(By.Id("Question_Category_Id")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                {
                    var dropdown = driver.FindElement(By.Id("Question_Category_Id"));
                    dropdown.FindElement(By.XPath("//option[. = 'Каде можам да најдам']")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                }
                driver.FindElement(By.CssSelector("option:nth-child(8)")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.CssSelector(".btn-primary")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.LinkText("Види повеќе...")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                driver.FindElements(By.ClassName("question-list-item-title")).Any(e =>
                {
                    return e.Text == "Prasanje broj 123456789";
                });
                
                driver.Close();
            }
        }
    }
}
