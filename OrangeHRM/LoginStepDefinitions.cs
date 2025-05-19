using System;
using OrangeHRM.Pages;
using Reqnroll;

namespace OrangeHRM
{
    [Binding]
    public class LoginStepDefinitions
    {
        BasePage _basepage;
        ScenarioContext _scenarioContext;
        public LoginStepDefinitions(ScenarioContext scenariocontext)
        {
            _basepage = scenariocontext.ScenarioContainer.Resolve<BasePage>();
            _scenarioContext = scenariocontext.ScenarioContainer.Resolve<ScenarioContext>();
        }
        [Given("OrangeHrm is loaded succesfully")]
        public void GivenOrangeHrmIsLoadedSuccesfully()
        {
            _basepage.LoadAppplicationUnderTest();  
        }

        [When("Inserts the username and password appropriately")]
        public void WhenInsertsTheUsernameAndPasswordAppropriately()
        {
            throw new PendingStepException();
        }

        [When("User clicks on Login")]
        public void WhenUserClicksOnLogin()
        {
            throw new PendingStepException();
        }

        [Then("User is signed in succesfully")]
        public void ThenUserIsSignedInSuccesfully()
        {
            throw new PendingStepException();
        }
    }
}
