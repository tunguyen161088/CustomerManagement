using System;

namespace Data
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }
    }
}
