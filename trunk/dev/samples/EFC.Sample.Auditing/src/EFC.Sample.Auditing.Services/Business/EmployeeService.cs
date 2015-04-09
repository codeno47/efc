namespace EFC.Sample.Auditing.Services.Business
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using EFC.Common.Service;
    using EFC.Sample.Auditing.Data.Contracts.Dto;
    using EFC.Sample.Auditing.Services.Application;
    using EFC.Sample.Auditing.Services.Contracts;
    using EFC.Sample.Auditing.Services.Data;
    using EFC.Sample.Auditing.Services.Extensions;

    using Microsoft.Practices.Unity;

    public class EmployeeService : BusinessService, IEmployeeService
    {
        /// <summary>
        /// Gets or sets as employee service.
        /// </summary>
        /// <value>
        /// As employee service.
        /// </value>
        [Dependency]
        public AsEmployeeService AsEmployeeService { get; set; }

        public EmployeeService(IUnityContainer unity)
            : base(unity)
        {

        }

        public override int Save()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public EmployeeDataDto AddEmployee(EmployeeDataDto employee)
        {
            var added = AsEmployeeService.AddEmployee(employee.ToEntity());

            if (added != null)
            {
                return added.ToDTO();
            }
            return null;
        }

        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void Update(EmployeeDataDto employee)
        {
            AsEmployeeService.Update(employee.ToEntity());
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDataDto> GetAllEmployees()
        {
            return AsEmployeeService.GetAllEmployees().ToDTOs();
        }
    }
}
