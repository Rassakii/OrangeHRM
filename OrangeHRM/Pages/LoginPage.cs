using OpenQA.Selenium;
using OrangeHRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Pages
{
    internal class LoginPage
    {
         IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
           

        }
        //IWebElement UsernameTextfield => _driver.FindElement(By.XPath("//input[@name='username']"));
        //IWebElement PasswordTextfield => _driver.FindElement(By.XPath("//input[@placeholder='Password']"));

        public IWebElement textField(string textFieldPlaceholder)
        {return  _driver.FindElement(By.XPath($"//input[contains(@class,'oxd-input') and @placeholder='{textFieldPlaceholder}']")); 
        }
        IWebElement LoginButton => _driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--main orangehrm-login-button']"));
        public void FillDetails(UserProfile user) 
        {
            textField("Username").SendKeys(user.username);
            textField("Password").SendKeys(user.password);


        }
        public void ClickLogin() 
        {
            LoginButton.Click();
        }
    }
}
