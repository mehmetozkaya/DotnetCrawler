using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCrawler.Scheduler
{
    public interface IDotnetCrawlerScheduler
    {
        long RetryTime { get; set; }
        Task Schedule();
    }
}
