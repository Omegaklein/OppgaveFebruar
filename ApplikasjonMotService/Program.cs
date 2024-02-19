using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var tokencall = new Tokencall();

        // Prompt the user for username and password
        Console.WriteLine("Enter username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();

        // Fetch the token
        string token = await tokencall.GetAccessTokenAsync(username, password);

        if (token != null)
        {
            // You can now use the token as needed
            Console.WriteLine($"Token received: {token}");

            // Other program logic...
        }
        else
        {
            Console.WriteLine("Failed to fetch token. Exiting program.");
        }
    }
}
