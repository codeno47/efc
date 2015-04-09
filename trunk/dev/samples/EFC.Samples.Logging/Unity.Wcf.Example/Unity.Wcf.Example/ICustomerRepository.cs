using System.Linq;

namespace Unity.Wcf.Example
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Query();
    }
}