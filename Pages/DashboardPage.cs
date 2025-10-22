using OpenQA.Selenium;


namespace qa_dotnet_cucumber.Pages
{
    public class DashboardPage
    {

        private readonly IWebDriver _driver;
        private readonly By WelcomeMessage = By.Id("welcome");

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetWelcomeMessage()
        {
            return _driver.FindElement(WelcomeMessage).Text;
        }
    }

}