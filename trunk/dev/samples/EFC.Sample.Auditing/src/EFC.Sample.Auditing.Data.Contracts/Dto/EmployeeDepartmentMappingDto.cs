//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-03-05 - 16.15.29
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EFC.Sample.Auditing.Data.Contracts.Dto
{
    [DataContract()]
    public partial class EmployeeDepartmentMappingDto
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public Int32 DepartmentId { get; set; }

        [DataMember()]
        public Int32 EmployeeId { get; set; }

        [DataMember()]
        public DepartmentDataDto DepartmentData { get; set; }

        [DataMember()]
        public EmployeeDataDto EmployeeData { get; set; }

        public EmployeeDepartmentMappingDto()
        {
        }

        public EmployeeDepartmentMappingDto(Int32 id, Int32 departmentId, Int32 employeeId, DepartmentDataDto departmentData, EmployeeDataDto employeeData)
        {
			this.Id = id;
			this.DepartmentId = departmentId;
			this.EmployeeId = employeeId;
			this.DepartmentData = departmentData;
			this.EmployeeData = employeeData;
        }
    }
}
