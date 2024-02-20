using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SauceDemoTests.StepDefinitions.Login
{
    public partial class LoginPage
    {
        private readonly IWebDriver Webdriver;
        private readonly WebDriverWait WebDriverWait;

        public LoginPage(IWebDriver webdriver)
        {
            Webdriver = webdriver;
            WebDriverWait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(10));
        }

        IWebElement UserName => Webdriver.FindElement(By.Id("user-name"));
        IWebElement Password => Webdriver.FindElement(By.Id("password"));
        IWebElement LoginBtn => Webdriver.FindElement(By.Id("login-button"));
        IWebElement ErrorMessageText => Webdriver.FindElement(By.XPath("//h3[@data-test='error']"));
        IWebElement ErrorMessageClose => Webdriver.FindElement(By.XPath("//button[@class='error-button']"));

        public void Login(string ipUserName, string ipPassword)
        {
            try
            {
                if (!(ipUserName.Equals("Blank")))
                {
                    UserName.SendKeys(ipUserName);
                }

                if (!(ipPassword.Equals("Blank")))
                {
                    Password.SendKeys(ipPassword);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void ClickLoginBtn()
        {
            try
            {
                LoginBtn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void VerifyLoginElements()
        {
            Assert.That(UserName.Displayed, Is.EqualTo(true));
            Assert.That(Password.Displayed, Is.EqualTo(true));
        }

        public string GetErrorText()
        {
            try
            {
                var ErrorText = ErrorMessageText.Text;

                return ErrorText;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ClickErrorMessageCloseBtn()
        {
            try
            {
                WebDriverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@class='error-button']")));
                ErrorMessageClose.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Boolean GetErrorMessagePresense()
        {
            try
            {
                var IsErrorMessageDisplayed = ErrorMessageText.Displayed;

                return IsErrorMessageDisplayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
