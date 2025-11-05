using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using AutomationTestStore.Pages;

namespace AutomationTestStore.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Change Password Test")]
    public class ChangePasswordTest : BaseTests
    {
        [Test(Description = "User changes their account password")]
        [AllureTag("ChangePassword", "Positive")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserChangesAccountPassword()
        {

            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails("PlayoinTeam", "wording");
            accountLoginPage.ClickOnLoginButton();

            myAccountPage.ClickOnResetPasswordButton();

            changePasswordPage.EnterCurrentAndNewPassword("wording", "Newwording", "Newwording");
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

        [Test(Description = "User inputs invalid current account password")]
        [AllureTag("ChangePassword", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserInputsInvalidCurrentPassword()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails("PlayoinTeam", "Newwording");
            accountLoginPage.ClickOnLoginButton();

            myAccountPage.ClickOnResetPasswordButton();

            changePasswordPage.EnterCurrentAndNewPassword("wrongcurrentpassword", "AnotherNewwording", "AnotherNewwording");
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

        [Test(Description = "User inputs invalid confirm password")]
        [AllureTag("ChangePassword", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserInputInvalidConfirmPassword()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(Driver);

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails("PlayoinTeam", "Newwording");
            accountLoginPage.ClickOnLoginButton();

            myAccountPage.ClickOnResetPasswordButton();

            changePasswordPage.EnterCurrentAndNewPassword("Newwording", "MismatchedPassword1", "MismatchedPassword2");
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
