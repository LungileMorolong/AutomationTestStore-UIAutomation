using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class ShoppingCartPage : PageObjects
    {
        #region Private Fields
        private By productName = By.CssSelector("#cart > div > div.container-fluid.cart-info.product-list > table > tbody > tr:nth-child(2) > td:nth-child(2) > a");
        private By quantityNumber = By.CssSelector("#cart_quantity123d4ba17727b9155709742d2033b6e8e11");
        #endregion

        #region Constructor
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public string GetProductName()
        {
            Logs.Step("Getting Product Name");
            return GetText(productName);
        }
        public int GetQuantityNumber()
        {
            Logs.Step("Getting Quantity Number");
            string quantityText = GetAttribute(quantityNumber, "value");
            return int.Parse(quantityText);
        }
        #endregion


    }
}
