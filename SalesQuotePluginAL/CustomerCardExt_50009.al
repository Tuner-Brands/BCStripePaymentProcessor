pageextension 50409 UpdateCustomer extends "Customer Card"
{

    layout
    {
        addafter("Payment Method Code")
        {
            field(StripeCardId; Rec.StripeCardId)
            {
                ApplicationArea = All;
                Caption = 'Default Card Id';
                Enabled = false;
            }
        }

        addafter("Customer Posting Group")
        {

            field("Stripe ID"; Rec."StripeID")
            {
                ApplicationArea = All;
                Caption = 'Stripe ID';
            }
        }
    }


}


tableextension 50409 CustomertTableExtension extends "Customer"
{
    fields
    {
        field(50402; StripeCardId; Text[100]) { }

        field(50404; StripeID; Text[100]) { }

    }
}
