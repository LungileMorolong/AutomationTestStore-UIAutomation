using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using Allure.Commons;

namespace AutomationTestStore
{
    public class BaseTests
    {
        protected IWebDriver Driver;

        [SetUp]

        public void SetUp()
        {
            Driver = WebDriverFactory.CreateDriver();
            Driver.Navigate().GoToUrl(Constants.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                TakeScreenshot();
            }
            Driver.Quit();
        }


        private void TakeScreenshot()
        {
            try
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                string solutionDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

                string screenshotDir = Path.Combine(solutionDir, "Screenshots");

                if (!Directory.Exists(screenshotDir))
                {
                    Directory.CreateDirectory(screenshotDir);
                }

                string screenshotFile = Path.Combine(screenshotDir, $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(screenshotFile);

                AllureLifecycle.Instance.AddAttachment("Screenshot on failure", "image/png", screenshotFile);
            }
            catch (Exception ex)
            {
                Logs.Info($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}
