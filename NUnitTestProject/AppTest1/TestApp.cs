using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace NUnitTestProject.AppTest1
{
    [TestFixture]
    public class TestApp
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            //driver = new InternetExplorerDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheAppTest()
        {
            driver.Navigate().GoToUrl("http://localhost/WebApp/TestValidateWeb.aspx");
            driver.FindElement(By.Id("txtId")).Click();
            driver.FindElement(By.Id("txtId")).Clear();
            driver.FindElement(By.Id("txtId")).SendKeys("123");
            driver.FindElement(By.Id("txtName")).Click();
            driver.FindElement(By.Id("txtName")).Clear();
            driver.FindElement(By.Id("txtName")).SendKeys("123");
            driver.FindElement(By.Id("txtNickName")).Click();
            driver.FindElement(By.Id("txtNickName")).Clear();
            driver.FindElement(By.Id("txtNickName")).SendKeys("333");
            driver.FindElement(By.Id("txtMax")).Click();
            driver.FindElement(By.Id("txtMax")).Clear();
            driver.FindElement(By.Id("txtMax")).SendKeys("333");
            driver.FindElement(By.Id("txtItem")).Click();
            driver.FindElement(By.Id("txtItem")).Clear();
            driver.FindElement(By.Id("txtItem")).SendKeys("444");
            driver.FindElement(By.XPath("//table[@id='txtCreateItme_table']/tbody/tr[2]/td[4]/div")).Click();
            driver.FindElement(By.XPath("//div[@id='txtCreateItme_root']/div")).Click();
            driver.FindElement(By.Id("btnSave")).Click();
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
