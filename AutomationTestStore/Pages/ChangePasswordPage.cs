using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class ChangePasswordPage : PageObjects
    {
        #region Private Fields
        private By currentPasswordField = By.Id("PasswordFrm_current_password");
        private By newPasswordField = By.Id("PasswordFrm_password");
        private By confirmNewPasswordField = By.Id("PasswordFrm_confirm");
        private By continueButton = By.CssSelector("#PasswordFrm > div.form-group > div > button");
        private By backButton = By.CssSelector("#PasswordFrm > div.form-group > div > a > i");
        private By passwordMismatchErrorMessage = By.CssSelector("#PasswordFrm > div.registerbox.form-horizontal > fieldset > div:nth-child(3) > span");
        private By invalidPasswordErrorMessage = By.CssSelector("#PasswordFrm > div.registerbox.form-horizontal > fieldset > div:nth-child(1) > span");
        #endregion

        #region Constructor
        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public void EnterCurrentAndNewPassword(string currentPassword, string newPassword, string confirmPassword)
        {
            Logs.Step("Entering Current Password");
            ClearAndSendKeys(currentPasswordField, currentPassword);

            Logs.Step("Entering New Password");
            ClearAndSendKeys(newPasswordField, newPassword);

            Logs.Step("Entering Confirm New Password");
            ClearAndSendKeys(confirmNewPasswordField, confirmPassword);
        }

        public void ClickOnContinueButton()
        {
            Logs.Step("Clicking on Continue Button");
            Click(continueButton);
        }

        public void ClickOnBackButton()
        {
            Logs.Step("Clicking on Back Button");
            Click(backButton);
        }
        public string GetPasswordMismatchErrorMessage()
        {
            Logs.Step("Getting Password Mismatch Error Message");
            return GetText(passwordMismatchErrorMessage);
        }
        public string GetInvalidPasswordErrorMessage()
        {
            Logs.Step("Getting Invalid Password Error Message");
            return GetText(invalidPasswordErrorMessage);
        }
        #endregion
    }
}
