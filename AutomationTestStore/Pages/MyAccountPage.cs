using OpenQA.Selenium;


namespace AutomationTestStore.Pages
{
    public class MyAccountPage : PageObjects
    {
        #region Private Fields
        private By welcomeBackText = By.CssSelector("#customer_menu_top > li > a > div");
        private By resetPasswordButton = By.CssSelector("#maincontainer > div > div.col-md-9.col-xs-12.mt20 > div > ul > li:nth-child(2) > a");
        private By logoutLinkText = By.CssSelector("#maincontainer > div > div.column_right.col-md-3.col-xs-12.mt20 > div.sidewidt > div > ul > li:nth-child(10) > a");
        #endregion

        #region Constructor
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public string GetWelcomeBackText()
        {
            Logs.Step("Getting Welcome Back Text");
            return GetText(welcomeBackText);
        }
        public void ClickOnResetPasswordButton()
        {
            Logs.Step("Clicking on Reset Password Button");
            Click(resetPasswordButton);
        }
        public void ClickOnLogoutLinkText()
        {
            Logs.Step("Clicking on Logout Button");
            Click(logoutLinkText);
        }
        #endregion
    }
}
