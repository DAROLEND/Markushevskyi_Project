using System;
using System.Collections.Generic;

namespace JewelryStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual List<OrderItem> Items { get; set; }
    }
}
