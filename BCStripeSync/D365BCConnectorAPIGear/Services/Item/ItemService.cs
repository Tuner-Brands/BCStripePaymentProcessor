using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D365BCConnectorAPIGear.Entities;
using D365BCConnectorAPIGear;

namespace D365BCConnectorAPIGear
{
    public class ItemService : BusinessCentralService, IItemService
    {
        public ItemService(string clientId, string clientSecret, string tenantId, string companyId) : base(clientId, clientSecret, tenantId, companyId)
        {
        }



        public Task<ApiResponse<Item>?> GetAsync(string id)
        {
            var url = $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/v2.0/companies({_companyId})/items/{id}";
            return GetDataAsync<Item>(url);
        }

        public Task<ApiResponse<Item>?> GetByNumberAsync(string number)
        {
            var url = $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/v2.0/companies({_companyId})/items?$filter=number eq '{number}'";
            return GetDataAsync<Item>(url);
        }


    }
}
