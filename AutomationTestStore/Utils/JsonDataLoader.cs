using System;
using System.IO;
using System.Text.Json;

namespace AutomationTestStore.Utils
{
    public static class JsonDataLoader
    {
        public static JsonData Load(string path = "Data/TestData.json")
        {
            var resolved = ResolvePath(path);
            if (!File.Exists(resolved))
                throw new FileNotFoundException($"Test data file not found at: {resolved}");

            var json = File.ReadAllText(resolved);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<JsonData>(json, options);
            if (data == null)
                throw new InvalidOperationException("Failed to deserialize test data JSON.");

            return data;
        }

        private static string ResolvePath(string path)
        {
            return Path.GetFullPath(path);
        }

        // Convenience helpers
        public static JsonData.NewUserData? GetNewUser(string path = "Data/TestData.json")
            => Load(path).CreateUser?.NewUser;

        public static JsonData.ExistingUserData? GetExistingUser(string path = "Data/TestData.json")
            => Load(path).CreateUser?.ExistingUser;
    }
}
