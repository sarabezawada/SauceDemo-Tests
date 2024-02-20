namespace SauceDemo_Tests.Utils.TestData
{
    public class ProductOrderList
    {
        public int Quantity { get; set; }
        public ProductInformation Products { get; set; }
    }

    public class ProductInformation
    {
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
    }
}
