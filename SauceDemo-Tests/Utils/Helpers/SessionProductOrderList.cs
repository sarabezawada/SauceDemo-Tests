using Newtonsoft.Json;
using SauceDemo_Tests.Utils.TestData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SauceDemo_Tests.Utils.Helpers
{
    public class SessionProductOrderList
    {
        private readonly List<ProductOrderList> ProductOrderList;
        private List<ProductInformation> Products;

        public SessionProductOrderList(List<ProductOrderList> productOrderList) {
            ProductOrderList = productOrderList;
            Products = new List<ProductInformation>();
        }

        public void AddProductToOrderList(string productName) {
            var SelectedProduct = GetProductInformation(productName);

            ProductOrderList.Add(new ProductOrderList { 
                Quantity = 1,
                Products = SelectedProduct
            });
        }

        public void RemoveProductToOrderList(string productName)
        {
            var item = ProductOrderList.First(x => x.Products.ProductName == productName);
            ProductOrderList.Remove(item);
        }

        public ProductInformation GetProductInformation(string productName) {

            ReadProductInformation();
            var ProductInformation = (from product in Products
                                      where product.ProductName == productName
                                      select product).First();

            return ProductInformation;
        }

        public string GetImageInformation(string productName) {

            ReadProductInformation();

            var ImageInformation = (from product in Products
                                      where product.ProductName == productName
                                      select product.ProductImage).First();

            return ImageInformation;
        }

        public List<ProductInformation> ReadProductInformation() {
            string BaseDirPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")); ;
            string ProdcutJSONPath = BaseDirPath + @"Utils\TestData\Products.json";

            using (StreamReader r = new StreamReader(ProdcutJSONPath))
            {
                string json = r.ReadToEnd();
                Products = JsonConvert.DeserializeObject<List<ProductInformation>>(json);
            }

            return Products;
        }

        public (double itemTotal, double tax, double total) GetSessionPriceDetails()
        {
            var ItemTotal = 0.00;
            var Tax = 0.00;
            var Total = 0.00;
            var PriceList = from productList in ProductOrderList
                            select productList.Products.ProductPrice;

            foreach (var price in PriceList)
            {
                var Price = price.Substring(price.IndexOf('$'));
                Price = Price.Replace("$", "");
                ItemTotal +=  double.Parse(s: Price);
            }

            Tax = Math.Round((ItemTotal * 0.08), 2);
            Total = Math.Round((ItemTotal + Tax), 2);

            return (ItemTotal, Tax, Total);
        }

        public void FlushProductList()
        {
            ProductOrderList.Clear();
        }
    }
}
