reportextension 50401 SalesQuoteUpdate extends "Standard Sales - Quote"
{
    dataset
    {
        add(Header)
        {
            column(StripeInvoicePdf; StripeInvoicePdf)
            {
            }
            column(StripeHostedInvoiceUrl; StripeHostedInvoiceUrl)
            {
            }
        }
    }
}
