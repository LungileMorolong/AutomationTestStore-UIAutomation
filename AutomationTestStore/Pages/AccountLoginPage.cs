using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class AccountLoginPage : PageObjects
    {
        #region Private Fields
        private By registrationContinueButton = By.CssSelector("#accountFrm > fieldset > button");
        private By loginNameInputField = By.Id("loginFrm_loginname");
        private By passwordInputField = By.Id("loginFrm_password");
        private By loginButton = By.CssSelector("#loginFrm > fieldset > button");
        private By forgotPasswordLink = By.CssSelector("#loginFrm > fieldset > a:nth-child(3)");
        private By forgotYourLoginLink = By.CssSelector("#loginFrm > fieldset > a:nth-child(4)");
        private By invalidLoginWarningMessage = By.CssSelector("#maincontainer > div > div > div > div.alert.alert-error.alert-danger");
        #endregion

        #region Constructor
        public AccountLoginPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public void ClickOnRegistrationContinueButton()
        {
            Logs.Step("Clicking on Registration Continue Button");
            Click(registrationContinueButton);
        }

        public void EnterLoginDetails(string loginName, string password)
        {
            Logs.Step($"Entering Login Name: {loginName}");
            ClearAndSendKeys(loginNameInputField, loginName);
            Logs.Step("Entering Password");
            ClearAndSendKeys(passwordInputField, password);
        }

        public void ClickOnLoginButton()
        {
            Logs.Step("Clicking on Login Button");
            Click(loginButton);
        }

        public void ClickOnForgotPasswordLink()
        {
            Logs.Step("Clicking on Forgot Password Link");
            Click(forgotPasswordLink);
        }

        public void ClickOnForgotYourLoginLink()
        {
            Logs.Step("Clicking on Forgot Your Login Link");
            Click(forgotYourLoginLink);
        }

        public string GetInvalidLoginWarningMessage()
        {
            Logs.Step("Getting Invalid Login Warning Message");
            return GetText(invalidLoginWarningMessage);
        }
        #endregion
    }
}
