using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
