using FinePaymentApp.Data;

namespace FinePaymentManagement;

public class FinePaymentService : IFinePaymentService
{
    private readonly HttpClient httpClient;

    // defines the end point for the API
    // base address is defined with the AddHttpClient call
    // calls will go to baseaddress + endpoint and baseaddress + endpoint + "/{id}"
    private const string endPoint = "api/FinePayments";

    // constructor used by AddHttpClient
    public FinePaymentService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    // gets the list of items, returns an empty array if the call has failed
    public async Task<IEnumerable<FinePayment>> GetFinePayments()
    {
        FinePayment[]? results = null;
        try
        {
            results = await httpClient.GetFromJsonAsync<FinePayment[]>(endPoint);
        }
        catch (HttpRequestException e)
        {
            System.Console.WriteLine("!!! GetFinePayments EXCEPTION !!! " + e.GetType().ToString() + ": " + e.Message);
        }
        if (results == null) results = Array.Empty<FinePayment>();
        return results;
    }

    public async Task<FinePayment?> GetFinePayment(long id)
    {
        FinePayment? result = null;
        try
        {
            result = await httpClient.GetFromJsonAsync<FinePayment>(endPoint + "/" + id);
        }
        catch (HttpRequestException e)
        {
            System.Console.WriteLine("!!! GetFinePayment EXCEPTION !!! " + e.GetType().ToString() + ": " + e.Message);
        }
//        if (result == null) result = Array.Empty<FinePayment>();
        return result;
    }

        public async Task<FinePayment?> SearchFinePayment(string? caseRef, string? onlineAccountRef)
    {
        FinePayment? result = null;
        try
        {
            result = await httpClient.GetFromJsonAsync<FinePayment>(endPoint + $"/search?caseref={caseRef}&onlineaccountref={onlineAccountRef}");
        }
        catch (HttpRequestException e)
        {
            System.Console.WriteLine("!!! SearchFinePayment EXCEPTION !!! " + e.GetType().ToString() + ": " + e.Message);
        }
//        if (result == null) result = Array.Empty<FinePayment>();
        return result;
    }

    // adds an item and returns the list of items
    // the list of items is fetched from the API, so that the synchronisation is garanteed
    public async Task<bool> AddFinePayment( FinePayment finePayment )
    {
        bool isSuccessStatusCode = false;
        try
        {
            var response = await httpClient.PostAsJsonAsync<FinePayment>(endPoint, finePayment);
            isSuccessStatusCode = response.IsSuccessStatusCode;
        }
        catch (HttpRequestException e)
        {
            System.Console.WriteLine("!!! AddFinePayments EXCEPTION !!! " + e.GetType().ToString() + ": " + e.Message);
        }
        return isSuccessStatusCode;
    }

    // deletes an item, and returns the list of items
    // the list of items is fetched from the API, so that the synchronisation is garanteed
    public async Task<bool> DeleteFinePayment( FinePayment finePayment )
    {
        bool isSuccessStatusCode = false;
        try
        {
            var response = await httpClient.DeleteAsync(endPoint + "/" + finePayment.Id);
            isSuccessStatusCode = response.IsSuccessStatusCode;

        }
        catch (HttpRequestException e)
        {
            System.Console.WriteLine("!!! DeleteFinePayments EXCEPTION !!! " + e.GetType().ToString() + ": " + e.Message);
        }
        return isSuccessStatusCode;
    }

    // replaces an item, and returns the list of items
    // the list of items is fetched from the API, so that the synchronisation is garanteed
    public async Task<bool> SetFinePayment( FinePayment finePayment )
    {
        bool isSuccessStatusCode = false;
        try
        {
            var response = await httpClient.PutAsJsonAsync(endPoint + "/" + finePayment.Id, finePayment);
            isSuccessStatusCode = response.IsSuccessStatusCode;
        }
        catch (HttpRequestException e)
        {
            System.Console.WriteLine("!!! PutFinePayments EXCEPTION !!! " + e.GetType().ToString() + ": " + e.Message);
        }
        return isSuccessStatusCode;
    }
}