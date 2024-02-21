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

            while (true)
            {
                Console.WriteLine("Choose an action to execute:");
                Console.WriteLine("1. PutCustomer");
                Console.WriteLine("2. PutOrder");
                Console.WriteLine("3. PutOrderLine");
                Console.WriteLine("4. GetCustomer");
                Console.WriteLine("5. GetOrder");
                Console.WriteLine("6. PostCustomer");
                Console.WriteLine("7. PostOrder");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PutCustomer putCustomer = new PutCustomer();
                        await putCustomer.PutCustomerAsync(accessToken);
                        break;

                    case "2":
                        PutOrder putOrder = new PutOrder();
                        await putOrder.PutOrderAsync(accessToken);
                        break;

                    case "3":
                        PutOrderLine putOrderLine = new PutOrderLine();
                        await putOrderLine.PutOrderLineAsync(accessToken);
                        break;

                    case "4":
                        GetCustomer getCustomer = new GetCustomer();
                        await getCustomer.GetCustomerAsync(accessToken);
                        break;

                    case "5":
                        GetOrder getOrder = new GetOrder();
                        await getOrder.GetOrderAsync(accessToken);
                        break;

                    case "6":
                        PostCustomer postCustomer = new PostCustomer();
                        await postCustomer.PostCustomerAsync(accessToken);
                        break;

                    case "7":
                        PostOrder postOrder = new PostOrder();
                        await postOrder.PostOrderAsync(accessToken);
                        break;

                    case "0":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Failed to fetch token.");
        }
    }
}
