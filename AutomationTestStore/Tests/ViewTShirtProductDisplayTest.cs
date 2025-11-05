using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using AutomationTestStore.Pages;

namespace AutomationTestStore.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Go to T-Shirt Product Display")]
    public class ViewTShirtProductDisplayTest : BaseTests
    {
        [Test(Description = "User to navigate to T-Shirt product display")]
        [AllureTag("T-Shirt Product Display", "Positive")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("QA Team")]
        public void UserNavigatesToTShirtProductDisplay()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            TshirtGalleryPage tshirtGalleryPage = new TshirtGalleryPage(Driver);
            TShirtProductDisplayPage tShirtProductDisplayPage = new TShirtProductDisplayPage(Driver);

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails("PlayoinTeam", "Newwording");
            accountLoginPage.ClickOnLoginButton();

            homePage.SelectTShirtFromApprealAndAccessoriesMenu();

            tshirtGalleryPage.ClickOnTShirtProductTile();

            var tShirtProductTitle = tShirtProductDisplayPage.GetTShirtProductTitle();

            try
            {
                Assert.That(tShirtProductTitle, Does.Contain("Casual 3/4 Sleeve Baseball T-Shirt"));
                Logs.Info("User navigated to T-Shirt Product Display successfully and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }
    }
}
