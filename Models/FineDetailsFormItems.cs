using System.ComponentModel.DataAnnotations;

public class FineDetailsFormItems
{
    [Required]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "9 characters please")]
    public string CaseReference { get; set; } = "";
    
    [Required]
    [MinLength(6)]
    public string OnlineAccountReference { get; set; } = "";
}