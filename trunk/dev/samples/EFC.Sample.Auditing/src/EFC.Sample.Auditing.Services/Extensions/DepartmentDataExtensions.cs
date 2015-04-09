//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-03-05 - 16.15.30
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using EFC.Sample.Auditing.Data.Contracts.Dto;
using EFC.Sample.Auditing.Services.Data;

namespace EFC.Sample.Auditing.Services.Extensions
{

    /// <summary>
    /// Assembler for <see cref="DepartmentData"/> and <see cref="DepartmentDataDto"/>.
    /// </summary>
    public static partial class DepartmentDataExtensions
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="DepartmentDataDto"/> converted from <see cref="DepartmentData"/>.</param>
        static partial void OnDTO(this DepartmentData entity, DepartmentDataDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="DepartmentData"/> converted from <see cref="DepartmentDataDto"/>.</param>
        static partial void OnEntity(this DepartmentDataDto dto, DepartmentData entity);

        /// <summary>
        /// Converts this instance of <see cref="DepartmentDataDto"/> to an instance of <see cref="DepartmentData"/>.
        /// </summary>
        /// <param name="dto"><see cref="DepartmentDataDto"/> to convert.</param>
        public static DepartmentData ToEntity(this DepartmentDataDto dto)
        {
            if (dto == null) return null;

            var entity = new DepartmentData();

            entity.Id = dto.Id;
            entity.DepartmentName = dto.DepartmentName;
            entity.Location = dto.Location;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="DepartmentData"/> to an instance of <see cref="DepartmentDataDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="DepartmentData"/> to convert.</param>
        public static DepartmentDataDto ToDTO(this DepartmentData entity)
        {
            if (entity == null) return null;

            var dto = new DepartmentDataDto();

            dto.Id = entity.Id;
            dto.DepartmentName = entity.DepartmentName;
            dto.Location = entity.Location;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="DepartmentDataDto"/> to an instance of <see cref="DepartmentData"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<DepartmentData> ToEntities(this IEnumerable<DepartmentDataDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="DepartmentData"/> to an instance of <see cref="DepartmentDataDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<DepartmentDataDto> ToDTOs(this IEnumerable<DepartmentData> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
