using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PutOrderLine
{
    private readonly HttpClient _httpClient;

    public PutOrderLine()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> PutOrderLineAsync(string accessToken)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            string baseUrl = "https://vbi.okonomibistand.no/VBInterfaceOBIDev";
            // Adjusted URL to include hardcoded orderNo and lineNo
            string endpoint = "/api/Order/64056/OrderLine/2";
            string requestUrl = $"{baseUrl}{endpoint}";

            // OrderLine data
            var orderLineData = new
            {
                productNo = "1",
                lineNo = 0, // This might be redundant because of the URL structure but included for consistency
                quantity = 0,
                price = 0,
                transactionInformation2 = "13:54"
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(orderLineData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(requestUrl, content);
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Order line updated successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to update order line. Error: {ex.Message}");
            return false;
        }
    }
}
