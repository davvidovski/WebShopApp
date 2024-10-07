# WebShop Automation

This project automates the login page testing for WebShop App using Selenium and NUnit in C#.

## Prerequisites

- .NET SDK 8.0
- Chrome browser
- ChromeDriver that suits your Chrome Browser (ensure it is available in your PATH or specify its location in the WebDriverFactory.cs)

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/davvidovski/WebShopApp.git
   cd WebShopApp

2. Restore the project dependencies (this will automatically install NUnit, Selenium, and other required packages): 
    ```bash
    dotnet restore

3. Run the tests:
   ```bash
    dotnet test

## Folder Breakdown

- `/Drivers`: Contains the WebDriver setup (currently for Chrome).
- `/Pages`: Implements the Page Object Model for the login page.
- `/Tests`: Contains NUnit test cases for the login page.

## CI/CD Integration

If using GitHub Actions or another CI/CD system, make sure your pipeline includes the following steps:

- Install .NET SDK 8.0 or higher
- Install Chrome and ChromeDriver
- Run the tests using the dotnet test command

Refer to .github/workflows/ci.yml (or equivalent) for more details.

## Extending the Tests

To add more tests, follow the Page Object Model (POM) structure for better maintainability. Create new Page Objects in the /Pages folder and corresponding test cases in the /Tests folder.
