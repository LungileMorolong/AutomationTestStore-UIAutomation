using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationTestStore
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");
            new DriverManager().SetUpDriver(new EdgeConfig());

            return new EdgeDriver(options);
        }
    }
}
