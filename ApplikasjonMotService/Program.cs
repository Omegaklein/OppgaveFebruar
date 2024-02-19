using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Tokencall tokencaller = new Tokencall();
        string accessToken = await tokencaller.FetchTokenAsync();

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Token received, you can proceed with further actions here
            Console.WriteLine("Token received successfully.");

            // Call PutCustomer method
            // PutCustomer putCustomer = new PutCustomer();
            // await putCustomer.PutCustomerAsync(accessToken);

            // call PutOrder method
            //PutOrder putOrder = new PutOrder(); // Corrected class name to PutOrder
            //await putOrder.PutOrderAsync(accessToken); // Corrected method name to PutOrderAsync

            //call putorderline
            //putorderline putorderline = new putorderline();

        }
        else
        {
            Console.WriteLine("Failed to fetch token.");
        }
    }
}
