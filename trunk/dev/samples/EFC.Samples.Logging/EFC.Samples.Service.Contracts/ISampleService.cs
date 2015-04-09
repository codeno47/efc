using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Samples.Service.Contracts
{
    public interface ISampleService
    {
        string GetUserName(int id);
    }
}
