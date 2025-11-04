using Microsoft.Extensions.Configuration;

namespace AutomationTestStore
{
    public static class Constants
    {
        private static string _baseUrl;
        private static int _timeOutCommand;

        public static void Init(IConfigurationRoot config)
        {
            var localBrowserConfig = config.GetSection("TestSettings");
            _baseUrl = localBrowserConfig["BaseUrl"];
            _timeOutCommand = Convert.ToInt16(localBrowserConfig["TimeOutCommand"]);
        }

        public static string BaseUrl
        {
            get 
            { 
                return _baseUrl; 
            }
        }

        public static int TimeOutCommand
        {
            get 
            { 
                return _timeOutCommand; 
            }
        }
    }
}
