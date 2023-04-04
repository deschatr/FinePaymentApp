using System.ComponentModel.DataAnnotations;

public class PaymentDetailsFormItems
{
    public string? CardType { get; set; }

    public string? CardNumber{ get; set; }

    public DateOnly ExpiryDate { get; set; }

    // etc...

}