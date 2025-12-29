using System.Text.Json.Serialization;

namespace AutomationTestStore.Utils
{
    public class JsonData
    {
        [JsonPropertyName("CreateUser")]
        public CreateUserSection? CreateUser { get; set; }

        public class CreateUserSection
        {
            [JsonPropertyName("NewUser")]
            public NewUserData? NewUser { get; set; }

            [JsonPropertyName("ExistingUser")]
            public ExistingUserData? ExistingUser { get; set; }
        }

        public class NewUserData
        {
            [JsonPropertyName("firstName")]
            public string? firstName { get; set; }

            [JsonPropertyName("lastName")]
            public string? lastName { get; set; }

            [JsonPropertyName("telephone")]
            public string? telephone { get; set; }

            [JsonPropertyName("fax")]
            public string? fax { get; set; }

            [JsonPropertyName("company")]
            public string? company { get; set; }

            [JsonPropertyName("address1")]
            public string? address1 { get; set; }

            [JsonPropertyName("address2")]
            public string? address2 { get; set; }

            [JsonPropertyName("city")]
            public string? city { get; set; }

            [JsonPropertyName("region")]
            public string? region { get; set; }

            [JsonPropertyName("postalCode")]
            public string? postalCode { get; set; }

            [JsonPropertyName("country")]
            public string? country { get; set; }
        }

        public class ExistingUserData
        {
            [JsonPropertyName("firstName")]
            public string? firstName { get; set; }

            [JsonPropertyName("lastName")]
            public string? lastName { get; set; }

            [JsonPropertyName("email")]
            public string? email { get; set; }

            [JsonPropertyName("telephone")]
            public string? telephone { get; set; }

            [JsonPropertyName("fax")]
            public string? fax { get; set; }

            [JsonPropertyName("company")]
            public string? company { get; set; }

            [JsonPropertyName("address1")]
            public string? address1 { get; set; }

            [JsonPropertyName("address2")]
            public string? address2 { get; set; }

            [JsonPropertyName("city")]
            public string? city { get; set; }

            [JsonPropertyName("region")]
            public string? region { get; set; }

            [JsonPropertyName("postalCode")]
            public string? postalCode { get; set; }

            [JsonPropertyName("country")]
            public string? country { get; set; }

            [JsonPropertyName("loginName")]
            public string? loginName { get; set; }

            [JsonPropertyName("password")]
            public string? password { get; set; }

            [JsonPropertyName("confirmPassword")]
            public string? confirmPassword { get; set; }

            [JsonPropertyName("newPassword")]
            public string? newPassword { get; set; }

            [JsonPropertyName("confirmNewPassword")]
            public string? confirmNewPassword { get; set; }

            [JsonPropertyName("invalidPassword")]
            public string? invalidPassword { get; set; }

            [JsonPropertyName("invalidLoginName")]
            public string? invalidLoginName { get; set; }
        }

    }
}
