using System;
using System.Threading.Tasks;

namespace RobinOgMarius
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string token = null;
            var tokencall = new Tokencall();


            while (string.IsNullOrEmpty(token))
            {
                token = await tokencall.CallApi();

                if (string.IsNullOrEmpty(token))
                {
                    Console.WriteLine("Failed to get token. Please try again.");
                }
                else
                {
                    Console.WriteLine("Token received.");
                }
            }

            // Ask the user what action to perform
            Console.WriteLine("What action do you want to perform?");
            Console.WriteLine("1. Get Customer");
            Console.WriteLine("2. Other action");

            // Read user input
            string actionChoice = Console.ReadLine();

            switch (actionChoice)
            {
                case "1":
                    // Perform the action to get customer
                    var getCustomer = new Getcustomer(token);
                    await getCustomer.GetCustomerByCustomerNumber();
                    break;
                case "2":
                    // Perform other action
                    // Add your code here for other actions
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid action.");
                    break;
            }
        }
    }
}
