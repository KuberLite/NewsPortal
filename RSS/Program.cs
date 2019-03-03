using NewsPortal.FetcherFacade;
using NewsPortal.FetcherFacade.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewsPortal.ConsoleSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await Handle()).Wait();
        }

        private static async Task Handle()
        {
        }
    }
}
