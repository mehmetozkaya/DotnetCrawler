using System;
using System.Collections.Generic;

namespace DotnetCrawler.Data.Models
{
    public partial class Baskets
    {
        public Baskets()
        {
            BasketItem = new HashSet<BasketItem>();
        }

        public int Id { get; set; }
        public string BuyerId { get; set; }

        public virtual ICollection<BasketItem> BasketItem { get; set; }
    }
}
