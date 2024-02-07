using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public Getcustomer()
        {
            _client = new HttpClient();
            // Assuming your bearer token is valid and you understand the security implications of hardcoding it
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "vBvQrqS3JXHxvuZPk44gqchCNXppm_0YRKgdfUapsD5w6sWz0U7O-gdEVqWiYJxiERKbqW0_POxi3FvNqKiiWSWiwz_fcXGc5Ku6EHRoO_UXtnL8uHUuFeKV1lX5jDV5eZKrsIO6uju7t2MLHTGGFu5xmD4hoNQ65bMW0OY_gW-oFkM_Dxc_-Jbb8S1aEqgVsL_WIRfuIhBQXNETSxFa0Tfo2aI-h8UM3LQafvyMfOjESAxv5F8JKaW2hDs8DrZbMx-Gkm0YydoN-ZJGKb2P1hWUkRit6fTYNVrFrT3O93dwnsAlJYgktp6HnZsJq9Vrn-VCsnyPkvWpnPvYzeE3gwLil2BoppKAGbmfs9IB6U5eMYVTCHCTebQvKImOXjqdjSjY7eqlPu5qrhyZ1mSTSdmspR51M2m0Y92w2NokGuQwmVqpHE0-NpSon9C937dO9rHCKax-CXXFwMLuIZXsuhA-uDAaY_wFAKeXJjWOaPeu0v4W-1d7XL4rFCZjuss7qd9spNozTxyQ8A1K4equOeT1uf-zBtxmRQ3EiEDuTD3pJBFq4g-h0qkU34qR5ih3MfLZfmW0hLZnFtiSv4knHckdVmndD3-Sl63FPENSWKald11eZKUT8Ukpfph2ghncF28fzAsGXRvw9CKpwAorCFH-9KGIOtEFWxGRr5phuLNf1mtB5c4zotkQAJFPVZG7WtIOjDAmI-b4wpEiqxufgLo2YR_o1InoGMQ7SEtlzl8YSSiYt9ZcFmWZ1XZPg1_oHgFUJ2rFKuXQX7EAhhGfBMJhZFOff1eiY8VjVNwwIftteCzOv_LiDEY5DXrn3YsQTGfXr-qxM5EZO_Oe6kwZvy2O2M6gl0ribNR_eLhHTTymObl-lUSoV-acGIt477R7UHeXHhs3hY0wKeIFN645qQ");
        }

        public async Task GetCustomerByCustomerNumber()
        {
            Console.WriteLine("Enter customer number: ");
            string customerNumber = Console.ReadLine();

            // Correctly using string interpolation to insert the customer number into the URL
            string endpoint = $"api/Customer/{customerNumber}";
            string baseUrl = "https://vbi.okonomibistand.no/VBInterfaceOBIDev/";
            string fullUrl = $"{baseUrl}{endpoint}";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Deserialize the JSON response into a CustomerInfo object
                    CustomerInfo customerInfo = JsonConvert.DeserializeObject<CustomerInfo>(responseBody);
                    // Displaying customer information
                    Console.WriteLine("Customer Information:");
                    Console.WriteLine($"Name: {customerInfo.Name}");
                    Console.WriteLine($"Id: {customerInfo.Id}");
                    Console.WriteLine($"Mobile Phone: {customerInfo.MobilePhone}");
                    // Add more properties as needed
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
