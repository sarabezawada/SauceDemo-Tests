using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemo_Tests.Utils.Helpers;
using SauceDemo_Tests.Utils.TestData;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SauceDemoTests.StepDefinitions.Products
{
    [Binding]
    public class ProductsSteps
    {
        private readonly IWebDriver WebDriver;
        private readonly List<ProductOrderList> ProductOrderList;
        private readonly ProductsPage ProductsPage;
        private readonly SessionProductOrderList SessionProductOrderList;     
        private readonly Common Common;

        public ProductsSteps(IWebDriver webDriver, List<ProductOrderList> productOrderList)
        {
            WebDriver = webDriver;
            ProductOrderList = productOrderList;
            ProductsPage = new ProductsPage(WebDriver);
            SessionProductOrderList = new SessionProductOrderList(ProductOrderList);
            Common = new Common(productOrderList);
        }

        [Then(@"The user views Products page")]
        public void ThenTheUserViewsProductsPage()
        {
            var Pagetitle = ProductsPage.GetPageTitle();
            Assert.That(Pagetitle, Is.EqualTo("Products"), "Product page title is incorrect");
        }

        [When(@"The user clciks on Logout from menu options")]
        public void WhenTheUserClciksOnLogoutFromMenuOptions()
        {
            ProductsPage.ClickMenu();
            ProductsPage.ClickLogout();
        }

        [When(@"The user clicks on Add to cart button with (.*) product from Prodcuts page")]
        public void WhenTheUserClicksOnAddToCartButtonWithProductFromProdcutsPage(string productName)
        {
            ProductsPage.AddProductToCart(productName);
            SessionProductOrderList.AddProductToOrderList(productName);
        }

        [When(@"The user clicks on Add to cart button with (.*) product from Large Prodcut page")]
        public void WhenTheUserClicksOnAddToCartButtonWithProductFromLargeProdcutPage(string productName)
        {
            ProductsPage.AddProductToCartFromLarge(productName);
            SessionProductOrderList.AddProductToOrderList(productName);
        }


        [When(@"The user clicks on (.*) product image from Products page")]
        public void WhenTheUserClicksOnProductImageFromProductsPage(string productName)
        {
            ProductsPage.ClickProduct(productName);
        }

        [Then(@"The user verifies (.*) details on Product page")]
        public void ThenTheUserVerifiesDetailsOnProductPage(string productName)
        {
            var ActualProdcut = ProductsPage.GetLargeProductInformation();
            var ExpectedProdcut = SessionProductOrderList.GetProductInformation(productName);
            var IsProductsSame = Common.CompareProducts(ExpectedProdcut, ActualProdcut);
            Assert.That(IsProductsSame, Is.EqualTo(true), $"{productName} details are incorrect on Product page");
        }

        [Then(@"The user verifies (.*) product information on Products page")]
        public void ThenTheUserVerifiesProductInformationOnProductsPage(string productName)
        {
            var ActualProdcut = ProductsPage.GetProductInformation(productName);
            var ExpectedProdcut = SessionProductOrderList.GetProductInformation(productName);
            var IsProductsSame = Common.CompareProducts(ExpectedProdcut, ActualProdcut);
            Assert.That(IsProductsSame, Is.EqualTo(true), $"{productName} details are incorrect on Products page");
        }

        [When(@"The user clicks on Back to products on Product page")]
        public void WhenTheUserClicksOnBackToProductsOnProductPage()
        {
            ProductsPage.NavigateToProducts();
        }

        [When(@"The user selects (.*) from the filter dropdown on the Products page")]
        public void WhenTheUserSelectsFromTheFilterDropdownOnTheProductsPage(string sortOrder)
        {
            ProductsPage.SelectItemForFilter(sortOrder);
        }

        [Then(@"The user verify (.*) sorting order on the Products page")]
        public void ThenTheUserVerifySortingOrderOnTheProductsPage(string sortOrder)
        {
            var productsList = SessionProductOrderList.ReadProductInformation();
            var expectedOrderList = Common.SortProductList(productsList, sortOrder);
            var actualOrderList = ProductsPage.ReadProductsFromAllProdcuts();

            bool isListSame = Common.CompareProductList(expectedOrderList, actualOrderList);
            Assert.That(isListSame, Is.EqualTo(true), $"Products sorting is incorrect for filter: {sortOrder} on Products page");
        }
    }
}
