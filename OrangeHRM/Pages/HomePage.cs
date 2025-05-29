using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Pages
{
    internal class HomePage
    {
        IWebDriver _driver;
        public HomePage(IWebDriver driver) 
        { 
            _driver = driver;
        }
        IWebElement PageHeader => _driver.FindElement(By.XPath("//h6[@class='oxd-text oxd-text--h6 oxd-topbar-header-breadcrumb-module']"));
        IWebElement Chart => _driver.FindElement(By.XPath("//canvas[@id='2aaQhqAX']"));
        IWebElement PIMButton => _driver.FindElement(By.XPath("//a[@href='/web/index.php/pim/viewPimModule']"));

        public string VerifyHeaderText()
        { 
           return PageHeader.Text;
        }
        public bool VerifyChartDisplay()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

             wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//canvas[@id='2aaQhqAX']")));

            return Chart.Displayed;
        }
        public void ClickPim() 
        {
            PIMButton.Click();
        }
    }
}
