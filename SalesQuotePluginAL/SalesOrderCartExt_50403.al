pageextension 50403 PageExtSalesOrder extends "Sales Order"
{

    layout
    {
        modify("Status")
        {
            Editable = true;
        }
    }


    trigger OnOpenPage();
    begin
        CurrPage.Editable(true);
    end;

}
