using OpenQA.Selenium;
using SauceDemo_Tests.Utils.Helpers;
using SauceDemo_Tests.Utils.TestData;
using System;
using System.Collections.Generic;

namespace SauceDemo_Tests.StepDefinitions.Overview
{
    public class OverviewPage
    {
        private readonly IWebDriver Webdriver;
        private readonly List<ProductOrderList> ProductOrderList;
        private readonly ProductInformation ProductInformation;
        private readonly SessionProductOrderList SessionProductOrderList;

        public OverviewPage(IWebDriver webdriver)
        {
            Webdriver = webdriver;
            ProductOrderList = new List<ProductOrderList>();
            ProductInformation = new ProductInformation();
            SessionProductOrderList = new SessionProductOrderList(ProductOrderList);
        }

        IWebElement PageTitle => Webdriver.FindElement(By.XPath("//div[@class='header_secondary_container']/span"));
        IReadOnlyCollection<IWebElement> OverviewProductList => Webdriver.FindElements(By.XPath("//*[@class='cart_list']/div[@class='cart_item']"));
        IWebElement PaymentInformation => Webdriver.FindElement(By.XPath("//*[text()='Payment Information']"));
        IWebElement PaymentInformationValue => Webdriver.FindElement(By.XPath("//*[text()='Payment Information']/following-sibling::div[@class='summary_value_label'][1]"));
        IWebElement ShippingInformation => Webdriver.FindElement(By.XPath("//*[text()='Shipping Information']"));
        IWebElement ShippingInformationValue => Webdriver.FindElement(By.XPath("//*[text()='Shipping Information']/following-sibling::div[@class='summary_value_label'][1]"));
        IWebElement ItemTotal => Webdriver.FindElement(By.ClassName("summary_subtotal_label"));
        IWebElement Tax => Webdriver.FindElement(By.ClassName("summary_tax_label"));
        IWebElement PriceTotal => Webdriver.FindElement(By.XPath("//*[@class='summary_info_label summary_total_label']"));
        IWebElement FinishBtn => Webdriver.FindElement(By.Id("finish"));
        IWebElement CancelBtn => Webdriver.FindElement(By.Id("cancel"));

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

        public int GetProductListCount()
        {
            try
            {
                var ProdcutListCount = OverviewProductList.Count;

                return ProdcutListCount;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ProductOrderList> ReadProductsFromOverview() {
            try
            {
                var Quantity = 0;
                var ProductName = string.Empty;
                var ProductImage = string.Empty;
                var ProductDescription = string.Empty;
                var ProductPrice = string.Empty;

                foreach (var Product in OverviewProductList)
                {
                    Quantity = int.Parse(Product.FindElement(By.ClassName("cart_quantity")).Text);
                    ProductName = Product.FindElement(By.ClassName("cart_item_label")).FindElement(By.TagName("a")).Text;
                    ProductDescription = Product.FindElement(By.ClassName("cart_item_label")).FindElement(By.ClassName("inventory_item_desc")).Text;
                    ProductPrice = Product.FindElement(By.ClassName("cart_item_label")).FindElement(By.ClassName("item_pricebar")).FindElement(By.ClassName("inventory_item_price")).Text;

                    ProductOrderList.Add(new ProductOrderList
                    {
                        Quantity = Quantity,
                        Products = new ProductInformation
                        {
                            ProductName = ProductName,
                            ProductImage = ProductImage,
                            ProductDescription = ProductDescription,
                            ProductPrice = ProductPrice
                        }
                    });
                }

                return ProductOrderList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public (bool isDisplayed, string value) GetPaymentInformation() {
            try
            {
                var IsPaymentLabelDisplayed = PaymentInformation.Displayed;
                var PaymentInfoValue = PaymentInformationValue.Text;

                return (IsPaymentLabelDisplayed, PaymentInfoValue);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public (bool isDisplayed, string value) GetShippingInformation()
        {
            try
            {
                var IsShippingLabelDisplayed = ShippingInformation.Displayed;
                var ShippingInfoValue = ShippingInformationValue.Text;

                return (IsShippingLabelDisplayed, ShippingInfoValue);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public (double itemTotal, double tax, double total) GetPriceInformation()
        {
            try
            {
                var ItemTotalValue = ItemTotal.Text;
                var TaxValue = Tax.Text;
                var TotalValue = PriceTotal.Text;

                ItemTotalValue = ItemTotalValue.Substring(ItemTotalValue.IndexOf('$'));
                ItemTotalValue = ItemTotalValue.Replace("$", "");

                TaxValue = TaxValue.Substring(TaxValue.IndexOf('$'));
                TaxValue = TaxValue.Replace("$", "");

                TotalValue = TotalValue.Substring(TotalValue.IndexOf('$'));
                TotalValue = TotalValue.Replace("$", "");

                return (Math.Round(double.Parse(ItemTotalValue), 2), Math.Round(double.Parse(TaxValue), 2), Math.Round(double.Parse(TotalValue), 2));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void NavigateToComplete() {
            try
            {
                FinishBtn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
