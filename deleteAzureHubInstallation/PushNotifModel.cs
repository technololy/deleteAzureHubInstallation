using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace deleteAzureHubInstallation
{
       public partial class Pushmodel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("silent")]
        public bool Silent { get; set; }
    }
}
