using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SauceDemo_Tests.StepDefinitions.YourInformation
{
    [Binding]
    public class YourInformationSteps
    {
        private readonly IWebDriver WebDriver;
        private readonly YourInformationPage YourInformationPage;

        public YourInformationSteps(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            YourInformationPage = new YourInformationPage(WebDriver);
        }

        [Then(@"The user views Checkout Your Information page")]
        public void ThenTheUserViewsCheckoutYourInformationPage()
        {
            var Pagetitle = YourInformationPage.GetPageTitle();
            Assert.That(Pagetitle, Is.EqualTo("Checkout: Your Information"), "Your Information page title is incorrect");
        }

        [When(@"The user enters First Name as (.*), Last Name as (.*), Postal Code as (.*) on Checkout Your Information page")]
        public void WhenTheUserEntersOnCheckoutYourInformationPage(string firstName, string lastName, string postalCode)
        {
            YourInformationPage.EnterUserInformation(firstName, lastName, postalCode);
        }

        [When(@"The user clicks on Continue button on Your Cart page")]
        public void WhenTheUserClicksOnContinueButtonOnYourCartPage()
        {
            YourInformationPage.NavigateToOverview();
        }
    }
}
