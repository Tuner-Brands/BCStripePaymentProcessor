using D365BCConnectorAPIGear.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear
{
    public class SalesQuoteLineService : BusinessCentralService, ISalesQuoteLineService
    {
        public SalesQuoteLineService(string clientId, string clientSecret, string tenantId, string companyId) : base(clientId, clientSecret, tenantId, companyId)
        {
        }


        public Task<ApiResponse<SalesQuoteLine>?> GetAsync(string id)
        {
            var url = $"https://api.businesscentral.dynamics.com/v2.0/{(_tenantId)}/Production/api/v2.0/companies({_companyId})/salesQuoteLines({id})";
            return GetDataAsync<SalesQuoteLine>(url);
        }


        public Task<ApiResponse<SalesQuoteLine>?> GetByQuoteIdAsync(string id)
        {
            var url = $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/v2.0/companies({_companyId})/salesQuotes({id})/salesQuoteLines";
            return GetDataAsync<SalesQuoteLine>(url);
        }


    }
}
