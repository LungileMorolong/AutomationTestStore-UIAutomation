using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using AutomationTestStore.Pages;

namespace AutomationTestStore.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("User Login")]
    public class LoginTest : BaseTests
    {
        [Test(Description = "User login into account")]
        [AllureTag("Login", "Positive")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserLoginIntoAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails("PlayoinTeam", "SecurePassword123");
            accountLoginPage.ClickOnLoginButton();

            var welcomeText = myAccountPage.GetWelcomeBackText();
            try
            {
                Assert.That(welcomeText, Does.Contain($"Welcome back {"Playi"}"));
                Logs.Info("User logged in successfully and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }

        [Test(Description = "User login using invalid username")]
        [AllureTag("Login", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserLoginWithInvalidUserName()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails("PlayonTeam", "SecurePassword123");
            accountLoginPage.ClickOnLoginButton();

            var errorMessage = accountLoginPage.GetInvalidLoginWarningMessage();
            try
            {
                Assert.That(errorMessage, Does.Contain("Error: Incorrect login or password provided."));
                Logs.Info("The correct error message appear indicating invalid username or password was provided");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }

        [Test(Description = "User login using invalid password")]
        [AllureTag("Login", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserLoginWithInvalidPassword()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails("PlayoinTeam", "SecurePassword13");
            accountLoginPage.ClickOnLoginButton();

            var errorMessage = accountLoginPage.GetInvalidLoginWarningMessage();
            try
            {
                Assert.That(errorMessage, Does.Contain("Error: Incorrect login or password provided."));
                Logs.Info("The correct error message appear indicating invalid username or password was provided");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }
    }
}
