using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationTestStore.Pages
{
    public class PageObjects
    {
        protected WebDriverWait _wait;

        protected IWebDriver CurrentDriver;
        protected readonly Actions _actions;


        public PageObjects(IWebDriver driver)
        {
            CurrentDriver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.TimeOutCommand));
            _actions = new Actions(driver);
        }

        #region Wait Methods
        public IWebElement WaitForElementToDisplay(By by)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element with locator: {by} was not displayed within timeout.");
            }
        }

        public IWebElement WaitForElementToBeEnabled(By by)
        {
            try
            {
                return _wait.Until(driver =>
                {
                    var element = driver.FindElement(by);
                    return (element.Enabled && element.Displayed) ? element : null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element with locator: {by} was not enabled within timeout.");
            }
        }

        public void WaitForPageToLoad()
        {
            try
            {
                _wait.Until(driver =>
                {
                    try
                    {
                        var jsExecutor = (IJavaScriptExecutor)driver;
                        string readyState = jsExecutor.ExecuteScript("return document.readyState").ToString();
                        return readyState.Equals("complete", StringComparison.OrdinalIgnoreCase);
                    }
                    catch
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Page did not load completely within the timeout period.");
            }
        }
        #endregion

        #region Element Interaction Methods
        public void ClearAndSendKeys(By by, string text)
        {
            var element = WaitForElementToBeEnabled(by);
            element.Clear();
            element.SendKeys(text);
        }

        public void Click(By by)
        {
            var element = _wait.Until(ExpectedConditions.ElementToBeClickable(by));
            element.Click();
        }

        public string GetText(By by)
        {
            var element = WaitForElementToDisplay(by);
            return element.Text;
        }

        public string GetAttribute(By by, string attributeName)
        {
            var element = WaitForElementToDisplay(by);
            return element.GetAttribute(attributeName);
        }

        public void HoverAndSelectDropdown(By menuLocator, By subMenuLocator)
        {
            var menuElement = WaitForElementToDisplay(menuLocator);
            _actions.MoveToElement(menuElement).Perform();

            var subMenuElement = WaitForElementToBeEnabled(subMenuLocator);
            _actions.MoveToElement(subMenuElement).Click().Perform();
        }
        #endregion

        #region Alert Methods
        public IAlert GetAlert()
        {
            try
            {
                _wait.Until(ExpectedConditions.AlertIsPresent());
                return CurrentDriver.SwitchTo().Alert();
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("No alert was displayed within timeout period.");
            }
        }

        public void AcceptAlert()
        {
            var alert = GetAlert();
            alert.Accept();
        }

        public void DismissAlert()
        {
            var alert = GetAlert();
            alert.Dismiss();
        }

        public string GetAlertText()
        {
            var alert = GetAlert();
            return alert.Text;
        }
        #endregion
    }
}
