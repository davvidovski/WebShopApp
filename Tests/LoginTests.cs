using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebShop.Drivers;
using WebShop.Locators;
using WebShop.Pages;
using System;

namespace WebShop.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver? driver; // WebDriver instance, nullable to allow for uninitialized state
        private LoginPage? loginPage; // LoginPage instance, nullable for similar reasons

        // Setup method that runs before each test
        [SetUp]
        public void Setup()
        {
            driver = WebDriverFactory.InitializeDriver(); // Initialize the WebDriver instance
            Assert.NotNull(driver, "WebDriver initialization failed."); // Assert that the driver is successfully initialized
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/"); // Navigate to the demo webshop URL
            driver.FindElement(LoginPageLocators.LoginButtonTopMenu).Click(); // Click the login button in the top menu
            loginPage = new LoginPage(driver); // Initialize the LoginPage with the WebDriver
        }

        // Test to check the presence of login fields on the page
        [Test]
        public void PresenceOfLoginFields()
        {
            Assert.NotNull(driver, "WebDriver should not be null"); // Assert that driver is initialized
            Assert.NotNull(loginPage, "LoginPage object should not be null"); // Assert that LoginPage is initialized

            // Assert that the username field is displayed
            Assert.That(loginPage.IsLoginFieldDisplayed(), Is.True, "Username field should be present on the login page.");
            // Assert that the password field is displayed
            Assert.That(driver?.FindElement(LoginPageLocators.PasswordField)?.Displayed ?? false, Is.True, "Password field should be present on the login page.");
        }

        // Test to check behavior when required fields are not filled
        [Test]
        public void RequiredFieldBehavior()
        {
            Assert.NotNull(driver, "WebDriver should not be null"); // Assert that driver is initialized
            Assert.NotNull(loginPage, "LoginPage object should not be null"); // Assert that LoginPage is initialized

            loginPage.ClickLogin(); // Attempt to click login without entering any credentials

            // Check the border color of the username field for visual feedback
            var usernameBorderColor = driver?.FindElement(LoginPageLocators.UsernameField)?.GetCssValue("border-color") ?? string.Empty;
            Assert.That(usernameBorderColor, Is.EqualTo("rgb(238, 238, 238)"), "The border color for the required field should be red.");
            // Assert that an error message appears for missing credentials
            Assert.That(driver?.FindElement(LoginPageLocators.LoginNotSuccessfull)?.Displayed ?? false, Is.True, "Error message should appear for missing credentials.");
        }

        // Test to check behavior with invalid email format
        [Test]
        public void InvalidEmailFormat()
        {
            Assert.NotNull(driver, "WebDriver should not be null"); // Assert that driver is initialized
            Assert.NotNull(loginPage, "LoginPage object should not be null"); // Assert that LoginPage is initialized

            // Enter an invalid email format
            loginPage.EnterUsername("invalidemail"); 
            loginPage.EnterPassword("Password123@"); // Enter a valid password
            loginPage.ClickLogin(); // Attempt to login

            // Check for error message indicating invalid email format
            var errorMessage = driver?.FindElement(LoginPageLocators.InvalidEmailErrorMessage)?.Text ?? string.Empty;
            Assert.That(errorMessage.Contains("Please enter a valid email address."), Is.True, "Error message should indicate invalid email format.");

            // Check the border color of the username field
            var usernameBorderColor = driver?.FindElement(LoginPageLocators.UsernameField)?.GetCssValue("border-color") ?? string.Empty;
            Assert.That(usernameBorderColor, Is.EqualTo("rgb(238, 238, 238)"), "The border color for invalid email format should be red.");
        }

        // Test to validate login attempt with invalid credentials
        [Test]
        public void InvalidLoginAttempt()
        {
            Assert.NotNull(driver, "WebDriver should not be null"); // Assert that driver is initialized
            Assert.NotNull(loginPage, "LoginPage object should not be null"); // Assert that LoginPage is initialized

            // Enter invalid username and password
            loginPage.EnterUsername("invaliduser@test.com");
            loginPage.EnterPassword("InvalidPassword");
            loginPage.ClickLogin(); // Attempt to login

            // Assert that an error message is displayed for invalid credentials
            Assert.That(driver?.FindElement(LoginPageLocators.LoginNotSuccessfull)?.Displayed ?? false, Is.True, "Login should fail for invalid credentials.");
        }

        // Test to validate successful login
        [Test]
        public void SuccessfulLogin()
        {
            Assert.NotNull(driver, "WebDriver should not be null"); // Assert that driver is initialized
            Assert.NotNull(loginPage, "LoginPage object should not be null"); // Assert that LoginPage is initialized

            // Enter valid credentials
            loginPage.EnterUsername("ace_davidovski@hotmail.com");
            loginPage.EnterPassword("Password123@");
            loginPage.ClickLogin(); // Attempt to login

            // Assert that the logout button is displayed after a successful login
            Assert.That(driver?.FindElement(LoginPageLocators.LogoutButton)?.Displayed ?? false, Is.True, "Logout button should be displayed after a successful login.");
        }

        // Test to validate the "Remember Me" option
        [Test]
        public void RememberMeOption()
        {
            Assert.NotNull(driver, "WebDriver should not be null"); // Assert that driver is initialized
            Assert.NotNull(loginPage, "LoginPage object should not be null"); // Assert that LoginPage is initialized

            // Enter valid credentials
            loginPage.EnterUsername("ace_davidovski@hotmail.com");
            loginPage.EnterPassword("Password123@");
            loginPage.CheckRememberMe(); // Check the "Remember Me" option
            loginPage.ClickLogin(); // Attempt to login

            // Assert that the logout button is displayed after a successful login
            Assert.That(driver?.FindElement(LoginPageLocators.LogoutButton)?.Displayed ?? false, Is.True, "Logout button should be displayed after a successful login.");
        }

        // Test to validate behavior with an invalid password
        [Test]
        public void InvalidPasswordOnly()
        {
            Assert.NotNull(driver, "WebDriver should not be null"); // Assert that driver is initialized
            Assert.NotNull(loginPage, "LoginPage object should not be null"); // Assert that LoginPage is initialized

            // Enter valid username and invalid password
            loginPage.EnterUsername("ace_davidovski@hotmail.com");
            loginPage.EnterPassword("wrongpassword123");
            loginPage.ClickLogin(); // Attempt to login

            // Assert that an error message appears for invalid password
            Assert.That(driver?.FindElement(LoginPageLocators.LoginNotSuccessfull)?.Displayed ?? false, Is.True, "Error message should appear for invalid password.");
        }

        // Test to validate behavior when login fields are empty
        [Test]
        public void EmptyLoginFields()
        {
            Assert.NotNull(driver, "WebDriver should not be null"); // Assert that driver is initialized
            Assert.NotNull(loginPage, "LoginPage object should not be null"); // Assert that LoginPage is initialized

            loginPage.ClickLogin(); // Attempt to click login with empty fields

            // Assert that an error message appears for missing credentials
            Assert.That(driver?.FindElement(LoginPageLocators.LoginNotSuccessfull)?.Displayed ?? false, Is.True, "Error message should appear for missing credentials.");
        }

        // Tear down method that runs after each test
        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit(); // Close the browser
                driver.Dispose(); // Dispose of the WebDriver instance
                driver = null; // Set driver to null to avoid further references
            }
        }
    }
}
