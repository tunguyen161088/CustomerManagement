using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace CustomerManagement.Services
{
    public interface IOrderHelper
    {
        Task<List<Order>> GetOrdersByCustomerAsync(int customerId);
    }

    public class OrderHelper: IOrderHelper
    {
        public Task<List<Order>> GetOrdersByCustomerAsync(int customerId)
        {
            var orders = new List<Order>();

            using (var sr = new StreamReader(string.Concat(Environment.CurrentDirectory, @"/Data/Orders.txt")))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var fields = line.Split(',');

                    //orderid customerid quantity date
                    if (Convert.ToInt32(fields[1]) != customerId) continue;

                    orders.Add(new Order
                    {
                        CustomerId = customerId,
                        OrderId = Convert.ToInt32(fields[0]),
                        Quantity = Convert.ToInt32(fields[2]),
                        Date = Convert.ToDateTime(fields[3])
                    });
                }
            }

            return Task.Run(()=> orders);
        }
    }
}
