using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PostCustomer
{
    private readonly HttpClient _httpClient;

    public PostCustomer()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> PostCustomerAsync(string accessToken)
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
                name = "Magnus Westlie",
                address1 = "Bærumsgata 123",
                postalNo = "1337",
                postalArea = "Bærum",
                phone = "99999999"
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(customerData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content); // Change PUT to POST
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Customer data posted successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to post customer data. Error: {ex.Message}");
            return false;
        }
    }
}
