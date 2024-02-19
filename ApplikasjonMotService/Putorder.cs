using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PutOrder
{
    private readonly HttpClient _httpClient;

    public PutOrder()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> PutOrderAsync(string accessToken)
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
                orderNo = 64056,
                employeeNo = 1
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(orderData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(requestUrl, content);
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
