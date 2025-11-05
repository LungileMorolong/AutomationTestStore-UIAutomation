using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using AutomationTestStore.Pages;

namespace AutomationTestStore.Tests
{
    [TestFixture]
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

            homePage.ClickOnLoginOrRegister();

            accountLoginPage.EnterLoginDetails("PlayoinTeam", "Newwording");
            accountLoginPage.ClickOnLoginButton();

            homePage.SelectTShirtFromApprealAndAccessoriesMenu();

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
