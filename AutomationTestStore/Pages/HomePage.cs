using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class HomePage : PageObjects
    {
        #region Private Fields
        private By homeMenuOption = By.CssSelector("#categorymenu > nav > ul > li:nth-child(1) > a");
        private By apprealAndAccessoriesMenuOption = By.CssSelector("#categorymenu > nav > ul > li:nth-child(2) > a");
        private By tshirtDropDownOption = By.CssSelector("#categorymenu > nav > ul > li:nth-child(2) > div > ul:nth-child(1) > li:nth-child(2) > a");
        private By loginOrRegister = By.CssSelector("#customer_menu_top > li > a");
        private By viewCartButton = By.CssSelector("#main_menu_top > li:nth-child(3) > a > span");
        #endregion

        #region Constructor
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public void ClickOnHomeMenuOption()
        {
            Logs.Step("Clicking on Home Menu Option");
            Click(homeMenuOption);
        }

        public void SelectTShirtFromApprealAndAccessoriesMenu()
        {
            Logs.Step("Selecting T-Shirt from Appreal and Accessories Menu");
            HoverAndSelectDropdown(apprealAndAccessoriesMenuOption, tshirtDropDownOption);
        }

        public void ClickOnLoginOrRegister()
        {
            Logs.Step("Clicking on Login or Register");
            Click(loginOrRegister);
        }

        public string GetLoginOrRegisterText()
        {
            Logs.Step("Getting Login or Register Text");
            return GetText(loginOrRegister);
        }

        public void ClickOnViewCartButton()
        {
            Logs.Step("Clicking on View Cart Button");
            Click(viewCartButton);
        }
        #endregion
    }
}
