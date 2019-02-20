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

            const string CrawleUrl = "https://www.ebay.com/b/Apple-iPhone/9355/bn_319682";

            //var crawler = new CaldwellCrawler<Catalog>()
            //                     .AddRequest(new CaldwellRequest { Url = CrawleUrl, Regex = @".*itm/.+", TimeOut = 5000 })
            //                     .AddDownloader(new CaldwellDownloader { DownloderType = CaldwellDownloaderType.FromMemory, DownloadPath = @"C:\caldwellcrawler\" })
            //                     .AddProcessor(new CaldwellProcessor<Catalog> { })
            //                     .AddPipeline(new CaldwellPipeline<Catalog> { });

            //await crawler.Crawle();
        }
    }
}
