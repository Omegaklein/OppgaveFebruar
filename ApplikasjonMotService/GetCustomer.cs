using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RobinOgMarius
{
    public class GetCustomer
    {
        public async Task CallApi()
        {
            string endpoint = "api/Customer/61043";
            string url = $"https://vbi.okonomibistand.no/VBInterfaceOBIDev/{endpoint}";

            string bearerToken = "1NLtnUyoSSSAmvXhRBMJ5aXJyzEtyIIGWF8_vV2vPIV4zABh25FjnoX3eEVgBXBBvF1EiZYaSt_ius-Xa05-8CUjE7QwqOKyM4hL4KUkUja-OFQjfJtj5GSjyPmnKOLfxbN_1l8Oval249EAd9hGTBY1j4hQgU69KrkoEG_t9RHEeubUKnyAaJLfUR41J704gIOEmzjiC2uNdaV8nXjE4NkUo06nHZFrGWtY26oWzsPz7qBIPnbWujcP732vabc2UAlfDxFu6k71p_L8H1odX8N_1dhfFrTexuu7Mt05zoFtOTDE7henps9tNpmjsBFN7GupUCqpst6R6vThlC5nRycCezAif_Re83kvpMki2kGVLLvruPu1QvHNHnLdiZKN9eM2kSEuHBljXumnyZWj8kkyGYWWTDhjyb3Y3bTIWcedPyoj8sAGnmMK73fXMxMMktjeUXFcx0klDJNlIiEakp04jchZUGcB8WKVMM3K4PJd6P4K8tY7_HMCQzrgfw87296qicYuU81OUblytIZcrTDTV2eBNQm_2_egjh2VJfk8Aj1PJ1QSwf3wJ-XPVE63m1ub-tiFHDoak0QYRQ-KNhZwgc5WxGINpQwc9x1kACSTRn-LdZiwEHSzSdW2hSvjP4ejN5AkLu-hTG5LD_rzBVrH6wdzdbRQ_g0rooCJvNhmVia-KacLLL3WeoYO5iMF4MsrM9UjcBBhZcMDqvaSAiZ_ojbMdeLwF7Qrrew3WAyqYnQovWAK6P6iyMr7Emm6h-H_pxr8-9AQI4RP2MdvwxTzIdTS7CFq09soz2pwYlhhrBNcsnFy0nDtDa_xM3VfMzugUgC9EJVfh1S0x_WJ5WKsu917OjruTD_C1eqigD6ZDuYgk2EFeP79ZW88BKo_44NxyA-fOsVJVGMsDuDE0w";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented));
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request error: {ex.Message}");
                }
            }
        }
    }
}
