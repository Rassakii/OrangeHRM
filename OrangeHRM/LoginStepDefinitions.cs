using OrangeHRM.Model;
using OrangeHRM.Pages;
using Reqnroll;

namespace OrangeHRM
{
    [Binding]
    public class LoginStepDefinitions
    {
        BasePage _basepage;
        HomePage _homepage;
        ScenarioContext _scenarioContext;
        LoginPage _loginpage;
        public LoginStepDefinitions(ScenarioContext scenariocontext)
        {
            _basepage = scenariocontext.ScenarioContainer.Resolve<BasePage>();
            _scenarioContext = scenariocontext.ScenarioContainer.Resolve<ScenarioContext>();
            _loginpage = scenariocontext.ScenarioContainer.Resolve<LoginPage>();
            _homepage = scenariocontext.ScenarioContainer.Resolve<HomePage>();
        }
        [Given("OrangeHrm is loaded succesfully")]
        public void GivenOrangeHrmIsLoadedSuccesfully()
        {
            _basepage.LoadAppplicationUnderTest();
            var user = new UserProfile();
            _scenarioContext.Set(user, "user");
        }

        [When("Inserts the username and password appropriately")]
        public void WhenInsertsTheUsernameAndPasswordAppropriately()
        {
            var user = _scenarioContext.Get<UserProfile>("user");
            _loginpage.FillDetails(user);

        }

        [When("User clicks on Login")]
        public void WhenUserClicksOnLogin()
        {
            _loginpage.ClickLogin();
        }

        [Then("User is signed in succesfully")]
        public void ThenUserIsSignedInSuccesfully()
        {
            String ExpectedText=_homepage.VerifyHeaderText();
            StringAssert.Contains(ExpectedText, "Dashboard");
            //Assert.IsTrue(_homepage.VerifyChartDisplay());
        }
    }
}