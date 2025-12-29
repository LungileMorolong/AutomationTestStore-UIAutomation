using System;
using System.Text;
using System.Security.Cryptography;

namespace AutomationTestStore.Utils
{
    public class CredentialGenerator
    {
        private const string lowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        private const string uppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string digitCharacters = "0123456789";
        private const string specialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        private const string allPasswordCharacters = lowercaseCharacters + uppercaseCharacters + digitCharacters + specialCharacters;

        private const string usernameCharacters = lowercaseCharacters + uppercaseCharacters + digitCharacters;

        public static string GenerateRandomUsername(int length = 8)
        {
            return RandomNumberGenerator.GetString(usernameCharacters, length);
        }

        public static string GenerateRandomPassword(int length = 12)
        {
            return RandomNumberGenerator.GetString(allPasswordCharacters, length);
        }

        public static string GenerateRandomEmail(int usernameLength = 8, string domain = "example.com")
        {
            string username = GenerateRandomUsername(usernameLength);
            return $"{username}@{domain}";
        }
    }
}
