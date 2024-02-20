using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemo_Tests.Utils.TestData;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace SauceDemoTests.StepDefinitions.Products
{

    public class ProductsPage
    {
        private readonly IWebDriver Webdriver;
        private readonly WebDriverWait WebDriverWait;

        public ProductsPage(IWebDriver webdriver)
        {
            Webdriver = webdriver;
            WebDriverWait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(10));
        }

        IWebElement PageTitle => Webdriver.FindElement(By.XPath("//div[@class='header_secondary_container']/span"));
        IWebElement Menu => Webdriver.FindElement(By.Id("react-burger-menu-btn"));
        IWebElement FilterDropdown => Webdriver.FindElement(By.ClassName("product_sort_container"));
        IWebElement Logut => Webdriver.FindElement(By.Id("logout_sidebar_link"));
        IWebElement BackToProductsBtn => Webdriver.FindElement(By.Id("back-to-products"));

        IReadOnlyCollection<IWebElement> AllProductsList => Webdriver.FindElements(By.XPath("//*[@class='inventory_list']/div[@class='inventory_item']"));

        // Backpack Locators
        IWebElement Backpack => Webdriver.FindElement(By.Id("item_4_title_link"));
        IWebElement BackpackImage => Webdriver.FindElement(By.XPath("//*[@alt='Sauce Labs Backpack']"));
        IWebElement BackpackDescription => Webdriver.FindElement(By.XPath("//*[@id='item_4_title_link']/following-sibling::div[@class='inventory_item_desc']"));
        IWebElement BackpackPrice => Webdriver.FindElement(By.XPath("//*[@id='add-to-cart-sauce-labs-backpack']/preceding-sibling::div[@class='inventory_item_price']"));
        IWebElement BackpackAddBtn => Webdriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        IWebElement BackpackRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-backpack"));

        // BikeLight Locators
        IWebElement BikeLight => Webdriver.FindElement(By.Id("item_0_title_link"));
        IWebElement BikeLightImage => Webdriver.FindElement(By.XPath("//*[@alt='Sauce Labs Bike Light']"));
        IWebElement BikeLightDescription => Webdriver.FindElement(By.XPath("//*[@id='item_0_title_link']/following-sibling::div[@class='inventory_item_desc']"));
        IWebElement BikeLightPrice => Webdriver.FindElement(By.XPath("//*[@id='add-to-cart-sauce-labs-bike-light']/preceding-sibling::div[@class='inventory_item_price']"));
        IWebElement BikeLightAddBtn => Webdriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        IWebElement BikeLightRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-backpack"));

        // BoltTShirt Locators
        IWebElement BoltTShirt => Webdriver.FindElement(By.Id("item_1_title_link"));
        IWebElement BoltTShirtImage => Webdriver.FindElement(By.XPath("//*[@alt='Sauce Labs Bolt T-Shirt']"));
        IWebElement BoltTShirtDescription => Webdriver.FindElement(By.XPath("//*[@id='item_1_title_link']/following-sibling::div[@class='inventory_item_desc']"));
        IWebElement BoltTShirtPrice => Webdriver.FindElement(By.XPath("//*[@id='add-to-cart-sauce-labs-bolt-t-shirt']/preceding-sibling::div[@class='inventory_item_price']"));
        IWebElement BoltTShirtAddBtn => Webdriver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        IWebElement BoltTShirtRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt"));

        // FleeJacket Locators
        IWebElement FleeJacket => Webdriver.FindElement(By.Id("item_5_title_link"));
        IWebElement FleeJacketImage => Webdriver.FindElement(By.XPath("//*[@alt='Sauce Labs Fleece Jacket']"));
        IWebElement FleeJacketDescription => Webdriver.FindElement(By.XPath("//*[@id='item_5_title_link']/following-sibling::div[@class='inventory_item_desc']"));
        IWebElement FleeJacketPrice => Webdriver.FindElement(By.XPath("//*[@id='add-to-cart-sauce-labs-fleece-jacket']/preceding-sibling::div[@class='inventory_item_price']"));
        IWebElement FleeJacketAddBtn => Webdriver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
        IWebElement FleeJacketRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-fleece-jacket"));

        // Onesie Locators
        IWebElement Onesie => Webdriver.FindElement(By.Id("item_2_title_link"));
        IWebElement OnesieImage => Webdriver.FindElement(By.XPath("//*[@alt='Sauce Labs Onesie']"));
        IWebElement OnesieDescription => Webdriver.FindElement(By.XPath("//*[@id='item_2_title_link']/following-sibling::div[@class='inventory_item_desc']"));
        IWebElement OnesiePrice => Webdriver.FindElement(By.XPath("//*[@id='add-to-cart-sauce-labs-onesie']/preceding-sibling::div[@class='inventory_item_price']"));
        IWebElement OnesieAddBtn => Webdriver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        IWebElement OnesieRemoveBtn => Webdriver.FindElement(By.Id("remove-sauce-labs-onesie"));

        // RedTShirt Locators
        IWebElement RedTShirt => Webdriver.FindElement(By.Id("item_3_title_link"));
        IWebElement RedTShirtImage => Webdriver.FindElement(By.XPath("//*[@alt='Test.allTheThings() T-Shirt (Red)']"));
        IWebElement RedTShirtDescription => Webdriver.FindElement(By.XPath("//*[@id='item_3_title_link']/following-sibling::div[@class='inventory_item_desc']"));
        IWebElement RedTShirtPrice => Webdriver.FindElement(By.XPath("//*[@id='add-to-cart-test.allthethings()-t-shirt-(red)']/preceding-sibling::div[@class='inventory_item_price']"));
        IWebElement RedTShirtAddBtn => Webdriver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)"));
        IWebElement RedTShirtRemoveBtn => Webdriver.FindElement(By.Id("remove-test.allthethings()-t-shirt-(red)"));

        //Large Product Image Locators
        IWebElement ProductName => Webdriver.FindElement(By.XPath("//*[@class='inventory_details_name large_size']"));
        IWebElement ProductImage => Webdriver.FindElement(By.ClassName("inventory_details_img"));
        IWebElement ProductDescription => Webdriver.FindElement(By.XPath("//*[@class='inventory_details_desc large_size']"));
        IWebElement ProductPrice => Webdriver.FindElement(By.ClassName("inventory_details_price"));
        IWebElement ProductAddBtn => Webdriver.FindElement(By.XPath("//*[@class='btn btn_primary btn_small btn_inventory']"));
        IWebElement ProductRemoveBtn => Webdriver.FindElement(By.XPath("//*[@class='btn btn_secondary btn_small btn_inventory']"));

        public void ClickMenu()
        {
            try
            {
                Menu.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ClickLogout()
        {
            try
            {
                WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("logout_sidebar_link")));
                Logut.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

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

        public void AddProductToCart(string productName) {
            switch (productName)
            {
                case "Sauce Labs Backpack":
                    BackpackAddBtn.Click();
                    break;
                case "Sauce Labs Bike Light":
                    BikeLightAddBtn.Click();
                    break;
                case "Sauce Labs Bolt T-Shirt":
                    BoltTShirtAddBtn.Click();
                    break;
                case "Sauce Labs Fleece Jacket":
                    FleeJacketAddBtn.Click();
                    break;
                case "Sauce Labs Onesie":
                    OnesieAddBtn.Click();
                    break;
                case "Test.allTheThings() T-Shirt (Red)":
                    RedTShirtAddBtn.Click();
                    break;
                default:
                    throw new ArgumentException("Provide incorrect product name");
            }
        }

        public void ClickProduct(string productName)
        {
            WebDriverWait.Until(ExpectedConditions.ElementExists(By.ClassName("product_sort_container")));

            switch (productName)
            {
                case "Sauce Labs Backpack":
                    Backpack.Click();
                    break;
                case "Sauce Labs Bike Light":
                    BikeLight.Click();
                    break;
                case "Sauce Labs Bolt T-Shirt":
                    BoltTShirt.Click();
                    break;
                case "Sauce Labs Fleece Jacket":
                    FleeJacket.Click();
                    break;
                case "Sauce Labs Onesie":
                    Onesie.Click();
                    break;
                case "Test.allTheThings() T-Shirt (Red)":
                    RedTShirt.Click();
                    break;
                default:
                    throw new ArgumentException("Provide incorrect product name");
            }
        }

        public void AddProductToCartFromLarge(string productName)
        {
            try
            {
                WebDriverWait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='btn btn_primary btn_small btn_inventory']")));
                ProductAddBtn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ProductInformation GetLargeProductInformation() {
            try
            {
                ProductInformation ProductInformation = new ProductInformation
                {
                    ProductName = ProductName.Text,
                    ProductImage = ProductImage.GetAttribute("src").Replace("https://www.saucedemo.com", ""),
                    ProductDescription = ProductDescription.Text,
                    ProductPrice = ProductPrice.Text
                };

                return ProductInformation;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            } 
        }

        public ProductInformation GetProductInformation(string productName)
        {
            try
            {
                string ProductName;
                string ProductImage;
                string ProductDescription;
                string ProductPrice;

                switch (productName)
                {
                    case "Sauce Labs Backpack":
                        ProductName = Backpack.Text;
                        ProductImage = BackpackImage.GetAttribute("src").Replace("https://www.saucedemo.com", "");
                        ProductDescription = BackpackDescription.Text;
                        ProductPrice = BackpackPrice.Text;
                        break;
                    case "Sauce Labs Bike Light":
                        ProductName = BikeLight.Text;
                        ProductImage = BikeLightImage.GetAttribute("src").Replace("https://www.saucedemo.com", "");
                        ProductDescription = BikeLightDescription.Text;
                        ProductPrice = BikeLightPrice.Text;
                        break;
                    case "Sauce Labs Bolt T-Shirt":
                        ProductName = BoltTShirt.Text;
                        ProductImage = BoltTShirtImage.GetAttribute("src").Replace("https://www.saucedemo.com", "");
                        ProductDescription = BoltTShirtDescription.Text;
                        ProductPrice = BoltTShirtPrice.Text;
                        break;
                    case "Sauce Labs Fleece Jacket":
                        ProductName = FleeJacket.Text;
                        ProductImage = FleeJacketImage.GetAttribute("src").Replace("https://www.saucedemo.com", "");
                        ProductDescription = FleeJacketDescription.Text;
                        ProductPrice = FleeJacketPrice.Text;
                        break;
                    case "Sauce Labs Onesie":
                        ProductName = Onesie.Text;
                        ProductImage = OnesieImage.GetAttribute("src").Replace("https://www.saucedemo.com", "");
                        ProductDescription = OnesieDescription.Text;
                        ProductPrice = OnesiePrice.Text;
                        break;
                    case "Test.allTheThings() T-Shirt (Red)":
                        ProductName = RedTShirt.Text;
                        ProductImage = RedTShirtImage.GetAttribute("src").Replace("https://www.saucedemo.com", "");
                        ProductDescription = RedTShirtDescription.Text;
                        ProductPrice = RedTShirtPrice.Text;
                        break;
                    default:
                        throw new ArgumentException("Provide incorrect product name");
                }

                ProductInformation ProductInformation = new ProductInformation
                {
                    ProductName = ProductName,
                    ProductImage = ProductImage,
                    ProductDescription = ProductDescription,
                    ProductPrice = ProductPrice
                };

                return ProductInformation;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SelectItemForFilter(string itemToSelect) {
            try
            {
                var filterDropDown = new SelectElement(FilterDropdown);
                filterDropDown.SelectByText(itemToSelect);
                WebDriverWait.Until(ExpectedConditions.ElementExists(By.ClassName("product_sort_container")));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ProductInformation> ReadProductsFromAllProdcuts()
        {
            try
            {
                var ProductName = string.Empty;
                var ProductImage = string.Empty;
                var ProductDescription = string.Empty;
                var ProductPrice = string.Empty;
                List<ProductInformation> productOrderList = new List<ProductInformation>();

                int index = 1;
                foreach (var ProductItem in AllProductsList)
                {
                    ProductName = ProductItem.FindElement(By.ClassName("inventory_item_description")).FindElement(By.TagName("a")).Text;
                    ProductImage = Webdriver.FindElement(By.XPath("//*[@class='inventory_list']/div[@class='inventory_item'][" + index + "]//img")).GetAttribute("src").Replace("https://www.saucedemo.com", "");
                    ProductDescription = ProductItem.FindElement(By.ClassName("inventory_item_desc")).Text;
                    ProductPrice = ProductItem.FindElement(By.ClassName("inventory_item_price")).Text;

                    productOrderList.Add(new ProductInformation
                    {
                        ProductName = ProductName,
                        ProductImage = ProductImage,
                        ProductDescription = ProductDescription,
                        ProductPrice = ProductPrice
                    });

                    index++;
                }

                return productOrderList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        public void NavigateToProducts() {
            try
            {
                BackToProductsBtn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
