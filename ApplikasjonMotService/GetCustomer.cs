using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class GetCustomer
{
    private readonly HttpClient _httpClient;

    public GetCustomer()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> GetCustomerAsync(string accessToken)
    {
        try
        {
            Console.Write("Enter Customer Number: ");
            int customerNumber;
            if (!int.TryParse(Console.ReadLine(), out customerNumber))
            {
                Console.WriteLine("Invalid input for customer number.");
                return false;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            string baseUrl = "https://vbi.okonomibistand.no/VBInterfaceOBIDev";
            string endpoint = $"/api/Customer/{customerNumber}";
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
            Console.WriteLine($"Customer Data:\n{formattedJson}");

            // Deserialize the JSON response into your customer data type, if needed
            // Example: var customerData = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(jsonResponse);

            return true;
        }
        catch (Exception ex)
        {
            // Log the entire exception for detailed error information
            Console.WriteLine($"Failed to get customer data. Error: {ex.ToString()}");
            return false;
        }
    }
}
