using Allure.Commons;
using AutomationTestStore.Pages;
using AutomationTestStore.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationTestStore.Tests
{
    [TestFixture, Order(4)]
    [AllureNUnit]
    [AllureSuite("Logout Test")]
    public class LogOutTest : BaseTests
    {
        [Test(Description = "User logout from account")]
        [AllureTag("Logout", "Positive")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserLogoutFromAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);
            LogoutPage logoutPage = new LogoutPage(Driver);

            string userName = JsonDataLoader.GetExistingUser().loginName;
            string loginPassword = JsonDataLoader.GetExistingUser().password;

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails(userName, loginPassword);
            accountLoginPage.ClickOnLoginButton();
            myAccountPage.ClickOnLogoutLinkText();

            var logoutMessage = logoutPage.GetLogoutMessage();
            try
            {
                Assert.That(logoutMessage, Does.Contain("You have been logged off your account. It is now safe to leave the computer."));
                Logs.Info("User logged out successfully and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }

            logoutPage.ClickOnContinueButton();

            var homeLoginOrRegistationText = homePage.GetLoginOrRegisterText();

            try
            {
                Assert.That(homeLoginOrRegistationText, Does.Contain("Login or register"));
                Logs.Info("User is navigated back to home page after logout and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }


        }
    }
}
