using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCrawler.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
    }
}
