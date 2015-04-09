using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using EFC.Samples.Service.Data;
using Experion.Client.Common.WorkItem;
using Experion.Components.Data;

namespace EFC.Samples.Logging
{
    public class LoggingWorkItem : WorkItem
    {
        public LoggingWorkItem()
        {
            
        }
        protected override void OnWorkItemStart()
        {
           base.OnWorkItemStart();
        
        }

        public void RegisterItems()
        {

        }
    }
}
