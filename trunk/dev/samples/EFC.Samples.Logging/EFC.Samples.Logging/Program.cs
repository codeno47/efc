using System;
using System.Linq;
using EFC.Samples.Service.Contracts;

namespace EFC.Samples.Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            var workItem = new LoggingWorkItem();
            workItem.Start();

            var routeService = workItem.Unity.ResolveFor<IRouteService>();

            var plans = routeService.GetAllRoutes();
            var plandata = plans.FirstOrDefault();
            var found = routeService.GetBeatPlan(plandata);

          
            foreach (var route in plans)
            {
                Console.WriteLine(string.Format("Description :{0}", route.Description));
                Console.WriteLine(string.Format("PlanName :{0}", route.PlanName));
                Console.WriteLine(string.Format("Target :{0}", route.Target));
                Console.WriteLine("----------------------------------");
            }
            Console.ReadKey();
        }
    }
}
