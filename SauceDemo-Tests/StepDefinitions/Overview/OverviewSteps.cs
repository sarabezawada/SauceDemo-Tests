using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo_Tests.Utils.Helpers;
using SauceDemo_Tests.Utils.TestData;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SauceDemo_Tests.StepDefinitions.Overview
{
    [Binding]
    public class OverviewSteps
    {
        private readonly IWebDriver WebDriver;
        private readonly List<ProductOrderList> ProductOrderList;
        private readonly SessionProductOrderList SessionProductOrderList;
        private readonly OverviewPage OverviewPage;
        private readonly Common Common;

        public OverviewSteps(IWebDriver webDriver, List<ProductOrderList> productOrderList)
        {
            WebDriver = webDriver;
            ProductOrderList = productOrderList;
            OverviewPage = new OverviewPage(WebDriver);
            Common = new Common(productOrderList);
            SessionProductOrderList = new SessionProductOrderList(ProductOrderList);
        }

        [Then(@"The user views Checkout Overivew page")]
        public void ThenTheUserViewsCheckoutOverivewPage()
        {
            var Pagetitle = OverviewPage.GetPageTitle();
            Assert.That(Pagetitle, Is.EqualTo("Checkout: Overview"), "Overview page title is not correct");
        }

        [Then(@"The user verifies products on the Checkout Overivew page")]
        public void ThenTheUserVerifiesProductsOnTheCheckoutOverivewPage()
        {
            var ActualProductList = OverviewPage.ReadProductsFromOverview();

            var IsListSame = Common.CompareOrderProductList(ActualProductList);
            Assert.That(IsListSame, Is.EqualTo(true));
        }

        [Then(@"The user verifies Payment Information on the Checkout Overivew page")]
        public void ThenTheUserVerifiesPaymentInformationOnTheCheckoutOverivewPage()
        {
            var PaymentInformation = OverviewPage.GetPaymentInformation();
            Assert.That(PaymentInformation.isDisplayed, Is.EqualTo(true));
            Assert.That(PaymentInformation.value, Is.EqualTo("SauceCard #31337"), "Payment information is incorrect");
        }

        [Then(@"The user verifies Shipping Information on the Checkout Overivew page")]
        public void ThenTheUserVerifiesShippingInformationOnTheCheckoutOverivewPage()
        {
            var ShippingInformation = OverviewPage.GetShippingInformation();
            Assert.That(ShippingInformation.isDisplayed, Is.EqualTo(true));
            Assert.That(ShippingInformation.value, Is.EqualTo("Free Pony Express Delivery!"), "Shipping information is incorrect");
        }

        [Then(@"The user verifies Price Total Information on the Checkout Overivew page")]
        public void ThenTheUserVerifiesPriceTotalInformationOnTheCheckoutOverivewPage()
        {
            var ActualPriceDetails = OverviewPage.GetPriceInformation();
            var ExpectedPriceDetailsst = SessionProductOrderList.GetSessionPriceDetails();
            Assert.That(ExpectedPriceDetailsst.itemTotal, Is.EqualTo(ActualPriceDetails.itemTotal), "Item total price is incorrect");
            Assert.That(ExpectedPriceDetailsst.tax, Is.EqualTo(ActualPriceDetails.tax), "Tax is incorrect");
            Assert.That(ExpectedPriceDetailsst.total, Is.EqualTo(ActualPriceDetails.total), "Total price is incorrect");
        }

        [When(@"The user clicks on Finish button")]
        public void WhenTheUserClicksOnFinishButton()
        {
            OverviewPage.NavigateToComplete();
        }
    }
}
