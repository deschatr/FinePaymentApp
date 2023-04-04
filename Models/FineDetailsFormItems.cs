using System.ComponentModel.DataAnnotations;

public class FineDetailsFormItems
{
    [Required]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "9 characters please")]
    public string CaseReference { get; set; } = "";
    
    [Required]
    [MinLength(10)]
    public string OnlineAccountReference { get; set; } = "";
}