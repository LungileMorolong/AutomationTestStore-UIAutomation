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
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

            string filePath = Constants.TestDataFilePath;
            string loginSheetName = "Login Details";
            string passwordChangeSheetName = "Password Change";

            string userName = ExcelDataReader.ReadData(filePath, loginSheetName, "C2");
            string currentPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "B2");
            string newPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "C2");
            string confirmNewPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "D2");

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails(userName, currentPassword);
            accountLoginPage.ClickOnLoginButton();

            myAccountPage.ClickOnResetPasswordButton();

            changePasswordPage.EnterCurrentAndNewPassword(currentPassword, newPassword, confirmNewPassword);
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
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

            string filePath = Constants.TestDataFilePath;
            string loginSheetName = "Login Details";
            string passwordChangeSheetName = "Password Change";

            string currentPasswordUserName = ExcelDataReader.ReadData(filePath, loginSheetName, "C5");
            string currentLoginPassword = ExcelDataReader.ReadData(filePath, loginSheetName, "D5");

            string invalidCurrentPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "B3");
            string newPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "C3");
            string confirmNewPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "D3");

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails(currentPasswordUserName, currentLoginPassword);
            accountLoginPage.ClickOnLoginButton();

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
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

            string filePath = Constants.TestDataFilePath;
            string loginSheetName = "Login Details";
            string passwordChangeSheetName = "Password Change";

            string confirmPasswordUserName = ExcelDataReader.ReadData(filePath, loginSheetName, "C5");
            string confirmLoginPassword = ExcelDataReader.ReadData(filePath, loginSheetName, "D5");

            string currentPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "B4");
            string newPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "C4");
            string invalidConfirmNewPassword = ExcelDataReader.ReadData(filePath, passwordChangeSheetName, "D4");

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails(confirmPasswordUserName, confirmLoginPassword);
            accountLoginPage.ClickOnLoginButton();

            myAccountPage.ClickOnResetPasswordButton();

            changePasswordPage.EnterCurrentAndNewPassword(currentPassword, newPassword, invalidConfirmNewPassword);
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
