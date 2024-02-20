using OpenQA.Selenium;
using System;

namespace SauceDemo_Tests.StepDefinitions.Cart
{
    public class CartPage
    {
        private readonly IWebDriver Webdriver;

        public CartPage(IWebDriver webdriver)
        {
            Webdriver = webdriver;
        }

        IWebElement PageTitle => Webdriver.FindElement(By.XPath("//div[@class='header_secondary_container']/span"));
        IWebElement CartIcon => Webdriver.FindElement(By.ClassName("shopping_cart_link"));
        IWebElement CartProductCount => Webdriver.FindElement(By.ClassName("shopping_cart_badge"));
        IWebElement BackpackRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-backpack"));
        IWebElement BikeLightRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        IWebElement BoltTShirtRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt"));
        IWebElement FleeJacketRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-fleece-jacket"));
        IWebElement OnesieRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-onesie"));
        IWebElement RedTShirtRemoveBtn => Webdriver.FindElement(By.Id("remove-test.allthethings()-t-shirt-(red)"));
        IWebElement ProductRemoveBtn => Webdriver.FindElement(By.XPath("//*[@class='btn btn_secondary btn_small btn_inventory']"));
        IWebElement ContinueShoppingBtn => Webdriver.FindElement(By.Id("continue-shopping"));
        IWebElement CheckoutBtn => Webdriver.FindElement(By.Id("checkout"));

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

        public int GetCartProductCount()
        {
            try
            {
                var ProductCount = CartProductCount.Text;

                return int.Parse(ProductCount);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool VerifyCartBadge() {
            try
            {
                var IsDisplayed = CartProductCount.Displayed;

                return IsDisplayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void RemoveProductFromCart(string productName)
        {
            switch (productName)
            {
                case "Sauce Labs Backpack":
                    BackpackRemoveBtn.Click();
                    break;
                case "Sauce Labs Bike Light":
                    BikeLightRemoveBtn.Click();
                    break;
                case "Sauce Labs Bolt T-Shirt":
                    BoltTShirtRemoveBtn.Click();
                    break;
                case "Sauce Labs Fleece Jacket":
                    FleeJacketRemoveBtn.Click();
                    break;
                case "Sauce Labs Onesie":
                    OnesieRemoveBtn.Click();
                    break;
                case "Test.allTheThings() T-Shirt (Red)":
                    RedTShirtRemoveBtn.Click();
                    break;
                default:
                    throw new ArgumentException("Provide incorrect product name");
            }
        }

        public void NavigateToProdcuts()
        {
            try
            {
                ContinueShoppingBtn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void NavigateToCart() {
            try
            {
                CartIcon.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void NavigateToCheckout()
        {
            try
            {
                CheckoutBtn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
