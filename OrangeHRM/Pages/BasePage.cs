using OpenQA.Selenium;
using OrangeHRM.Configration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Pages
{
    internal class BasePage
    {
        public IWebDriver Driver;
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void LoadAppplicationUnderTest()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.Url);
            Driver.Manage().Window.Maximize();
        }
    }
}
