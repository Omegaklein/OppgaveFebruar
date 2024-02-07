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
            Getcustomer apiCaller = new Getcustomer();
            await apiCaller.GetCustomerByCustomerNumber();

        }
    }
}