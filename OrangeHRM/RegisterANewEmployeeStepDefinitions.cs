using System;
using OrangeHRM.Model;
using OrangeHRM.Pages;
using Reqnroll;

namespace OrangeHRM
{
    [Binding]
    public class RegisterANewEmployeeStepDefinitions
    {
        BasePage _basepage;
        HomePage _homepage;
        ScenarioContext _scenarioContext;
        PIMPage _pimpage;
        LoginPage _loginpage;
        public RegisterANewEmployeeStepDefinitions(ScenarioContext scenariocontext)
        {
            _basepage = scenariocontext.ScenarioContainer.Resolve<BasePage>();
            _scenarioContext = scenariocontext.ScenarioContainer.Resolve<ScenarioContext>();
            _loginpage = scenariocontext.ScenarioContainer.Resolve<LoginPage>();
            _pimpage = scenariocontext.ScenarioContainer.Resolve<PIMPage>();
            _homepage = scenariocontext.ScenarioContainer.Resolve<HomePage>();
        }
        [When("User navigate to PIM page and click add employee")]
        public void WhenUserNavigateToPIMPageAndClickAddEmployee()
        {
            _homepage.ClickPim();
            _pimpage.ClickAddButton();
        }

        [When("User fills Employee details")]
        public void WhenUserFillsEmployeeDetails()
        {
            var user = _scenarioContext.Get<UserProfile>("user");
            _pimpage.FillUserdetails(user);
        }

        [Then("the employee is added succesfully")]
        public void ThenTheEmployeeIsAddedSuccesfully()
        {
            
            var user = _scenarioContext.Get<UserProfile>("user");
            _pimpage.ClickEmployeeList();
            Thread.Sleep(10);
            Assert.IsTrue(_pimpage.DisplayEmployee(user));
        }
    }
}
