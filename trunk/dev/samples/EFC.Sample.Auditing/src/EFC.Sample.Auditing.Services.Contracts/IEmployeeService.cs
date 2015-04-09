using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Sample.Auditing.Services.Contracts
{
    using EFC.Sample.Auditing.Data.Contracts.Dto;

    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        EmployeeDataDto AddEmployee(EmployeeDataDto employee);

        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        void Update(EmployeeDataDto employee);

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeDataDto> GetAllEmployees();
    }
}
