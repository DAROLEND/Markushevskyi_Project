using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int JewelryId { get; set; }
        public virtual Jewelry Jewelry { get; set; }

        public int Quantity { get; set; }
    }
}
