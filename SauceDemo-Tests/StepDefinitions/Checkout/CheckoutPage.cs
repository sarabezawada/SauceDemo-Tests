using OpenQA.Selenium;
using System;

namespace SauceDemo_Tests.StepDefinitions.Checkout
{
    public class CheckoutPage
    {
        private readonly IWebDriver Webdriver;

        public CheckoutPage(IWebDriver webdriver)
        {
            Webdriver = webdriver;
        }

        IWebElement PageTitle => Webdriver.FindElement(By.XPath("//div[@class='header_secondary_container']/span"));
        IWebElement SuccessTickMark => Webdriver.FindElement(By.XPath("//*[@alt='Pony Express']"));
        IWebElement SuccessAccknowledgement => Webdriver.FindElement(By.XPath("//*[text()='Thank you for your order!']"));
        IWebElement SuccessMessage => Webdriver.FindElement(By.ClassName("complete-text"));
        IWebElement BackHomeBtn => Webdriver.FindElement(By.Id("back-to-products"));

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

        public (bool tickDisplayed, bool accknowledgementDisplayed, string successMessage) VerifySuccessDetails()
        {
            try
            {
                var TickDisplayed = SuccessTickMark.Displayed;
                var AccknowledgementDisplayed = SuccessAccknowledgement.Displayed;
                var SuccessMsg = SuccessMessage.Text;

                return (TickDisplayed, AccknowledgementDisplayed, SuccessMsg);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void NavigateToProducts() {
            try
            {
                BackHomeBtn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
