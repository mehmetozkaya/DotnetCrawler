using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCrawler.Request
{
    public class DotnetCrawlerRequest : IDotnetCrawlerRequest
    {
        public string Url { get; set; }
        public string Regex { get; set; }
        public long TimeOut { get; set; }
    }
}
