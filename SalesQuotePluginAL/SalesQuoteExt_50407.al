pageextension 50407 SalesQuoteExtention extends "Sales Quote"
{

    layout
    {



        addafter("Status")
        {
            field(StripeQuote; Rec.StripeQuoteId)
            {
                Importance = Additional;
                ApplicationArea = All;
                Caption = 'Stripe Quote Id';
                Enabled = false;
            }
        }

        addafter("StripeQuote")
        {
            field(StripeInvoice; Rec.StripeInvoiceId)
            {
                Importance = Additional;
                ApplicationArea = All;
                Caption = 'Stripe Invoice Id';
                Enabled = false;
            }
        }

        addafter("StripeInvoice")
        {
            field(StripePayment; Rec.StripePaymentId)
            {
                Importance = Additional;
                ApplicationArea = All;
                Caption = 'Stripe Payment Id';
                Enabled = false;
            }
        }

        addafter("StripePayment")
        {
            field(StripePaid; Rec.StripePaid)
            {
                ApplicationArea = All;
                Caption = 'Stripe Paid';
                Enabled = false;
            }
        }

        addafter("StripePayment")
        {
            field(StripeAutoPay; Rec.StripeAutoPay)
            {
                ApplicationArea = All;
                Caption = 'Charge Customer (Default Payment)';
                Enabled = true;
            }
        }

        addafter("StripeAutoPay")
        {
            field(StripeHostedInvoiceUrl; Rec.StripeHostedInvoiceUrl)
            {

                ApplicationArea = All;
                Caption = 'Payment URL';
                Editable = false;
                ToolTip = 'Click to open the payment link';
                ExtendedDatatype = URL;
            }
        }

        addafter("StripeHostedInvoiceUrl")
        {
            field(StripeInvoicePdf; Rec.StripeInvoicePdf)
            {
                ApplicationArea = All;
                Caption = 'Invoice PDF';
                Editable = false;
                ToolTip = 'Click to open the Invoice PDF';
                ExtendedDatatype = URL;
            }
        }



    }
}


tableextension 50408 SalesHeaderTableExtension extends "Sales Header"
{
    fields
    {
        field(50402; StripeQuoteId; Text[100]) { }
        field(50403; StripeInvoiceId; Text[100]) { }
        field(50404; StripePaymentId; Text[100]) { }
        field(50405; StripePaid; Boolean) { }
        field(50406; StripeHostedInvoiceUrl; Text[400]) { }
        field(50407; StripeInvoicePdf; Text[400]) { }
        field(50408; StripeAutoPay; Boolean)
        {
            trigger OnValidate()
            var
                result: Boolean;
            begin
                if (StripePaid = false) and (StripeInvoiceId <> '') and (Status = "Sales Document Status"::Released) then begin
                    StripeAutoPay := Confirm('Charge Customer?', false);
                end else begin
                    StripeAutoPay := false
                end;
            end;

        }
    }
}