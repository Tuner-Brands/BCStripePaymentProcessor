using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear
{
    public class Company : BaseObject
    {
        [JsonProperty("systemVersion")]
        public string? SystemVersion { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("businessProfileId")]
        public string? BusinessProfileId { get; set; }

        [JsonProperty("systemCreatedAt")]
        public DateTime SystemCreatedAt { get; set; }

        [JsonProperty("systemCreatedBy")]
        public Guid SystemCreatedBy { get; set; }

        [JsonProperty("systemModifiedAt")]
        public DateTime SystemModifiedAt { get; set; }

        [JsonProperty("systemModifiedBy")]
        public Guid SystemModifiedBy { get; set; }


    }
}
