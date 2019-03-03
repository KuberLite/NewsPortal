using NewsPortal.FetcherFacade;
using System;
using System.Text;
using System.Xml;

namespace NewsPortal.ConsoleSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Read.GetRequest("https://www.interfax.by/news/feed").Wait();
        }
    }
}
