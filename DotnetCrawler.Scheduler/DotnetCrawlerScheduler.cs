using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCrawler.Scheduler
{
    public class DotnetCrawlerScheduler : IDotnetCrawlerScheduler
    {
        public long RetryTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task Schedule()
        {
            throw new NotImplementedException();
        }
    }
}
