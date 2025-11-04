using Microsoft.Extensions.Configuration;
using NUnit.Framework;
namespace AutomationTestStore
{
    [SetUpFixture]
    public class StartUpTests
    {
        [OneTimeSetUp]
        public static void Initialize()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            Constants.Init(config);
        }
    }
}
