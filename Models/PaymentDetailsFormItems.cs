using System.ComponentModel.DataAnnotations;

public class PaymentDetailsFormItems
{
    public string? CardName { get; set; }
    public string? CardType { get; set; }

    [Required]
    [StringLength(maximumLength: 16, MinimumLength = 16, ErrorMessage = "9 characters please")]
    public string? CardNumber{ get; set; }

    public DateOnly ExpiryDate { get; set; }

    [Required]
    [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "9 characters please")]
    public string? Csv{ get; set; }
    // etc...

}