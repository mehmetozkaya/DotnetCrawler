using DotnetCrawler.Core;
using DotnetCrawler.Data.Models;
using DotnetCrawler.Downloader;
using DotnetCrawler.Pipeline;
using DotnetCrawler.Processor;
using DotnetCrawler.Request;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCrawler.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();           
        }

        static async Task MainAsync(string[] args)
        {
            var crawleUrl = "https://www.ebay.com/b/Apple-iPhone/9355/bn_319682";

            var crawler = new DotnetCrawler<Catalog>()
                                 .AddRequest(new DotnetCrawlerRequest { Url = crawleUrl, Regex = @".*itm/.+", TimeOut = 5000 })
                                 .AddDownloader(new DotnetCrawlerDownloader { DownloderType = DotnetCrawlerDownloaderType.FromMemory, DownloadPath = @"C:\DotnetCrawlercrawler\" })
                                 .AddProcessor(new DotnetCrawlerProcessor<Catalog> { })
                                 .AddPipeline(new DotnetCrawlerPipeline<Catalog> { });

            await crawler.Crawle();
        }
    }
}
