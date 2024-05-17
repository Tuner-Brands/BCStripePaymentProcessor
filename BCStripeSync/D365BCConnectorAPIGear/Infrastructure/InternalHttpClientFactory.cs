using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;


namespace D365BCConnectorAPIGear.Infrastructure
{
    internal class InternalHttpClientFactory : IHttpClientFactory
    {
        private static readonly HttpClient Client = new HttpClient();

        public HttpClient CreateClient(string name)
        {
            return Client;
        }
    }
}
