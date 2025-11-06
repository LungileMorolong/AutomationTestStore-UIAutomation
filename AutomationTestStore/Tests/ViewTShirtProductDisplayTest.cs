using Allure.Commons;
using AutomationTestStore.Pages;
using AutomationTestStore.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationTestStore.Tests
{
    [TestFixture, Order(6)]
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

            string filePath = Constants.TestDataFilePath;
            string loginSheetName = "Login Details";

            string userName = ExcelDataReader.ReadData(filePath, loginSheetName, "C5");
            string loginPassword = ExcelDataReader.ReadData(filePath, loginSheetName, "D5");

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails(userName, loginPassword);
            accountLoginPage.ClickOnLoginButton();

            homePage.SelectTShirtFromApparelAndAccessoriesMenu();

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
