using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Tokencall
{
    private readonly HttpClient _httpClient;

    public Tokencall()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> FetchTokenAsync()
    {
        try
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            string tokenEndpoint = "https://vbi.okonomibistand.no/VBInterfaceOBIDev/Token";
            string requestBody = $"grant_type=password&username={username}&password={password}";
            var content = new StringContent(requestBody, Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await _httpClient.PostAsync(tokenEndpoint, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(responseBody);

            string accessToken = jsonResponse["access_token"].ToString();
            Console.WriteLine($"Token received: {accessToken}");
            return accessToken;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to fetch token. Error: {ex.Message}");
            return null;
        }
    }
}
