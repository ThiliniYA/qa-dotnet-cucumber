using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace qa_dotnet_cucumber.Pages
{
    public class LanguagesPage
    {
        private readonly IWebDriver _driver;


    public LanguagesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Add a new language
        public void AddLanguage(string languageName, string languageLevel)
        {
            _driver.FindElement(By.XPath("//button[text()='Add New']")).Click();
            _driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(languageName);

            var dropdown = _driver.FindElement(By.XPath("//select[@name='level']"));
            dropdown.Click();
            _driver.FindElement(By.XPath($"//option[text()='{languageLevel}']")).Click();

            _driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        // Verify language exists
        public bool VerifyLanguageExists(string languageName, string languageLevel = null)
        {
            try
            {
                var languageElement = _driver.FindElement(By.XPath($"//td[text()='{languageName}']"));
                if (languageLevel != null)
                {
                    var levelElement = _driver.FindElement(By.XPath($"//td[text()='{languageLevel}']"));
                    return languageElement.Displayed && levelElement.Displayed;
                }
                return languageElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Update a language
        public void UpdateLanguage(string oldLanguage, string newLanguage, string newLevel)
        {
            _driver.FindElement(By.XPath($"//td[text()='{oldLanguage}']/following-sibling::td//i[@class='edit icon']")).Click();

            var input = _driver.FindElement(By.XPath("//input[@name='name']"));
            input.Clear();
            input.SendKeys(newLanguage);

            var dropdown = _driver.FindElement(By.XPath("//select[@name='level']"));
            dropdown.Click();
            _driver.FindElement(By.XPath($"//option[text()='{newLevel}']")).Click();

            _driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }

        // Delete a single language
        public void DeleteLanguage(string languageName)
        {
            _driver.FindElement(By.XPath($"//td[text()='{languageName}']/following-sibling::td//i[@class='remove icon']")).Click();
            try
            {
                _driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException)
            {
            }
        }

        // Delete all languages
        public void DeleteAllLanguages()
        {
            var languageRows = _driver.FindElements(By.XPath("//table[@class='ui fixed table']//tbody/tr"));

            while (languageRows.Count > 0)
            {
                languageRows[0].FindElement(By.XPath(".//i[@class='remove icon']")).Click();
                try
                {
                    _driver.SwitchTo().Alert().Accept();
                }
                catch (NoAlertPresentException)
                {
                }

                languageRows = _driver.FindElements(By.XPath("//table[@class='ui fixed table']//tbody/tr"));
            }
        }

        // Optional: check if table is empty
        public bool AreLanguagesEmpty()
        {
            var languageRows = _driver.FindElements(By.XPath("//table[@class='ui fixed table']//tbody/tr"));
            return languageRows.Count == 0;
        }
    }


}
