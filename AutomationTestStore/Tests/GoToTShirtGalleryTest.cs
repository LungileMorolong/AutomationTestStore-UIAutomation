using Allure.Commons;
using AutomationTestStore.Pages;
using AutomationTestStore.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationTestStore.Tests
{
    [TestFixture, Order(5)]
    [AllureNUnit]
    [AllureSuite("Go to T-Shirt Gallery")]
    public class GoToTShirtGalleryTest : BaseTests
    {
        [Test(Description = "User to navigate to T-Shirt Gallery")]
        [AllureTag("T-Shirt Gallery", "Positive")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("QA Team")]
        public void UserNavigatesToTShirtGallery()
        {

            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            TshirtGalleryPage tshirtGalleryPage = new TshirtGalleryPage(Driver);

            string userName = JsonDataLoader.GetExistingUser().loginName;
            string loginPassword = JsonDataLoader.GetExistingUser().password;

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails(userName, loginPassword);
            accountLoginPage.ClickOnLoginButton();            
            
            homePage.SelectTShirtFromApparelAndAccessoriesMenu();

            var tShirtPageTitle = tshirtGalleryPage.GetTShirtPageTitle();
            try
            {
                Assert.That(tShirtPageTitle, Does.Contain("T-SHIRTS"));
                Logs.Info("User navigated to T-Shirt Gallery successfully and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }
    }
}
