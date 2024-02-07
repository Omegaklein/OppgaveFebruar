using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Project -> Manage NuGet Packages -> Search for Newtonsoft.Json -> Install

//Console.WriteLine("Hello, Marius og Robin!");

namespace RobinOgMarius
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GetCustomer getCustomer = new GetCustomer();
            await getCustomer.CallApi();
        }
    }
}