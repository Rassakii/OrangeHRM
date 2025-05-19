using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll.BoDi;

namespace OrangeHRM.Utilities
{
    internal class WebdriverSupport
    {
        private readonly IObjectContainer _objectContainer;
        public IWebDriver _driver;


        public WebdriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }




        public void InitializeBrowser(string browser)
        {
            
            switch (browser.ToLower())
            {
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    _driver = new ChromeDriver(chromeOptions);
                    break;
                case "edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    _driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    throw new ArgumentException("Unsupported browser: " + browser);
            }
            _objectContainer.RegisterInstanceAs(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void CloseApplicationUnderTest()
        {


            _driver?.Quit();

        }
    }
}
