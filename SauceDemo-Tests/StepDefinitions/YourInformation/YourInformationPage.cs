using OpenQA.Selenium;
using System;

namespace SauceDemo_Tests.StepDefinitions.YourInformation
{
    public class YourInformationPage
    {
        private readonly IWebDriver Webdriver;

        public YourInformationPage(IWebDriver webdriver)
        {
            Webdriver = webdriver;
        }

        IWebElement PageTitle => Webdriver.FindElement(By.XPath("//div[@class='header_secondary_container']/span"));
        IWebElement FirstName => Webdriver.FindElement(By.Id("first-name"));
        IWebElement LastName => Webdriver.FindElement(By.Id("last-name"));
        IWebElement PostalCode => Webdriver.FindElement(By.Id("postal-code"));
        IWebElement CancelBtn => Webdriver.FindElement(By.Id("cancel"));
        IWebElement ContinueBtn => Webdriver.FindElement(By.Id("continue"));

        public string GetPageTitle()
        {
            try
            {
                var PageTitleText = PageTitle.Text;
                return PageTitleText;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void EnterUserInformation(string firstName, string lastName, string postalCode)
        {
            try
            {
                FirstName.SendKeys(firstName);
                LastName.SendKeys(lastName);
                PostalCode.SendKeys(postalCode);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void NavigateToOverview()
        {
            try
            {
                ContinueBtn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
