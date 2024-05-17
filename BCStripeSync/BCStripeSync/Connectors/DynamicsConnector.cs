using D365BCConnectorAPIGear;

namespace BCStripeSync.Connectors;

public class DynamicsConnector
{
    protected string ClientId;
    protected string ClientSecret;
    protected string CompanyId;
    protected string TenantId;


    public DynamicsConnector(string clientId, string clientSecret, string tenantId, string companyId)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
        TenantId = tenantId;
        CompanyId = companyId;
    }


    public async Task GetCompaniesAsync()
    {
        var companyService = new CompanyService(ClientId, ClientSecret, TenantId, CompanyId);
        var resp = await companyService.GetListAsync();
    }
}