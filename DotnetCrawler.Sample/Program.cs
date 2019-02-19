using DotnetCrawler.Data.Models;
using System;
using System.Linq;

namespace DotnetCrawler.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new MicrosofteShopOnWebCatalogDbContext();
            var asd = context.Catalog.ToList();
        }
    }
}
