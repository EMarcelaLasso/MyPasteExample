using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExample;
using MyExample2;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MyExample2.Tests
{
    [TestClass]
    public class ProfileTests
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new FirefoxDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
        }
        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }
        [TestMethod]
        public void RightEmail_First()
        {
            GmailMainPage searchEmailMainPage = new GmailMainPage(this.Driver);
            searchEmailMainPage.Navigate2();
            searchEmailMainPage.Search("t12251175@gmail.com", "Password1.");
            EmailPage gmailPage = new EmailPage(this.Driver);
            gmailPage.ValidateResultsCount("Google Account: test1");
        }
    }
}