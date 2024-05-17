using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear
{
    public class Account : BaseObject
    {


        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("subCategory")]
        public string? SubCategory { get; set; }

        [JsonProperty("blocked")]
        public bool Blocked { get; set; }

        [JsonProperty("accountType")]
        public string? AccountType { get; set; }

        [JsonProperty("directPosting")]
        public bool DirectPosting { get; set; }

        [JsonProperty("netChange")]
        public decimal NetChange { get; set; }

        [JsonProperty("consolidationTranslationMethod")]
        public string? ConsolidationTranslationMethod { get; set; }

        [JsonProperty("consolidationDebitAccount")]
        public string? ConsolidationDebitAccount { get; set; }

        [JsonProperty("consolidationCreditAccount")]
        public string? ConsolidationCreditAccount { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }
    }
}
