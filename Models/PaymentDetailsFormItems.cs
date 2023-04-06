using System.ComponentModel.DataAnnotations;

public class PaymentDetailsFormItems
{
    public string? CardName { get; set; }
    public string? CardType { get; set; }

    //[Required]
    //[CreditCard]
    public string? CardNumber{ get; set; }

    public DateOnly ExpiryDate { get; set; }
    //[Required]
    public string? ExpiryMonth { get; set; }
    //[Required]
    public string? ExpiryYear { get; set; }


    //[Required]
    //[StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "3 characters please")]
    public string? Csv{ get; set; }
    // etc...

}