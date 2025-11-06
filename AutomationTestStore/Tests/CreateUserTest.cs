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
        [AllureTag("Registation", "Positive")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void CreateNewUserAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);

            string filePath = Constants.TestDataFilePath;
            string sheetName = "Create User";

            string firstName = ExcelDataReader.ReadData(filePath, sheetName, "B2");
            string lastName = ExcelDataReader.ReadData(filePath, sheetName, "C2");
            string email = ExcelDataReader.ReadData(filePath, sheetName, "D2");
            string telephone = ExcelDataReader.ReadData(filePath, sheetName, "E2");
            string fax = ExcelDataReader.ReadData(filePath, sheetName, "F2");
            string company = ExcelDataReader.ReadData(filePath, sheetName, "G2");
            string address1 = ExcelDataReader.ReadData(filePath, sheetName, "H2");
            string address2 = ExcelDataReader.ReadData(filePath, sheetName, "I2");
            string city = ExcelDataReader.ReadData(filePath, sheetName, "J2");
            string region = ExcelDataReader.ReadData(filePath, sheetName, "K2");
            string zipCode = ExcelDataReader.ReadData(filePath, sheetName, "L2");
            string country = ExcelDataReader.ReadData(filePath, sheetName, "M2");
            string loginName = ExcelDataReader.ReadData(filePath, sheetName, "N2");
            string password = ExcelDataReader.ReadData(filePath, sheetName, "O2");
            string confirmPassword = ExcelDataReader.ReadData(filePath, sheetName, "P2");

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
        [AllureTag("Registation", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void CreateExistingUserAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            AccountRegistrationPage accountRegistrationPage = new AccountRegistrationPage(Driver);

            string filePath = Constants.TestDataFilePath;
            string sheetName = "Create User";

            string existingFirstName = ExcelDataReader.ReadData(filePath, sheetName, "B3");
            string existingLastName = ExcelDataReader.ReadData(filePath, sheetName, "C3");
            string existingEmail = ExcelDataReader.ReadData(filePath, sheetName, "D3");
            string existingTelephone = ExcelDataReader.ReadData(filePath, sheetName, "E3");
            string existingFax = ExcelDataReader.ReadData(filePath, sheetName, "F3");
            string existingCompany = ExcelDataReader.ReadData(filePath, sheetName, "G3");
            string existingAddress1 = ExcelDataReader.ReadData(filePath, sheetName, "H3");
            string existingAddress2 = ExcelDataReader.ReadData(filePath, sheetName, "I3");
            string existingCity = ExcelDataReader.ReadData(filePath, sheetName, "J3");
            string existingRegion = ExcelDataReader.ReadData(filePath, sheetName, "K3");
            string existingZipCode = ExcelDataReader.ReadData(filePath, sheetName, "L3");
            string existingCountry = ExcelDataReader.ReadData(filePath, sheetName, "M3");
            string existingLoginName = ExcelDataReader.ReadData(filePath, sheetName, "N3");
            string existingPassword = ExcelDataReader.ReadData(filePath, sheetName, "O3");
            string existingConfirmPassword = ExcelDataReader.ReadData(filePath, sheetName, "P3");

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
