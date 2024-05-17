permissionset 50400 StripeAPI
{
    Assignable = true;
    Caption = 'StripeAPI';
    Permissions =
          tabledata "Customer" = RIMD,
          tabledata "Payment Terms" = RMD,
          tabledata "Currency" = RM,
          tabledata "Sales Header" = RIM,
          tabledata "Sales Line" = RIMD;
}
