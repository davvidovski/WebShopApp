using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebShop.Pages
{
    // BasePage serves as a foundation for all page classes in the application
    public class BasePage
    {
        protected IWebDriver driver; // Instance of the WebDriver to interact with the browser

        // Constructor to initialize the driver instance
        public BasePage(IWebDriver driver)
        {
            this.driver = driver; // Assign the passed driver to the class variable
        }

        // Method to wait for a specific element to be visible and enabled
        protected void WaitForElement(By locator, TimeSpan timeout)
        {
            // Create a new WebDriverWait instance with the specified timeout
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            // Wait until the condition specified in the lambda expression is met
            wait.Until(d => 
            {
                // Attempt to find the element using the provided locator
                var element = d.FindElement(locator);
                // Return true if the element is displayed and enabled, indicating it can be interacted with
                return element.Displayed && element.Enabled; 
            });
        }
    }
}
