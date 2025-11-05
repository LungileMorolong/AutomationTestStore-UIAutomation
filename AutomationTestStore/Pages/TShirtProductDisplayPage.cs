using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class TShirtProductDisplayPage : PageObjects
    {

        #region Private Fields
        private By tShirtProductTitle = By.CssSelector("#product_details > div > div:nth-child(2) > div > div > h1 > span");
        private By addToCartButton = By.CssSelector("#product > fieldset > div:nth-child(6) > ul > li > a");
        #endregion

        #region Constructor
        public TShirtProductDisplayPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public string GetTShirtProductTitle()
        {
            Logs.Step("Getting T-Shirt Page Title");
            return GetText(tShirtProductTitle);
        }
        public void ClickOnAddToCartButton()
        {
            Logs.Step("Clicking on Add to Cart Button");
            Click(addToCartButton);
        }
        #endregion
    }
}
