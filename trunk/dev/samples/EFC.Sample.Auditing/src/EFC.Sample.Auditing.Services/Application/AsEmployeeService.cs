using System.Data.Entity;

using Microsoft.Practices.Unity;

namespace EFC.Sample.Auditing.Services.Application
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using EFC.Common.Service;
    using EFC.Components.Data;
    using EFC.Sample.Auditing.Data.Contracts.Dto;
    using EFC.Sample.Auditing.Services.Data;

    /// <summary>
    /// Application Service
    /// </summary>
    public class AsEmployeeService : ApplicationService<SampleContainer>
    {
        /// <summary>
        /// Gets the employee data repository.
        /// </summary>
        /// <value>
        /// The employee data repository.
        /// </value>
        private IRepository<EmployeeData, int> EmployeeDataRepository
        {
            get { return DataContext.GetRepository<EmployeeData, int>(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsEmployeeService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public AsEmployeeService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public EmployeeData AddEmployee(EmployeeData employee)
        {
            var added = EmployeeDataRepository.Add(employee);
            this.SaveChangesWithAudit();

            return added;
        }

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public EmployeeData GetEmployeeById(int id)
        {
            return EmployeeDataRepository.GetById(id);
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeData> GetAllEmployees()
        {
            return EmployeeDataRepository.GetAll();
        }

        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void Update(EmployeeData employee)
        {
            var found = GetEmployeeById(employee.Id);

            if (found != null)
            {
                ////Mapper.CreateMap<EmployeeData, EmployeeData>();
                ////Mapper.Map(employee, found);

                found.FirstName = employee.FirstName;

                this.SaveChangesWithAudit();
            }


            
        }
    }
}
