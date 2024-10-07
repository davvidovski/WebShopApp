using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebShop.Utilities
{
    // SeleniumHelper class provides utility methods for Selenium operations
    public static class SeleniumHelper
    {
        // WaitForElement method waits until the specified element is displayed on the page
        // Parameters:
        // - driver: The IWebDriver instance used for browser interaction
        // - locator: The By locator used to find the element on the page
        // - timeout: The maximum time to wait for the element to be displayed
        public static void WaitForElement(IWebDriver driver, By locator, TimeSpan timeout)
        {
            // Create a new instance of WebDriverWait with the specified timeout
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            
            // Wait until the specified element is found and is displayed
            wait.Until(drv => drv.FindElement(locator).Displayed);
        }
    }
    
}
