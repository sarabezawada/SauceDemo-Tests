using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoTests.StepDefinitions.Login;
using System.Configuration;
using TechTalk.SpecFlow;

namespace SauceDemoTests.StepDefinitions
{
    [Binding]
    public partial class LoginSteps
    {
        private readonly IWebDriver Webdriver;
        private readonly LoginPage loginPage;

        public LoginSteps(IWebDriver webDriver)
        {
            Webdriver = webDriver;
            loginPage = new LoginPage(Webdriver);
        }

        [Given(@"The user is on the Login page")]
        public void GivenTheUserIsOnTheSauceDemoLoginPage()
        {
            var url = ConfigurationManager.AppSettings["appUrl"];
            Webdriver.Url = url;
        }

        [When(@"The user enters Username as (.*) and Password as (.*)")]
        public void WhenTheUserEntersUsernameAsTestAndPasswordAsTest(string ipUserName, string ipPassword)
        {
            loginPage.Login(ipUserName, ipPassword);
        }

        [Then(@"The user clicks on Login button")]
        public void ThenTheUserClicksOnLoginButton()
        {
            loginPage.ClickLoginBtn();
        }

        [Then(@"The user views Sauce Demo login page")]
        public void ThenTheUserViewsSauceDemoLoginPage()
        {
            loginPage.VerifyLoginElements();
        }

        [Then(@"The user views Error message (.*) on the Login page")]
        public void ThenTheUserViewsErrorMessageOnTheLoginPage(string errorMessageText)
        {
            var ErrorMessageText = loginPage.GetErrorText();
            Assert.That(ErrorMessageText, Is.EqualTo(errorMessageText), "Expected error message is not displayed");
        }

        [When(@"The user clicks on Close icon in the error message on the Login page")]
        public void WhenTheUserClicksOnCloseIconInTheErrorMessageOnTheLoginPage()
        {
            loginPage.ClickErrorMessageCloseBtn();
        }

        [Then(@"The user view Login page without any errors")]
        public void ThenTheUserViewLoginPageWithouyAnyErrors()
        {
            var IsErrorMessageDisplayed = loginPage.GetErrorMessagePresense();
            Assert.That(IsErrorMessageDisplayed, Is.EqualTo(false), "Error message should not be displayed");
        }


    }
}
