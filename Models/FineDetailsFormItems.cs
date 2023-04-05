using System.ComponentModel.DataAnnotations;

public class FineDetailsFormItems
{
    [Required]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "The format of the case reference is 23/123456")]
    public string CaseReference { get; set; } = "";
    
    [Required]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "The online account reference should be 12 characters: NIDF12345678")]
    public string OnlineAccountReference { get; set; } = "";
}