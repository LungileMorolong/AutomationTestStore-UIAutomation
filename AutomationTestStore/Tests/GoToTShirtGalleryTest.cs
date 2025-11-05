using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using AutomationTestStore.Pages;

namespace AutomationTestStore.Tests
{
    [TestFixture]
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

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails("PlayoinTeam", "Newwording");
            accountLoginPage.ClickOnLoginButton();            
            
            homePage.SelectTShirtFromApprealAndAccessoriesMenu();

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
