using System;
using System.Collections.Generic;

using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;
namespace deleteAzureHubInstallation
{
    public partial class Pushnotif
    {
        [JsonPropertyName("eTag")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long ETag { get; set; }

        [JsonPropertyName("expirationTime")]
        public DateTimeOffset ExpirationTime { get; set; }

        [JsonPropertyName("registrationId")]
        public string RegistrationId { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("pushVariables")]
        public object PushVariables { get; set; }

        [JsonPropertyName("pnsHandle")]
        public string PnsHandle { get; set; }

        [JsonPropertyName("isReadOnly")]
        public bool IsReadOnly { get; set; }

        [JsonPropertyName("extensionData")]
        public ExtensionData ExtensionData { get; set; }
    }

    public partial class ExtensionData
    {
    }
}


