using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebShop.Drivers
{
    public class WebDriverFactory
    {
        // Method to initialize the WebDriver for Chrome only
        public static IWebDriver InitializeDriver()
        {
            // Create Chrome options with additional arguments
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless"); // Run in headless mode
            chromeOptions.AddArgument("--no-sandbox"); // Required for some CI environments
            chromeOptions.AddArgument("--disable-dev-shm-usage"); // Overcomes limited resource problems
            chromeOptions.AddArgument("--disable-gpu"); // Applicable for older versions of Chrome
            chromeOptions.AddArgument("--start-maximized"); // Optionally keep this for local runs

            // Initialize the ChromeDriver with the specified options
            IWebDriver driver = new ChromeDriver(chromeOptions);

            // Set an implicit wait timeout of 30 seconds for finding elements
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return driver; // Return the initialized WebDriver instance
        }
    }
}
