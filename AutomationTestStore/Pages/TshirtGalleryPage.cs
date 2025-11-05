using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class TshirtGalleryPage : PageObjects
    {
        #region Private Fields
        private By tShirtPageTitle = By.CssSelector("#maincontainer > div > div > div > h1 > span.maintext");
        private By tShirtProductTile = By.CssSelector("#maincontainer > div > div > div > div > div.thumbnails.grid.row.list-inline > div:nth-child(4) > div.thumbnail > a > img");
        private By tShirtAddToCartButton = By.CssSelector("#maincontainer > div > div > div > div > div.thumbnails.grid.row.list-inline > div:nth-child(4) > div.thumbnail > div.pricetag.jumbotron > a > i");
        #endregion

        #region Constructor
        public TshirtGalleryPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public string GetTShirtPageTitle()
        {
            Logs.Step("Getting T-Shirt Page Title");
            return GetText(tShirtPageTitle);
        }
        public void ClickOnTShirtProductTile()
        {
            Logs.Step("Clicking on T-Shirt Product Tile");
            Click(tShirtProductTile);
        }
        public void ClickOnAddToCartButton()
        {
            Logs.Step("Clicking on Add to Cart Button for T-Shirt");
            Click(tShirtAddToCartButton);
        }
        #endregion
    }
}
