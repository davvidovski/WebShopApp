using OpenQA.Selenium;

namespace WebShop.Locators
{
    public static class LoginPageLocators
    {
        // Top menu button to open login form
        public static readonly By LoginButtonTopMenu = By.ClassName("ico-login");

        // Email (username) input field on the login page
        public static readonly By UsernameField = By.Id("Email");

        // Password input field on the login page
        public static readonly By PasswordField = By.Id("Password");

        // Button to submit the login form
        public static readonly By LoginButton = By.CssSelector("input.button-1.login-button");

        // Validation error message displayed when login fails
        public static readonly By LoginNotSuccessfull = By.CssSelector("div.validation-summary-errors");

        // Logout button displayed after successful login
        public static readonly By LogoutButton = By.ClassName("ico-logout");

        // Error message shown when an invalid email format is entered
        public static readonly By InvalidEmailErrorMessage = By.XPath("//span[@class='field-validation-error']/span");
    }
}
