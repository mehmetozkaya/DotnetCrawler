using DotnetCrawler.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCrawler.Pipeline
{
    public interface IDotnetCrawlerPipeline<TEntity> where TEntity : class, IEntity
    {
        Task Run(IEnumerable<TEntity> entity);
    }
}
