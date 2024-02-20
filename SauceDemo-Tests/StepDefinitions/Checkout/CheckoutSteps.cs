using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemo_Tests.Utils.Helpers;
using SauceDemo_Tests.Utils.TestData;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SauceDemo_Tests.StepDefinitions.Checkout
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly IWebDriver Webdriver;
        private readonly CheckoutPage CheckoutPage;
        private readonly List<ProductOrderList> ProductOrderList;
        private readonly SessionProductOrderList SessionProductOrderList;
        private readonly WebDriverWait WebDriverWait;

        public CheckoutSteps(IWebDriver webdriver, List<ProductOrderList> productOrderList)
        {
            Webdriver = webdriver;
            ProductOrderList = productOrderList;
            CheckoutPage = new CheckoutPage(Webdriver);
            SessionProductOrderList = new SessionProductOrderList(ProductOrderList);
            WebDriverWait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(10));
        }

        [Then(@"The user view Checkout Complete page")]
        public void ThenTheUserViewCheckoutCompletePage()
        {
            var Pagetitle = CheckoutPage.GetPageTitle();
            Assert.That(Pagetitle, Is.EqualTo("Checkout: Complete!"), "Check Complete page title is incorrect");
        }

        [Then(@"The user verifies Succuess message")]
        public void ThenTheUserVerifiesSuccuessMessage()
        {
            var SuccessDetails = CheckoutPage.VerifySuccessDetails();
            Assert.That(SuccessDetails.tickDisplayed, Is.EqualTo(true), "Success tick mark is not displayed");
            Assert.That(SuccessDetails.accknowledgementDisplayed, Is.EqualTo(true), "Success accknowledgement is not displayed");
            Assert.That(SuccessDetails.successMessage, Is.EqualTo("Your order has been dispatched, and will arrive just as fast as the pony can get there!"), "Success message is not displayed");
        }

        [When(@"The user clicks on Back Home button on Checkout Complete page")]
        public void WhenTheUserClicksOnBackHomeButtonOnCheckoutCompletePage()
        {
            CheckoutPage.NavigateToProducts();
            SessionProductOrderList.FlushProductList();
            WebDriverWait.Until(ExpectedConditions.ElementExists(By.ClassName("product_sort_container")));
        }
    }
}
