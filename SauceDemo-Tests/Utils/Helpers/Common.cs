using SauceDemo_Tests.Utils.TestData;
using System.Collections.Generic;
using System.Linq;

namespace SauceDemo_Tests.Utils.Helpers
{
    public class Common
    {
        private readonly List<ProductOrderList> ProductOrderList;
        public Common(List<ProductOrderList> productOrderList) {
            ProductOrderList = productOrderList;
        }

        public bool CompareOrderProductList(List<ProductOrderList> actualList) {
            bool IsListSame = ProductOrderList.Count == actualList.Count &&
                ProductOrderList.Select(x => x.Quantity).ToHashSet().SetEquals(actualList.Select(x => x.Quantity))
                && ProductOrderList.Select(x => x.Products.ProductName).ToHashSet().SetEquals(actualList.Select(x => x.Products.ProductName))
                && ProductOrderList.Select(x => x.Products.ProductDescription).ToHashSet().SetEquals(actualList.Select(x => x.Products.ProductDescription))
                && ProductOrderList.Select(x => x.Products.ProductPrice).ToHashSet().SetEquals(actualList.Select(x => x.Products.ProductPrice));

            return IsListSame;
        }

        public bool CompareProducts(ProductInformation expectProuct, ProductInformation actualProduct) {
            bool IsProductsSame = expectProuct.ProductName.Equals(actualProduct.ProductName)
                && expectProuct.ProductImage.Equals(actualProduct.ProductImage)
                && expectProuct.ProductDescription.Equals(actualProduct.ProductDescription)
                && expectProuct.ProductPrice.Equals(actualProduct.ProductPrice);

            return IsProductsSame;
        }

        public bool CompareProductList(List<ProductInformation> expectedList, List<ProductInformation> actualList)
        {
            bool IsListSame = expectedList.Count == actualList.Count
                && expectedList.Select(x => x.ProductName).ToHashSet().SetEquals(actualList.Select(x => x.ProductName))
                && expectedList.Select(x => x.ProductImage).ToHashSet().SetEquals(actualList.Select(x => x.ProductImage))
                && expectedList.Select(x => x.ProductDescription).ToHashSet().SetEquals(actualList.Select(x => x.ProductDescription))
                && expectedList.Select(x => x.ProductPrice).ToHashSet().SetEquals(actualList.Select(x => x.ProductPrice));

            return IsListSame;
        }

        public List<ProductInformation> SortProductList(List<ProductInformation> productList, string sortOrder) {

            List<ProductInformation> sortedList;

            switch (sortOrder)
            {
                case "Name (A to Z)":
                    sortedList = productList.OrderBy(i => i.ProductName).ToList();
                    break;
                case "Name (Z to A)":
                    sortedList = productList.OrderByDescending(i => i.ProductName).ToList();
                    break;
                case "Price (low to high)":
                    sortedList = productList.OrderBy(i => double.Parse(i.ProductPrice.Replace("$", ""))).ToList();
                    break;
                case "Price (high to low)":
                    sortedList = productList.OrderByDescending(i => double.Parse(i.ProductPrice.Replace("$", ""))).ToList();
                    break;
                default:
                    sortedList = productList.OrderBy(i => i.ProductName).ToList();
                    break;
            }

            return sortedList;
        }
    }
}
