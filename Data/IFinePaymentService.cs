using FinePaymentApp.Data;


public interface IFinePaymentService
{
    Task<IEnumerable<FinePayment>> GetFinePayments();
    Task<FinePayment?> GetFinePayment(long id);
    Task<FinePayment?> SearchFinePayment(string? caseRef, string? onlineAccountRef);
    Task<bool> AddFinePayment(FinePayment finePayment);
    Task<bool> DeleteFinePayment(FinePayment finePayment);
    Task<bool> SetFinePayment( FinePayment finePayment);
}