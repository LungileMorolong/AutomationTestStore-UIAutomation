using Microsoft.Extensions.Configuration;

namespace AutomationTestStore
{
    public static class Constants
    {
        private static string _baseUrl;
        private static string _testDataFilePath;
        private static int _timeOutCommand;

        public static void Init(IConfigurationRoot config)
        {
            var localBrowserConfig = config.GetSection("TestSettings");
            _baseUrl = localBrowserConfig["BaseUrl"];
            _testDataFilePath = localBrowserConfig["TestDataFilePath"];
            _timeOutCommand = Convert.ToInt16(localBrowserConfig["TimeOutCommand"]);
        }


        public static string BaseUrl
        {
            get 
            { 
                return _baseUrl; 
            }
        }

        public static string TestDataFilePath
        {
            get
            {
                string baseDirectory = AppContext.BaseDirectory;

                string repoRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));

                string fullPath = Path.Combine(repoRoot, _testDataFilePath);

                return fullPath;
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
