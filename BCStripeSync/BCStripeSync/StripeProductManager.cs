using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BCStripeSync.Connectors;
using D365BCConnectorAPIGear;
using D365BCConnectorAPIGear.Entities;
using Stripe;

namespace BCStripeSync
{
    public class StripeProductManager
    {
        private StripeConnector StripeConnector { get; set; }
        private IMapper Mapper { get; set; }

        public StripeProductManager(StripeConnector stripeConnector)
        {
            StripeConnector = stripeConnector;
            var mapperConfiguration = AutoMapperConfig.Configure();
            Mapper = mapperConfiguration.CreateMapper();
        }


        public async Task<Stripe.Price> SetUpProductAsync(SalesQuoteLine line)
        {
            var stripeProducts =  StripeConnector.GetProductsBySku(line.LineObjectNumber); // todo: make Async
            if (!stripeProducts.Any())
            {
                throw new Exception("No products found for the given SKU.");
            }

            var stripeProduct = stripeProducts.First();
            var stripePrices =  StripeConnector.GetPricesByProductId(stripeProduct.Id);  // todo: make Async

            double unitPriceAfterDiscounts = CalculateDiscountedPrice( Convert.ToDouble( line.UnitPrice) , Convert.ToDouble( line.DiscountPercent) );

            var targetPrice = (decimal)unitPriceAfterDiscounts * 100;
            var existingPrice = stripePrices.FirstOrDefault(x => x.Active && x.UnitAmountDecimal == targetPrice);

            if (existingPrice != null)
            {
                return existingPrice;
            }

            return  StripeConnector.CreatePrice(unitPriceAfterDiscounts, stripeProduct.Id);  // todo: make Async
        }

        
        private double CalculateDiscountedPrice(double unitPrice, double? discountPercent)
        {
            if (discountPercent.HasValue && discountPercent > 0)
            {
                return Math.Round(unitPrice * (1 - discountPercent.Value / 100), 2);
            }
            return unitPrice;
        }


    }
}