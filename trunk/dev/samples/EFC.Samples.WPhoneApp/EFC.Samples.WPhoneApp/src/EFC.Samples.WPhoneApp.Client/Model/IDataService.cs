using System;
using System.Collections.Generic;
using System.Text;

namespace EFC.Samples.WPhoneApp.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}
