using Allure.Commons;
using AutomationTestStore.Pages;
using AutomationTestStore.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationTestStore.Tests
{
    [TestFixture, Order(3)]
    [AllureNUnit]
    [AllureSuite("Change Password Test")]
    public class ChangePasswordTest : BaseTests
    {
        [Test(Description = "User changes their account password"), Order(1)]
        [AllureTag("ChangePassword", "Positive")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserChangesAccountPassword()
        {

            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

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
            string newPassword = CredentialGenerator.GenerateRandomPassword();
            string confirmNewPassword = newPassword;

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

            accountRegistrationPage.ClickAccountContinueButton();

            myAccountPage.ClickOnResetPasswordButton();

            changePasswordPage.EnterCurrentAndNewPassword(password, newPassword, confirmNewPassword);
            changePasswordPage.ClickOnContinueButton();

            var passwordChangeMessage = myAccountPage.GetPasswordChangeSuccessMessage();
            try
            {
                Assert.That(passwordChangeMessage, Does.Contain("Success: Your password has been successfully updated."));
                Logs.Info("User changed password successfully and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }

        [Test(Description = "User inputs invalid current account password"), Order(2)]
        [AllureTag("ChangePassword", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserInputsInvalidCurrentPassword()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

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
            string invalidCurrentPassword = CredentialGenerator.GenerateRandomPassword();
            string newPassword = CredentialGenerator.GenerateRandomPassword();
            string confirmNewPassword = newPassword;

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

            accountRegistrationPage.ClickAccountContinueButton();

            myAccountPage.ClickOnResetPasswordButton();

            changePasswordPage.EnterCurrentAndNewPassword(invalidCurrentPassword, newPassword, confirmNewPassword);
            changePasswordPage.ClickOnContinueButton();

            var invalidPasswordErrorMessage = changePasswordPage.GetInvalidPasswordErrorMessage();
            try
            {
                Assert.That(invalidPasswordErrorMessage, Does.Contain("Your current password is incorrect! Please try again."));
                Logs.Info("The correct error message appear indicating invalid current password was provided");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }

        [Test(Description = "User inputs invalid confirm password"), Order(3)]
        [AllureTag("ChangePassword", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserInputInvalidConfirmPassword()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

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
            string newPassword = CredentialGenerator.GenerateRandomPassword();
            string invalidConfirmNewPassword = CredentialGenerator.GenerateRandomPassword();

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

            accountRegistrationPage.ClickAccountContinueButton();

            myAccountPage.ClickOnResetPasswordButton();

            changePasswordPage.EnterCurrentAndNewPassword(password, newPassword, invalidConfirmNewPassword);
            changePasswordPage.ClickOnContinueButton();

            var passwordMismatchErrorMessage = changePasswordPage.GetPasswordMismatchErrorMessage();
            try
            {
                Assert.That(passwordMismatchErrorMessage, Does.Contain("Password confirmation does not match password!"));
                Logs.Info("The correct error message appear indicating password mismatch.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }
    }
}
