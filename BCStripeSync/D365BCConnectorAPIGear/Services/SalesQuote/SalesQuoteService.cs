using D365BCConnectorAPIGear.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear
{
    internal class SalesQuoteService : BusinessCentralService, ISalesQuoteService
    {
        public SalesQuoteService(string clientId, string clientSecret, string tenantId, string companyId) : base(clientId, clientSecret, tenantId, companyId)
        {
        }

 


    }
}
