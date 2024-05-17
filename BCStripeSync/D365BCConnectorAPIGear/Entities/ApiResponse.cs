using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear.Entities
{
    public class ApiResponse<T>
    {
        [JsonProperty("value")]
        public T[] Value { get; set; }
    }
}
