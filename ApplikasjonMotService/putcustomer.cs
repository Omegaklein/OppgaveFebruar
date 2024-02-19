using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PutCustomer
{
    private readonly HttpClient _httpClient;

    public PutCustomer()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> PutCustomerAsync(string accessToken)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            string baseUrl = "https://vbi.okonomibistand.no/VBInterfaceOBIDev";
            string endpoint = "/api/Customer"; // Change this endpoint if needed
            string requestUrl = $"{baseUrl}{endpoint}";

            // Customer data
            var customerData = new
            {
                customerNo = 61046,
                name = "Eyvind Andersen",
                address1 = "Lyngvegen 32",
                postalNo = "6429",
                postalArea = "Molde",
                phone = "40412988"
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(customerData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(requestUrl, content);
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Customer data put successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to put customer data. Error: {ex.Message}");
            return false;
        }
    }
}
