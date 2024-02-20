using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SauceDemoTests.Utils.Helpers
{
    public class Browsers
    {
        public IWebDriver _webDriver;

        public Browsers(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebDriver LaunchBrwoser(string browser)
        {

            switch ((BrowserType)Enum.Parse(typeof(BrowserType), browser))
            {
                case BrowserType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--no-sandbox");
                    chromeOptions.AddArgument("--disable-application-cache");
                    chromeOptions.AddArgument("--start-maximized");
                    _webDriver = new ChromeDriver(chromeOptions);
                    break;
                default:
                    throw new ArgumentException("Provide incorrect browser type");
            }

            return _webDriver;
        }

        public enum BrowserType
        {
            Chrome,
            Edge,
            Safari,
            Firefox
        }
    }
}
