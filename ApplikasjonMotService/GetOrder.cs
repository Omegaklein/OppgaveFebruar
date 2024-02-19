using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class GetOrder
{
    private readonly HttpClient _httpClient;

    public GetOrder()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> GetOrderAsync(string accessToken)
    {
        try
        {
            Console.Write("Enter Order Number: ");
            int orderNumber;
            if (!int.TryParse(Console.ReadLine(), out orderNumber))
            {
                Console.WriteLine("Invalid input for order number.");
                return false;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            string baseUrl = "https://vbi.okonomibistand.no/VBInterfaceOBIDev";
            string endpoint = $"/api/Order/{orderNumber}"; // Update endpoint for order
            string requestUrl = $"{baseUrl}{endpoint}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                return false;
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            // Pretty print the JSON response
            var formattedJson = Newtonsoft.Json.JsonConvert.SerializeObject(Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse), Newtonsoft.Json.Formatting.Indented);

            // Log the formatted JSON response
            Console.WriteLine($"Order Data:\n{formattedJson}");

            // Deserialize the JSON response into your order data type, if needed
            // Example: var orderData = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(jsonResponse);

            return true;
        }
        catch (Exception ex)
        {
            // Log the entire exception for detailed error information
            Console.WriteLine($"Failed to get order data. Error: {ex.ToString()}");
            return false;
        }
    }
}
