using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCrawler.Downloader
{
    /// <summary>
    /// Type of the downloaders when crawler download source web
    /// </summary>
    public enum DotnetCrawlerDownloaderType
    {
        /// <summary>
        /// Download to local file
        /// </summary>
        FromFile,
        /// <summary>
        /// Without downloading to local file, download temp and directly use
        /// </summary>
        FromMemory,
        /// <summary>
        /// Read direct from web
        /// </summary>
        FromWeb
    }
}
