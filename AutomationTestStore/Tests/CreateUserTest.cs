using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using AutomationTestStore.Pages;

namespace AutomationTestStore.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Create User Tests")]
    public class CreateUserTest : BaseTests
    {
        [Test(Description = "Create a new user account")]
        [AllureTag("Registation", "Positive")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void CreateNewUserAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.ClickOnRegistrationContinueButton();

            accountRegistrationPage.EnterMandatoryPersonalDetails("Playi", "Doe", "teoaccount@gmail.com");
            accountRegistrationPage.EnterNonMandatoryPersonalDetails("1234567890", "098765432");

            accountRegistrationPage.EnterNonMandatoryAddressDetails("My Company", "Suite 100", "South Africa");
            accountRegistrationPage.EnterMandatoryAddressDetails("123 Main St", "Johannesburg", "Gauteng", "2154");

            accountRegistrationPage.EnterLoginDetails("PlayoinTeam", "SecurePassword123");

            accountRegistrationPage.SelectNewsletterSubscription(true);

            accountRegistrationPage.AgreeToTermsAndConditions();

            accountRegistrationPage.ClickContinueButton();

            var successMessage = accountRegistrationPage.GetRegistrationSuccessMessage();
            try
            {
                Assert.That(successMessage, Does.Contain("Congratulations! Your new account has been successfully created!"));
                Logs.Info("User account created successfully and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }

        [Test(Description = "Create a user account using exisiting user details")]
        [AllureTag("Registation", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void CreateExisitngUserAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.ClickOnRegistrationContinueButton();

            accountRegistrationPage.EnterMandatoryPersonalDetails("Playig", "Doe", "tepopaccount@gmail.com");
            accountRegistrationPage.EnterNonMandatoryPersonalDetails("1234567890", "098765432");

            accountRegistrationPage.EnterNonMandatoryAddressDetails("My Company", "Suite 100", "South Africa");
            accountRegistrationPage.EnterMandatoryAddressDetails("123 Main St", "Johannesburg", "Gauteng", "2154");

            accountRegistrationPage.EnterLoginDetails("PlayinTeam", "SecurePassword123");

            accountRegistrationPage.SelectNewsletterSubscription(false);

            accountRegistrationPage.AgreeToTermsAndConditions();

            accountRegistrationPage.ClickContinueButton();

            var failureMessage = accountRegistrationPage.GetRegistrationFailureMessage();
            try
            {
                Assert.That(failureMessage, Does.Contain("This login name is not available. Try different login name!"));
                Logs.Info("Alert message appeared informing login is not available");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }
    }
}
