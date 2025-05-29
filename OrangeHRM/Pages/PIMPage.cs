using OpenQA.Selenium;
using OrangeHRM.Model;

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
        IWebElement PaginationNextButton => _driver.FindElement(By.XPath("//i[contains(@class,'oxd-icon bi-chevron-right')]"));
        IWebElement AddButton => _driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']"));
        IWebElement EmployeelistButton => _driver.FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and contains(text(), 'Employee List')]"));
        IList<IWebElement> EmployeeList => _driver.FindElements(By.XPath("//div[@class='oxd-table-row oxd-table-row--with-border oxd-table-row--clickable']"));
        IWebElement Save_Button => _driver.FindElement(By.XPath("//button[@type='submit']"));
        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public void FillUserdetails(UserProfile user)
        {
            _loginPage.textField("First Name").SendKeys(user.Firstname);
            _loginPage.textField("Middle Name").SendKeys(user.Middlename);
            _loginPage.textField("Last Name").SendKeys(user.Lastname);
            Save_Button.Click();
            Thread.Sleep(3000);
        }

        public bool IsEmployeeDisplayedOnCurrentPage(UserProfile user)
        {
            foreach (var employee in EmployeeList)
            {
                if (employee.Text.ToLower().Contains(user.Firstname.ToLower()) && employee.Text.ToLower().Contains(user.Lastname.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        bool IsNextPageChevronDisplayed()
        {
            try
            {
                return PaginationNextButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsNewlyRegisteredEmployeeDisplayed(UserProfile user)
        {
            EmployeelistButton.Click();
            if (IsEmployeeDisplayedOnCurrentPage(user))
                return true;
            while (IsNextPageChevronDisplayed())
            {
                PaginationNextButton.Click();
                if (IsEmployeeDisplayedOnCurrentPage(user))
                    return true;
            }
            return false;
        }
    }
}