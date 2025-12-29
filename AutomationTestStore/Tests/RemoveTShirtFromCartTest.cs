using Allure.Commons;
using AutomationTestStore.Pages;
using AutomationTestStore.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationTestStore.Tests
{
    [TestFixture, Order(8)]
    [AllureNUnit]
    [AllureSuite("Remove added T-Shirt from cart")]
    public class RemoveTShirtFromCartTest : BaseTests
    {
        [Test(Description = "User to removed added T-Shirt from cart")]
        [AllureTag("Cart", "Positive")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("QA Team")]
        public void UserRemovesAddedTShirtFromCart()
        {
            HomePage homePage = new HomePage(Driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(Driver);
            TshirtGalleryPage tshirtGalleryPage = new TshirtGalleryPage(Driver);
            TShirtProductDisplayPage tShirtProductDisplayPage = new TShirtProductDisplayPage(Driver);
            ShoppingCartPage shoppingCartPage = new ShoppingCartPage(Driver);

            string userName = JsonDataLoader.GetExistingUser().loginName;
            string loginPassword = JsonDataLoader.GetExistingUser().password;

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails(userName, loginPassword);
            accountLoginPage.ClickOnLoginButton();

            homePage.SelectTShirtFromApparelAndAccessoriesMenu();

            tshirtGalleryPage.ClickOnTShirtProductTile();

            tShirtProductDisplayPage.ClickOnAddToCartButton();

            shoppingCartPage.ClickOnRemoveButton();

            var emptyCartMessage = shoppingCartPage.GetEmptyCartMessage();
            try
            {
                Assert.That(emptyCartMessage, Does.Contain("Your shopping cart is empty!"));
                Logs.Info("User removed added T-Shirt from cart successfully and verified.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }
    }
}
