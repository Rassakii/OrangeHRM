using OpenQA.Selenium;
using OrangeHRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Pages
{
    internal class PIMPage
    {
        LoginPage _loginPage;
        IWebDriver _driver;
      
        public PIMPage(IWebDriver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver);

        }

        IWebElement AddButton => _driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']"));
        IWebElement EmployeelistButton => _driver.FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and contains(text(), 'Employee List')]"));
        IList<IWebElement> EmployeeList => _driver.FindElements(By.XPath("//div[@class='oxd-table-row oxd-table-row--with-border oxd-table-row--clickable']"));
        public void ClickAddButton() 
        {
            AddButton.Click();
        }

        public void FillUserdetails(UserProfile user)
        {
            _loginPage.textField("First Name").SendKeys(user.Firstname);
            _loginPage.textField("Middle Name").SendKeys(user.Middlename);
            _loginPage.textField("Last Name").SendKeys(user.Lastname);


        }
        public void ClickEmployeeList() 
        {
            EmployeelistButton.Click();


        }
        
        public bool DisplayEmployee(UserProfile user)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.Text.Contains(user.Firstname))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
