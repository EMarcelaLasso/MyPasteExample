using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace MyExample
{
    public class PastePage
    {
        private readonly FirefoxDriver driver;
        public PastePage(FirefoxDriver browser)
        {
            driver = browser;
        }
  
        private readonly By newPasteButton = By.XPath("//a[@class='header__btn']");
        private readonly By newPasteTitle = By.XPath("//div[@class='content__title -no-border']");
        private readonly By newCode = By.Id("postform-text");
        private readonly By pasteExpiration = By.XPath("//span[@id='select2-postform-expiration-container']");
        private readonly By pasteName = By.Id("postform-name");
        private readonly By createNewPaste = By.XPath("//button[contains(text(),'Create New Paste')]");
        private readonly By validationLabel = By.XPath("//div[@class='notice -success -post-view']");
        public void CreateNewPaste(string code, string exp, string name)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            if (driver.FindElement(newPasteButton).Displayed)
            {
                driver.FindElement(newPasteButton).Click();
                driver.FindElement(newCode).SendKeys(code);
                driver.FindElement(newPasteButton).SendKeys(Keys.PageDown);
                driver.FindElement(pasteExpiration).Click();
                string expiration = "//li[contains(text(),'" + exp + "')]";
                driver.FindElement(By.XPath(expiration)).Click();
                driver.FindElement(newPasteButton).SendKeys(Keys.PageDown);
                driver.FindElement(pasteName).SendKeys(name);
                driver.FindElement(newPasteButton).SendKeys(Keys.PageDown);
                driver.FindElement(createNewPaste).Click();
            }
        }

        public void ValidatePaste(string expectedText, string name)
        {
            Assert.IsTrue(driver.FindElement(validationLabel).Text.Contains(expectedText));
            string vname = "//h1[contains(text(),'" + name + "')]";
            Assert.IsTrue(driver.FindElement(By.XPath(vname)).Displayed);
        }
    }
}
