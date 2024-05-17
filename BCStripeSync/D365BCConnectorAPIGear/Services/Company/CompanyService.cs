using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D365BCConnectorAPIGear.Entities;


namespace D365BCConnectorAPIGear
{
    public class CompanyService : BusinessCentralService,  ICompanyService
    {
        public CompanyService(string clientId, string clientSecret, string tenantId, string companyId = "") : base(clientId, clientSecret, tenantId, companyId)
        {
        }



        public Task<ApiResponse<Company>?> GetListAsync()
        {
            var url = $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/v2.0/companies";
            return GetDataAsync<Company>(url);
        }

    }
}
