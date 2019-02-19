using System;
using System.Collections.Generic;

namespace DotnetCrawler.Data.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string BuyerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string ShipToAddressCity { get; set; }
        public string ShipToAddressCountry { get; set; }
        public string ShipToAddressState { get; set; }
        public string ShipToAddressStreet { get; set; }
        public string ShipToAddressZipCode { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
