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

            // PutCustomer putCustomer = new PutCustomer();
            // await putCustomer.PutCustomerAsync(accessToken);

            // PutOrder putOrder = new PutOrder();
            // await putOrder.PutOrderAsync(accessToken);

            // PutOrderLine PutOrderLine = new PutOrderLine();
            // await PutOrderLine.PutOrderLineAsync(accessToken);

            // GetCustomer getCustomer = new GetCustomer();
            // await getCustomer.GetCustomerAsync(accessToken);

            // GetOrder getOrder = new GetOrder();
            // await getOrder.GetOrderAsync(accessToken);

            // PostCustomer postCustomer = new PostCustomer();
            // await postCustomer.PostCustomerAsync(accessToken);

            // PostOrder postOrder = new PostOrder();
            // await postOrder.PostOrderAsync(accessToken);
        }
        else
        {
            Console.WriteLine("Failed to fetch token.");
        }
    }
}
