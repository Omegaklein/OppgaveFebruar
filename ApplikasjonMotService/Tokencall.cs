using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RobinOgMarius
{
    public class Tokencall
    {
        public async Task CallApi()
        {
            string endepunkt = "Token";
            string url = $"https://vbi.okonomibistand.no/VBInterfaceOBIDev/{endepunkt}"; // URL til APIet hvor token skal hentes
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine(); // Husk at passordet vises i klartekst i terminalen
            // For å unngå dette, kan dere legge inn brukernavn og passord i User Secrets, dette forhindrer også at dere sender det inn på Github
            // HøyereKlikk på RobinOgMarius -> Manage User Secrets -> Legg inn brukernavn og passord
            // Brukernavn og passord sendes inn i bodyen til en POST-request
            // Dette er en form for autentisering som kalles "Resource Owner Password Credentials Grant"
            // Som forteller APIet hvilken type autentisering som blir brukt...


            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("hei");
                var content = new StringContent($"grant_type=password&username={"Brukernavn"}&password={"Passord"}", Encoding.UTF8, "application/x-www-form-urlencoded");

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode) // Sjekker om requesten var vellykket
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
        }
    }
}