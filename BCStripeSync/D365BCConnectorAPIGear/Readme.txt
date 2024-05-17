# D365BCConnectorAPIGear

Efficient C# connector for Dynamics365 Business Central API, facilitating easy API connectivity. 


# Microsoft Dynamics 365 Business Central API Connector (Version 2.0)

## Overview

This API connector is designed to integrate with the Microsoft Dynamics 365 Business Central API version 2.0. For more detailed information 
about the API, please visit the [official Microsoft documentation](https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/api-reference/v2.0/).



## API Authorization Details

To authorize API requests, you will need the following credentials:

- **Client ID:** The unique identifier (GUID) for your API client.
- **Client Secret:** The secret key used for OAuth authentication.
- **Tenant ID:** This identifier, known as a GUID, represents your specific environment. Within your tenant environment, it is possible to operate multiple companies, both in production and development settings. The Tenant ID can be retrieved from the URL while logged into the Business Central environment. The URL format typically appears as follows: https://businesscentral.dynamics.com/**<tenant id>**/Production/.
- **Company Id:** Is the envirment id of the company you want to connect to. You can retrieve the company id by using the company service to list the companies in your environment.


Ensure that these credentials are stored securely and used only where necessary to connect to the Business Central API.


## Company Service / Business Central Environment Details

You will want to obtain the company id of the company you want to connect to. You can retrieve the company id by using the company service to list the companies in your environment. Here is some example code on how to retrieve the company id.


```csharp
using D365BCConnectorAPIGear;

var clientId = "49f3cd66-1ce3-4b3c-8f8d-b21f1ba9e0b1";
var clientSecret = "f723hds82hd7jasdfsdafdasf0fk01~!rt9sa9kd9";
var tenantId = "39a9d28c-b46f-4723-bb32-35715212280e";

var companyApiService = new CompanyService(clientId, clientSecret, tenantId);

var companyListResponse = await companyApiService.GetCompanyListAsync();

foreach (var company in companyListResponse.Value)
{
    Console.WriteLine($"Instance Name: {company.Name,-30} Id: {company.Id}");
}
```

