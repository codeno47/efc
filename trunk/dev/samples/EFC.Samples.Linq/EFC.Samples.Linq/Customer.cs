using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Samples.Linq
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Catagory { get; set; }

        public List<Address> CustomerAddresss { get; set; }
    }
}
