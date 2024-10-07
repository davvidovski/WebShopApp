using OpenQA.Selenium;
using WebShop.Locators;

namespace WebShop.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver; // Store the WebDriver instance

        // Constructor to initialize the LoginPage with the WebDriver
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver; // Assign the provided WebDriver to the class variable
        }

        // Method to check if the username field is displayed on the page
        public bool IsLoginFieldDisplayed()
        {
            return driver.FindElement(LoginPageLocators.UsernameField).Displayed; // Return true if displayed
        }

        // Method to enter the specified username into the username field
        public void EnterUsername(string username)
        {
            driver.FindElement(LoginPageLocators.UsernameField).SendKeys(username); // Type the username
        }

        // Method to enter the specified password into the password field
        public void EnterPassword(string password)
        {
            driver.FindElement(LoginPageLocators.PasswordField).SendKeys(password); // Type the password
        }

        // Method to click the login button
        public void ClickLogin()
        {
            driver.FindElement(LoginPageLocators.LoginButton).Click(); // Click the login button
        }

        // Method to check or uncheck the "Remember Me" option
        public void CheckRememberMe()
        {
            driver.FindElement(By.Id("RememberMe")).Click(); // Click the Remember Me checkbox
        }
    }
}
