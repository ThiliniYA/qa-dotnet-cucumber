using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using qa_dotnet_cucumber.Pages;
using Reqnroll;
using SeleniumExtras.WaitHelpers;

namespace qa_dotnet_cucumber.Steps
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Expose driver if needed
        public IWebDriver Driver => _driver;

        // Locators
        private readonly By usernameField = By.Id("username");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.CssSelector("button[type='submit']");
        private readonly By flashMessage = By.CssSelector(".flash");

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Navigate to login page
        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        // Perform login
        public void Login(string username, string password)
        {
            var usernameElement = _wait.Until(ExpectedConditions.ElementIsVisible(usernameField));
            usernameElement.Clear();
            usernameElement.SendKeys(username);

            var passwordElement = _wait.Until(ExpectedConditions.ElementIsVisible(passwordField));
            passwordElement.Clear();
            passwordElement.SendKeys(password);

            var loginButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(loginButton));
            loginButtonElement.Click();
        }

        // Get any flash message (success or error)
        public string GetFlashMessage()
        {
            try
            {
                // Wait until any flash message is visible
                return _wait.Until(ExpectedConditions.ElementIsVisible(flashMessage)).Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }

        // Verify if currently at login page
        public bool IsAtLoginPage()
        {
            return _driver.Title.Contains("The Internet");
        }
    }
}