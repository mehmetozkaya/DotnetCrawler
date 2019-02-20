using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCrawler.Downloader
{
    public class DotnetCrawlerDownloader : IDotnetCrawlerDownloader
    {
        public DotnetCrawlerDownloaderType DownloderType { get; set; }
        public string DownloadPath { get; set; }
        private string _localFilePath;

        public DotnetCrawlerDownloader()
        {

        }

        public async Task<HtmlDocument> Download(string crawlUrl)
        {
            // if exist dont download again
            PrepareFilePath(crawlUrl);

            var existing = GetExistingFile(_localFilePath);
            if (existing != null)
                return existing;

            return await DownloadInternal(crawlUrl);
        }

        private async Task<HtmlDocument> DownloadInternal(string crawlUrl)
        {
            switch (DownloderType)
            {
                case DotnetCrawlerDownloaderType.FromFile:
                    using (WebClient client = new WebClient())
                    {
                        await client.DownloadFileTaskAsync(crawlUrl, _localFilePath);
                    }
                    return GetExistingFile(_localFilePath);

                case DotnetCrawlerDownloaderType.FromMemory:
                    var htmlDocument = new HtmlDocument();
                    using (WebClient client = new WebClient())
                    {
                        string htmlCode = await client.DownloadStringTaskAsync(crawlUrl);
                        htmlDocument.LoadHtml(htmlCode);
                    }
                    return htmlDocument;

                case DotnetCrawlerDownloaderType.FromWeb:
                    HtmlWeb web = new HtmlWeb();
                    return await web.LoadFromWebAsync(crawlUrl);
            }

            throw new InvalidOperationException("Can not load html file from given source.");
        }

        private void PrepareFilePath(string fileName)
        {
            var parts = fileName.Split('/');
            parts = parts.Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
            var htmlpage = string.Empty;
            if (parts.Length > 0)
            {
                htmlpage = parts[parts.Length - 1];
            }

            if (!htmlpage.Contains(".html"))
            {
                htmlpage = htmlpage + ".html";
            }
            htmlpage = htmlpage.Replace("=", "").Replace("?", "");

            _localFilePath = $"{DownloadPath}{htmlpage}";
        }

        private HtmlDocument GetExistingFile(string fullPath)
        {
            try
            {
                var htmlDocument = new HtmlDocument();
                htmlDocument.Load(fullPath);
                return htmlDocument;
            }
            catch (Exception exception)
            {
            }
            return null;
        }

    }
}
