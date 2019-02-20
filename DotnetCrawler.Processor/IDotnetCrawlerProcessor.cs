using DotnetCrawler.Data.Repository;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCrawler.Processor
{
    public interface IDotnetCrawlerProcessor<TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> Process(HtmlDocument document);
    }
}
