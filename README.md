# AutomationTestStore UI Automation

Automated UI test suite for the Automation Test Store website

## Table of Contents

About

Features

Getting Started

Prerequisites

Installation & Setup

Running the Tests

Project Structure

Author

## About

This project provides an end-to-end UI automation test suite targeting the Automation Test Store application. It is designed to validate key user flows in the store such as product browsing, search, account creation/login, shopping cart, and more. It uses a modular framework to promote readability, maintainability, and reusability of test code.

## Features

Automated UI tests covering core user journeys

Page Object Model (POM) implementation to separate page-specific logic from test logic

Configurable environment settings

Clear reports of test results

Easily extensible for additional test cases / flows

## Getting Started

Follow these steps to get the project running on your local machine.

## Prerequisites

.NET (choose correct version, e.g. .NET 6/7)

A supported browser driver (e.g. EdgeOptions for Edge)

Visual Studio / VS Code (or your IDE of choice)

Internet access to the Test Store site (or local version if applicable)

## Installation & Setup

### Clone the repository:

git clone https://github.com/LungileMorolong/AutomationTestStore-UIAutomation.git  
cd AutomationTestStore-UIAutomation/AutomationTestStore  


### Restore dependencies:

dotnet restore   # or your build command  


### Configure test settings:

Adjust appsettings.json or similar config file to set baseUrl, etc.

Ensure the required browser driver is available in PATH or the configured location.

## Running the Tests

To run all tests:

dotnet test   # or the command defined in the project  


To run a specific test suite or category:

dotnet test --filter Category=Smoke   # example  


Test results output will be generated under the allure-results folder.

## Project Structure
```
/AutomationTestStore
│
├── /Data               # Contains the TestData json file
├── /Pages              # Page object classes representing UI pages
├── /Tests              # Test classes implementing scenarios
├── /Utils              # Contains JsonData, JsonDataLoader, and CredentialGenerator class
├── appsettings.json    # Configuration file for environments, browsers, etc.
├── WebDriverFactory.cs # IWebDriver class to create the Edge driver
├── BaseTests.cs        # Base class that contains the SetUp and TearDown NUnit Fixture
├── Constants.cs        # Central Configuration Holder
├── StartUpTests.cs     # NUnit setup fixture which runs the code once before tests are executed
├── Logs.cs             # Class used for logging messages during execution
├── AutomationTestStore.sln  # Solution file
└── README.md
```

Pages: Each page class encapsulates locators + actions for that page.

Tests: Contains test methods grouped by feature (e.g., checkout, login).

## Author

Lungile Morolong – [GitHub Profile](https://github.com/LungileMorolong/)
