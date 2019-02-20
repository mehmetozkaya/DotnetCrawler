using DotnetCrawler.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCrawler.Core
{
    public class DotnetCrawler<TEntity> : IDotnetCrawler where TEntity : class, IEntity
    {
        //public IDotnetCrawlerRequest Request { get; private set; }
        //public IDotnetCrawlerDownloader Downloader { get; private set; }
        //public IDotnetCrawlerProcessor<TEntity> Processor { get; private set; }
        //public IDotnetCrawlerScheduler Scheduler { get; private set; }
        //public IDotnetCrawlerPipeline<TEntity> Pipeline { get; private set; }
        public Task Crawle()
        {
            throw new NotImplementedException();
        }
    }
}
