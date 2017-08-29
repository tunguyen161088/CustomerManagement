using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Data;

namespace CustomerManagement.Services
{
    public interface ICustomerHelper
    {
        Task<List<Customer>> GetCustomersAsync();
    }

    public class CustomerHelper: ICustomerHelper
    {
        public Task<List<Customer>> GetCustomersAsync()
        {
            var customers = new List<Customer>();

            using (var sr = new StreamReader(string.Concat(Environment.CurrentDirectory, @"/Data/Customers.txt")))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var fields = line.Split(',');

                    customers.Add(new Customer
                    {
                        CustomerId = Convert.ToInt32(fields[0]),
                        Name = fields[1]
                    });
                }
            }

            return Task.Run(() => customers);
        }
    }
}
