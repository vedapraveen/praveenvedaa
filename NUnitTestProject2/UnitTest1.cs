using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\CTAT\\WebDriver");
            baseURL = "https://www.google.com";
            verificationErrors = new StringBuilder();
        }

        [Test]
        public void test()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).Clear();
            driver.FindElement(By.Name("q")).SendKeys("gmail");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Web result with site links'])[1]/following::h3[1]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        [TearDown]
        public void closeBrowser()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


    }
}