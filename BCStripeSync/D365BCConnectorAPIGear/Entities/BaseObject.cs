using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear
{
    public abstract class BaseObject
    {

        [JsonProperty("@odata.etag")] public string? ODataEtag { get; set; }
        [JsonProperty("id")] public Guid Id { get; set; }
        [JsonProperty("number")] public string? No { get; set; }

    }
}
