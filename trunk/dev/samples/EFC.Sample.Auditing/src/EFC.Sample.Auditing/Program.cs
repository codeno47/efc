using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Sample.Auditing
{
    using System.Configuration;

    using EFC.Components.Logging;
    using EFC.Sample.Auditing.Data.Contracts.Dto;
    using EFC.Sample.Auditing.Services.Contracts;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class Program
    {
        private static UnityContainer container;

        public static void Main(string[] args)
        {

            ConfigureContainer();

            AuditTrailBootStrapper.Initialize();

            var employeeService = container.Resolve<IEmployeeService>();

            //employeeService.AddEmployee(
            //    new EmployeeDataDto { DOB = DateTime.Now, FirstName = "binu", LastName = "bhasuran" });

            var employees = employeeService.GetAllEmployees();

            var firstEmployee = employees.FirstOrDefault();

            firstEmployee.FirstName = "Testupdate2";

            employeeService.Update(firstEmployee);
            
        }

        /// <summary>
        /// Configures the container.
        /// </summary>
        protected static void ConfigureContainer()
        {
            container = new UnityContainer();
            var unityConfigurationSection = LoadUnityConfigurationFile();
            unityConfigurationSection.Configure(container, "parent");
            container.RegisterInstance(container, new TransientLifetimeManager());
        }

        /// <summary>
        /// Loads the unity configuration file.
        /// </summary>
        /// <returns>UnityConfigurationSection.</returns>
        private static UnityConfigurationSection LoadUnityConfigurationFile()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            return section;
        }
    }
}
