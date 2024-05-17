using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D365BCConnectorAPIGear;
using D365BCConnectorAPIGear.Entities;

namespace BCStripeSync.APIServiceExtensions
{
    public class SalesQuoteHeaderService : BusinessCentralService, ICustomerService
    {
        public SalesQuoteHeaderService(string clientId, string clientSecret, string tenantId, string companyId) : base(
            clientId, clientSecret, tenantId, companyId)
        {
        }

        public Task<ApiResponse<SalesQuoteHeader>?> GetAsync()
        {
            var url =
                $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/TunerBrands/StripeAPI/v1.0/companies({_companyId})/SalesQuoteHeader";
            return GetDataAsync<SalesQuoteHeader>(url);
        }


        public Task<ApiResponse<SalesQuoteHeader>?> GetFilteredAsync(string filterField, FilterOperator expression,
            object filterValue)
        {
            var filterValueString = FormatFilterValue(filterValue);
            var filtertype = string.Empty;

            if (expression == FilterOperator.Equal)
            {
                filtertype = "eq";
            }

            if (expression == FilterOperator.LessThan)
            {
                filtertype = "lt";
            }

            if (expression == FilterOperator.GreaterThan)
            {
                filtertype = "gt";
            }

            if (expression == FilterOperator.GreaterThanOrEqual)
            {
                filtertype = "ge";
            }

            if (expression == FilterOperator.LessThanOrEqual)
            {
                filtertype = "le";
            }

            if (expression == FilterOperator.NotEqual)
            {
                filtertype = "ne";
            }


            var url =
                $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/TunerBrands/StripeAPI/v1.0/companies({_companyId})/SalesQuoteHeader?$filter={filterField} {filtertype} {filterValueString}";
            return GetDataAsync<SalesQuoteHeader>(url);
        }


        public Task<bool> UpdateByNoAsync(string no, Dictionary<string, object> keyValuePairs, string eTag)
        {
            var url =
                $"https://api.businesscentral.dynamics.com/v2.0/{_tenantId}/Production/api/TunerBrands/StripeAPI/v1.0/companies({_companyId})/SalesQuoteHeader('Quote','{no}')";
            return UpdateDataAsync(url, keyValuePairs, eTag);
        }
    }
}