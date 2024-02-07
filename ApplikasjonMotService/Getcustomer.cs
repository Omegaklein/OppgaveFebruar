using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RobinOgMarius
{
    public class CustomerInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string MobilePhone { get; set; }
    }

    public class Getcustomer
    {
        private readonly HttpClient _client;

        public Getcustomer(string token)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // Set token in Authorization header
        }

        public async Task GetCustomerByCustomerNumber()
        {
            Console.WriteLine("Enter customer number: ");
            string customerNumber = Console.ReadLine();

            string endpoint = $"api/Customer/{customerNumber}";
            string baseUrl = "https://vbi.okonomibistand.no/VBInterfaceOBIDev/";
            string fullUrl = $"{baseUrl}{endpoint}";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    CustomerInfo customerInfo = JsonConvert.DeserializeObject<CustomerInfo>(responseBody);
                    Console.WriteLine("Customer Information:");
                    Console.WriteLine($"Name: {customerInfo.Name}");
                    Console.WriteLine($"Id: {customerInfo.Id}");
                    Console.WriteLine($"Mobile Phone: {customerInfo.MobilePhone}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
