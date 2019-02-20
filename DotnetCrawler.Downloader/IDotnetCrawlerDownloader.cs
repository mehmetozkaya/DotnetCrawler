using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCrawler.Downloader
{
    public interface IDotnetCrawlerDownloader
    {
        DotnetCrawlerDownloaderType DownloderType { get; set; }
        string DownloadPath { get; set; }

        Task<HtmlDocument> Download(string crawlUrl);
    }
}
