using System;
using System.Collections.Generic;
using System.Text;

namespace EFC.Samples.WPhoneApp.Model
{
    public class DataItem
    {
        public DataItem(string title)
        {
            Title = title;
        }

        public string Title
        {
            get;
            private set;
        }
    }
}
