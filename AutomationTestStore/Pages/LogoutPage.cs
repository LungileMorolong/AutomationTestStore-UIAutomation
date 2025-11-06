using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class LogoutPage : PageObjects
    {
        #region Private Fields
        private By logoutMessage = By.CssSelector("#maincontainer > div > div > div > div > section > p:nth-child(3)");
        private By continueButton = By.CssSelector("#maincontainer > div > div > div > div > section > a");
        #endregion

        #region Constructor
        public LogoutPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public string GetLogoutMessage()
        {
            Logs.Step("Getting Logout Message");
            return GetText(logoutMessage);
        }

        public void ClickOnContinueButton()
        {
            Logs.Step("Clicking on Continue Button");
            Click(continueButton);
        }
        #endregion
    }
}
