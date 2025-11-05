using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using AutomationTestStore.Pages;

namespace AutomationTestStore.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Go to cart to view added T-Shirt")]
    public class AddTShirtToCartTest : BaseTests
    {
        [Test(Description = "User to navigate to cart to view added T-Shirt product")]
        [AllureTag("Cart", "Positive")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("QA Team")]
        public void UserNavigatesToCartToViewAddedTShirtProduct()
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

            var productNameInCart = shoppingCartPage.GetProductName();
            var quantityInCart = shoppingCartPage.GetQuantityNumber();

            try
            {
                Assert.That(productNameInCart, Does.Contain("Casual 3/4 Sleeve Baseball T-Shirt"));
                Assert.That(quantityInCart, Is.EqualTo(1));
                Logs.Info("User navigated to cart and verified added T-Shirt product successfully.");
            }
            catch (AssertionException ex)
            {
                Logs.Info($"Assertion failed: {ex.Message}");
                throw;
            }
        }
    }
}
