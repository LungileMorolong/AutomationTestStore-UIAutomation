using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    public class AccountRegistrationPage : PageObjects
    {
        #region Private Fields
        private By firstNameInputField = By.Id("AccountFrm_firstname");
        private By lastNameInputField = By.Id("AccountFrm_lastname");
        private By emailInputField = By.Id("AccountFrm_email");
        private By telephoneInputField = By.Id("AccountFrm_telephone");
        private By faxInputField = By.Id("AccountFrm_fax");

        private By companyInputField = By.Id("AccountFrm_company");
        private By address1InputField = By.Id("AccountFrm_address_1");
        private By address2InputField = By.Id("AccountFrm_address_2");
        private By cityInputField = By.Id("AccountFrm_city");
        private By regionDropDown = By.Id("AccountFrm_zone_id");
        private By zipCodeInputField = By.Id("AccountFrm_postcode");
        private By countryDropDown = By.Id("AccountFrm_country_id");

        private By loginNameInputField = By.Id("AccountFrm_loginname");
        private By passwordInputField = By.Id("AccountFrm_password");
        private By confirmPasswordInputField = By.Id("AccountFrm_confirm");

        private By newsletterYesRadioButton = By.Id("AccountFrm_newsletter1");
        private By newsletterNoRadioButton = By.Id("AccountFrm_newsletter0");

        private By termsAndConditionsCheckbox = By.Id("AccountFrm_agree");

        private By continueButton = By.CssSelector("#AccountFrm > div.form-group > div > div > button");

        private By registrationSuccessMessage = By.CssSelector("#maincontainer > div > div.col-md-9.col-xs-12.mt20 > div > div > section > p:nth-child(3)");
        private By registrationFailureMessage = By.CssSelector("#maincontainer > div > div > div > div.alert.alert-error.alert-danger");

        private By accountContinueButton = By.CssSelector("#maincontainer > div > div.col-md-9.col-xs-12.mt20 > div > div > section > a");
        #endregion

        #region Constructor
        public AccountRegistrationPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Public Methods
        public void EnterMandatoryPersonalDetails(string firstName, string lastName, string email)
        {
            Logs.Step($"Entering First Name: {firstName}");
            ClearAndSendKeys(firstNameInputField, firstName);

            Logs.Step($"Entering Last Name: {lastName}");
            ClearAndSendKeys(lastNameInputField, lastName);

            Logs.Step($"Entering Email: {email}");
            ClearAndSendKeys(emailInputField, email);
        }
        public void EnterNonMandatoryPersonalDetails(string telephone, string fax)
        {
            Logs.Step($"Entering Telephone: {telephone}");
            ClearAndSendKeys(telephoneInputField, telephone);

            Logs.Step($"Entering Fax: {fax}");
            ClearAndSendKeys(faxInputField, fax);
        }

        public void EnterMandatoryAddressDetails(string address1, string city, string region, string zipCode)
        {

            Logs.Step($"Entering Address 1: {address1}");
            ClearAndSendKeys(address1InputField, address1);

            Logs.Step($"Entering City: {city}");
            ClearAndSendKeys(cityInputField, city);

            Logs.Step($"Selecting Region: {region}");
            SelectByText(regionDropDown, region);

            Logs.Step($"Entering Zip Code: {zipCode}");
            ClearAndSendKeys(zipCodeInputField, zipCode);
        }

        public void EnterNonMandatoryAddressDetails(string company, string address2, string country)
        {
            Logs.Step($"Entering Company: {company}");
            ClearAndSendKeys(companyInputField, company);

            Logs.Step($"Entering Address 2: {address2}");
            ClearAndSendKeys(address2InputField, address2);

            Logs.Step($"Selecting Country: {country}");
            SelectByText(countryDropDown, country);
        }

        public void EnterLoginDetails(string loginName, string password, string confirmPassword)
        {
            Logs.Step($"Entering Login Name: {loginName}");
            ClearAndSendKeys(loginNameInputField, loginName);

            Logs.Step($"Entering Password.");
            ClearAndSendKeys(passwordInputField, password);

            Logs.Step($"Entering Confirm Password.");
            ClearAndSendKeys(confirmPasswordInputField, confirmPassword);
        }

        public void SelectNewsletterSubscription(bool subscribe)
        {
            if (subscribe)
            {
                Logs.Step("Selecting Newsletter Subscription: Yes");
                WaitForElementToBeEnabled(newsletterYesRadioButton).Click();
            }
            else
            {
                Logs.Step("Selecting Newsletter Subscription: No");
                WaitForElementToBeEnabled(newsletterNoRadioButton).Click();
            }
        }

        public void AgreeToTermsAndConditions()
        {
            Logs.Step("Agreeing to Terms and Conditions.");
            WaitForElementToBeEnabled(termsAndConditionsCheckbox).Click();
        }

        public void ClickContinueButton()
        {
            Logs.Step("Clicking Continue Button to submit the registration form.");
            Click(continueButton);
        }

        public string GetRegistrationSuccessMessage()
        {
            Logs.Step("Retrieving Registration Success Message.");
            return GetText(registrationSuccessMessage);
        }

        public string GetRegistrationFailureMessage()
        {
            Logs.Step("Retrieving Registration Failure Message.");
            return GetText(registrationFailureMessage);
        }

        public void ClickAccountContinueButton()
        {
            Logs.Step("Click Continue after account creation");
            Click(accountContinueButton);
        }
        #endregion
    }
}

