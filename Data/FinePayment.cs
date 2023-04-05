namespace FinePaymentApp.Data;
public class FinePayment
{
    public long Id { get; set; }
    public string? CaseReference { get; set; }
    public string? OnlineAccountReference { get; set; }
    public float Amount { get; set; }
    public DateTime PaymentDueDate { get; set; }
    public bool PaymentCompleted { get; set; } = false;
    public DateTime? PaymentDate { get; set; } = null;
    public string? PaymentReference { get; set; } = null;
}