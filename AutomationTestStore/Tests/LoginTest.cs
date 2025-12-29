using Allure.Commons;
using AutomationTestStore.Pages;
using AutomationTestStore.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationTestStore.Tests
{
    [TestFixture, Order(2)]
    [AllureNUnit]
    [AllureSuite("User Login")]
    public class LoginTest : BaseTests
    {
        [Test(Description = "User login into account"), Order(1)]
        [AllureTag("Login", "Positive")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserLoginIntoAccount()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);


            string firstName = JsonDataLoader.GetExistingUser().firstName;
            string userName = JsonDataLoader.GetExistingUser().loginName;
            string password = JsonDataLoader.GetExistingUser().password;

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails(userName, password);
            accountLoginPage.ClickOnLoginButton();

            var welcomeText = myAccountPage.GetWelcomeBackText();
            try
            {
                Assert.That(welcomeText, Does.Contain($"Welcome back {firstName}"));
                Logs.Info("User logged in successfully and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }

        [Test(Description = "User login using invalid username"), Order(2)]
        [AllureTag("Login", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserLoginWithInvalidUserName()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);

            string invalidLoginName = JsonDataLoader.GetExistingUser().invalidLoginName;
            string invalidLoginPassword = JsonDataLoader.GetExistingUser().invalidPassword;

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails(invalidLoginName, invalidLoginPassword);
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

        [Test(Description = "User login using invalid password"), Order(3)]
        [AllureTag("Login", "Negative")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("QA Team")]
        public void UserLoginWithInvalidPassword()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            MyAccountPage myAccountPage = new MyAccountPage(Driver);

            string invalidPasswordLoginName = JsonDataLoader.GetExistingUser().loginName;
            string invalidPassword = JsonDataLoader.GetExistingUser().invalidPassword;

            homePage.ClickOnLoginOrRegister();
            accountLoginPage.EnterLoginDetails(invalidPasswordLoginName, invalidPassword);
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
