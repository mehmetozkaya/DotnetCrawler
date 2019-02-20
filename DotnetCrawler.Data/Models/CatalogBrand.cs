using DotnetCrawler.Data.Repository;
using System;
using System.Collections.Generic;

namespace DotnetCrawler.Data.Models
{
    public partial class CatalogBrand : IEntity
    {
        public CatalogBrand()
        {
            Catalog = new HashSet<Catalog>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<Catalog> Catalog { get; set; }
    }
}
