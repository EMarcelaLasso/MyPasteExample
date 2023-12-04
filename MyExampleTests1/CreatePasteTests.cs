using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExample;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using static System.Net.WebRequestMethods;


namespace CreatePaste.Tests
{
    [TestClass]
    public class PasteTests
    {
        public FirefoxDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        [TestInitialize]
        public void SetupTest()
        {
            Driver = new FirefoxDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }
        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }
        [TestMethod]
        public void CreatePaste_First()
        {
            string pasteCode = "Hello from WebDriver";
            string pasteExp = "10 Minutes";
            string pasteName = "helloweb";
            Driver.Url = "https://pastebin.com/";
            PastePage createNewPaste = new PastePage(Driver);
            createNewPaste.CreateNewPaste(pasteCode, pasteExp, pasteName);
            createNewPaste.ValidatePaste("Your guest paste has been posted", pasteName);
        }
    }
}