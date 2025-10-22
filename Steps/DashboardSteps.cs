using OpenQA.Selenium;
using Reqnroll;
using NUnit.Framework;
using qa_dotnet_cucumber.Pages;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class DashboardSteps
    {
        private readonly DashboardPage _dashboardPage;

        public DashboardSteps(DashboardPage dashboardPage)
        {
            _dashboardPage = dashboardPage;
        }

        [Then("I should see the welcome message")]
        public void ThenIShouldSeeTheWelcomeMessage()
        {
            Assert.That(_dashboardPage.GetWelcomeMessage(), Does.Contain("Welcome"),
                "User should see a welcome message after logging in.");
        }
    }
}
