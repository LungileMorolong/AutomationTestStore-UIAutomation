using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using AutomationTestStore.Pages;
using AutomationTestStore.Utils;


namespace AutomationTestStore.Tests
{
    [TestFixture, Order(1)]
    [AllureNUnit]
    [AllureSuite("Create User Tests")]
    public class CreateUserTest : BaseTests
    {
        [Test(Description = "Create a new user account"), Order(1)]
        [AllureTag("Registration", "Positive")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void CreateNewUserAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);

            string firstName = JsonDataLoader.GetNewUser().firstName;
            string lastName = JsonDataLoader.GetNewUser().lastName;
            string email = CredentialGenerator.GenerateRandomEmail();
            string telephone = JsonDataLoader.GetNewUser().telephone;
            string fax = JsonDataLoader.GetNewUser().fax;
            string company = JsonDataLoader.GetNewUser().company;
            string address1 = JsonDataLoader.GetNewUser().address1;
            string address2 = JsonDataLoader.GetNewUser().address2;
            string city = JsonDataLoader.GetNewUser().city;
            string region = JsonDataLoader.GetNewUser().region;
            string zipCode = JsonDataLoader.GetNewUser().postalCode;
            string country = JsonDataLoader.GetNewUser().country;
            string loginName = CredentialGenerator.GenerateRandomUsername();
            string password = CredentialGenerator.GenerateRandomPassword();
            string confirmPassword = password;

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.ClickOnRegistrationContinueButton();

            accountRegistrationPage.EnterMandatoryPersonalDetails(firstName, lastName, email);
            accountRegistrationPage.EnterNonMandatoryPersonalDetails(telephone, fax);

            accountRegistrationPage.EnterNonMandatoryAddressDetails(company, address2, country);
            accountRegistrationPage.EnterMandatoryAddressDetails(address1, city, region, zipCode);

            accountRegistrationPage.EnterLoginDetails(loginName, password, confirmPassword);

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

        [Test(Description = "Create a user account using exisiting user details"), Order(2)]
        [AllureTag("Registration", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void CreateExistingUserAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);


            string existingFirstName = JsonDataLoader.GetExistingUser().firstName;
            string existingLastName = JsonDataLoader.GetExistingUser().lastName;
            string existingEmail = CredentialGenerator.GenerateRandomEmail();
            string existingTelephone = JsonDataLoader.GetExistingUser().telephone;
            string existingFax = JsonDataLoader.GetExistingUser().fax;
            string existingCompany = JsonDataLoader.GetExistingUser().company;
            string existingAddress1 = JsonDataLoader.GetExistingUser().address1;
            string existingAddress2 = JsonDataLoader.GetExistingUser().address2;
            string existingCity = JsonDataLoader.GetExistingUser().city;
            string existingRegion = JsonDataLoader.GetExistingUser().region;
            string existingZipCode = JsonDataLoader.GetExistingUser().postalCode;
            string existingCountry = JsonDataLoader.GetExistingUser().country;
            string existingLoginName = JsonDataLoader.GetExistingUser().loginName;
            string existingPassword = JsonDataLoader.GetExistingUser().password;
            string existingConfirmPassword = JsonDataLoader.GetExistingUser().confirmPassword;

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.ClickOnRegistrationContinueButton();

            accountRegistrationPage.EnterMandatoryPersonalDetails(existingFirstName, existingLastName, existingEmail);
            accountRegistrationPage.EnterNonMandatoryPersonalDetails(existingTelephone, existingFax);

            accountRegistrationPage.EnterNonMandatoryAddressDetails(existingCompany, existingAddress2, existingCountry);
            accountRegistrationPage.EnterMandatoryAddressDetails(existingAddress1, existingCity, existingRegion, existingZipCode);

            accountRegistrationPage.EnterLoginDetails(existingLoginName, existingPassword, existingConfirmPassword);

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
