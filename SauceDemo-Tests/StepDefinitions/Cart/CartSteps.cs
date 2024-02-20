using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo_Tests.Utils.Helpers;
using SauceDemo_Tests.Utils.TestData;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SauceDemo_Tests.StepDefinitions.Cart
{
    [Binding]
    public class CartSteps
    {
        private readonly IWebDriver Webdriver;
        private readonly CartPage CartPage;
        private readonly List<ProductOrderList> ProductOrderList;
        private readonly SessionProductOrderList SessionProductOrderList;

        public CartSteps(IWebDriver webdriver, List<ProductOrderList> productOrderList)
        {
            Webdriver = webdriver;
            ProductOrderList = productOrderList;
            CartPage = new CartPage(Webdriver);
            SessionProductOrderList = new SessionProductOrderList(ProductOrderList);
        }

        [Then(@"The user views Your Cart page")]
        public void ThenTheUserViewsYourCartPage()
        {
            var Pagetitle = CartPage.GetPageTitle();
            Assert.That(Pagetitle, Is.EqualTo("Your Cart"), "Cart Page title is incorrect");
        }

        [When(@"The user clicks Remove button with (.*) product from Cart page")]
        public void WhenTheUserClicksRemoveButtonWithProductFromCartPage(string productName)
        {
            CartPage.RemoveProductFromCart(productName);
            SessionProductOrderList.RemoveProductToOrderList(productName);
        }

        [When(@"The user clicks Continue Shopping button from Cart page")]
        public void WhenTheUserClicksContinueShoppingButtonFromCartPage()
        {
            CartPage.NavigateToProdcuts();
        }


        [Then(@"The user views (.*) items in the cart")]
        public void ThenTheUserViewsItemsInTheCart(int productCount)
        {
            var CartProductCount = CartPage.GetCartProductCount();
            Assert.That(CartProductCount, Is.EqualTo(productCount), "Product count in the shopping cart is incorrect");
        }

        [Then(@"The user verifies zero items in the cart")]
        public void ThenTheUserVerifiesItemsInTheCart()
        {
            var IsCartBadgeDisplayed = CartPage.VerifyCartBadge();
            Assert.That(IsCartBadgeDisplayed, Is.EqualTo(false), "Product count in the shopping cart is incorrect");
        }


        [When(@"The user clicks on the cart icon")]
        public void WhenTheUserClicksOnTheCartIcon()
        {
            CartPage.NavigateToCart();
        }

        [When(@"The user clicks Checkout button from Your Cart page")]
        public void WhenTheUserClicksCheckoutButtonFromYourCartPage()
        {
            CartPage.NavigateToCheckout();
        }
    }
}
