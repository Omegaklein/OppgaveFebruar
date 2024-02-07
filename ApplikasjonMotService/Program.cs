using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RobinOgMarius
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GetCustomerNumber apiCaller = new GetCustomerNumber();
            await apiCaller.GetCustomerByCustomerNumber();

        }
    }
}