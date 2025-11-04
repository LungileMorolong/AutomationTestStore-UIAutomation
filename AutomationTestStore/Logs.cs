using Allure.Commons;
using NUnit.Allure.Core;

namespace AutomationTestStore
{
    public static class Logs
    {
        static Logs()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();  
        }

        public static void Step(string message)
        {
            Console.WriteLine($"Step: {message}");
            AllureLifecycle.Instance.WrapInStep(delegate
            {
            }, "Step: " + message, "Step");
        }

        public static void Info(string message)
        {
            Console.WriteLine($"Info: {message}");
            AllureLifecycle.Instance.WrapInStep(delegate
            {
            }, "Info: " + message, "Info");
        }
    }
}
