using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class ShoppingCartPage : PageObjects
    {
        #region Private Fields
        private By productName = By.CssSelector("#cart > div > div.container-fluid.cart-info.product-list > table > tbody > tr:nth-child(2) > td:nth-child(2) > a");
        private By quantityNumber = By.CssSelector("#cart_quantity1232b2351e536ad293222b586fbf65d778f");
        private By removeButton = By.CssSelector("#cart > div > div.container-fluid.cart-info.product-list > table > tbody > tr:nth-child(2) > td:nth-child(7) > a");
        private By emptyCartMessage = By.CssSelector("#maincontainer > div > div > div > div");
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
        public void ClickOnRemoveButton()
        {
            Logs.Step("Clicking on Remove Button");
            Click(removeButton);
        }
        public string GetEmptyCartMessage()
        {
            Logs.Step("Getting Empty Cart Message");
            return GetText(emptyCartMessage);
        }
        #endregion


    }
}
