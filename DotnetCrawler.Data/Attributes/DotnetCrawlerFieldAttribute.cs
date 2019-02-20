using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCrawler.Data.Attributes
{
    public class DotnetCrawlerFieldAttribute : Attribute
    {
        public string Expression { get; set; }
        public SelectorType SelectorType { get; set; }
    }
}
