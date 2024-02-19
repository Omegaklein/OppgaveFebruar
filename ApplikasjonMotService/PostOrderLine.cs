using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class PostOrderLine
{
    private readonly HttpClient _httpClient;

    public PostOrderLine()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> PostOrderLineAsync(string accessToken)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            string baseUrl = "https://vbi.okonomibistand.no/VBInterfaceOBIDev";
            // Correct endpoint for POSTing a new order line, without specifying lineNo in the URL
            string endpoint = "/api/Order/64056/OrderLine";
            string requestUrl = $"{baseUrl}{endpoint}";

            // OrderLine data for POSTing a new order line
            var orderLineData = new
            {
                productNo = "1",
                lineNo = 2, // Depending on how your API handles this, it might not be necessary for a POST request
                quantity = 700,
                price = 10,
                transactionInformation2 = "14:09"
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(orderLineData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Change from PutAsync to PostAsync to correctly perform a POST request
            HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content);
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Order line posted successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to post order line. Error: {ex.Message}");
            return false;
        }
    }
}
