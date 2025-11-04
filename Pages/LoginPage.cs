using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll.BoDi;
using System;
using SeleniumExtras.WaitHelpers;

namespace qa_dotnet_cucumber.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;  

        // Locators
        private readonly By UsernameField = By.Id("username");
        private readonly By PasswordField = By.Id("password");
        private readonly By LoginButton = By.CssSelector("button[type='submit']");
        private readonly By SuccessMessage = By.CssSelector(".flash.success");
        private By usernameField;
        private By passwordField;
        private By loginButton;
        private By successMessage;

        public LoginPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
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

        // Get success message text
        public string GetSuccessMessage()
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(successMessage)).Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }

        // Check if login was successful
        public bool IsLoginSuccessful()
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(successMessage)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // Verify if currently at login page
        public bool IsAtLoginPage()
        {
            return _driver.Title.Contains("The Internet");
        }

        internal bool GetFlashMessage()
        {
            throw new NotImplementedException();
        }
    }
}