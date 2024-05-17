using System.Net.Http.Headers;
using D365BCConnectorAPIGear.Entities;
using Newtonsoft.Json;
using Serilog;

namespace D365BCConnectorAPIGear;

public class CustomerService : BusinessCentralService, ICustomerService
{
    /// <inheritdoc />
    public CustomerService(string clientId, string clientSecret, string tenantId, string companyId) : base(clientId,
        clientSecret, tenantId, companyId)
    {
    }

    public Task<ApiResponse<Customer>?> GetAsync(string id)
    {
        var url = $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/v2.0/companies({_companyId})/customers/{id}";
        return GetDataAsync<Customer>(url);
    }

    public Task<ApiResponse<Customer>?> GetByNumberAsync(string customerNumber)
    {
        var url = $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/v2.0/companies({_companyId})/customers?$filter=number eq '{customerNumber}'";
        return GetDataAsync<Customer>(url);
    }


}