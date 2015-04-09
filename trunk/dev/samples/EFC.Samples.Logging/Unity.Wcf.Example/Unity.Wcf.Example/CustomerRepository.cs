using System.Collections.Generic;
using System.Linq;

namespace Unity.Wcf.Example
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>
                                                         {
                                                             new Customer(1, "Bill", "Smith"),
                                                             new Customer(2, "John", "Jones"),
                                                             new Customer(3, "Sarah", "Davis")
                                                         };

        public IQueryable<Customer> Query()
        {
            return _customers.AsQueryable();
        }
    }
}