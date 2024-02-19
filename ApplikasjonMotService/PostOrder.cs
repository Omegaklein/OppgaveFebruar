using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PostOrder
{
    private readonly HttpClient _httpClient;

    public PostOrder()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> PostOrderAsync(string accessToken)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            string baseUrl = "https://vbi.okonomibistand.no/VBInterfaceOBIDev";
            string endpoint = "/api/order"; // Change this endpoint if needed
            string requestUrl = $"{baseUrl}{endpoint}";

            // Order data
            var orderData = new
            {
                customerNo = 61045,
                orderLines = new[]
                {
                    new { productNo = "1", quantity = 10, price = 20 }
                }
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(orderData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content); // Change from PutAsync to PostAsync
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Order placed successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to place order. Error: {ex.Message}");
            return false;
        }
    }
}
