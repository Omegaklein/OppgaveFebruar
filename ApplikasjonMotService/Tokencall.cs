using Newtonsoft.Json.Linq;
using System.Text;

public class Tokencall
{
    public async Task<string> CallApi()
    {
        string endepunkt = "Token";
        string url = $"https://vbi.okonomibistand.no/VBInterfaceOBIDev/{endepunkt}";

        Console.WriteLine("Enter username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();

        using (HttpClient client = new HttpClient())
        {
            var content = new StringContent($"grant_type=password&username={username}&password={password}", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody); // Print the response

                // Parse the JSON response
                JObject jsonResponse = JObject.Parse(responseBody);
                string accessToken = jsonResponse["access_token"].ToString();

                return accessToken; // Return the access token
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null; // Return null if request fails
            }
        }
    }
}
