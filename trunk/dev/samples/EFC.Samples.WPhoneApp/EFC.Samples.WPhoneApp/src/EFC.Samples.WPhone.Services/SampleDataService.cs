using System;
using System.Collections.Generic;
using EFC.Samples.WPhone.Service.Contracts;
using EFC.Samples.WPhone.Service.Contracts.Dtos;
using EFC.Samples.WPhone.Services.Application;
using EFC.Service.Phone;
using Microsoft.Practices.Unity;

namespace EFC.Samples.WPhone.Services
{
    public class SampleDataService :BusinessService, ISampleDataService
    {
        /// <summary>
        /// Gets or sets as sample.
        /// </summary>
        /// <value>
        /// As sample.
        /// </value>
        [Dependency]
        public SampleApplicationService AsSample { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleDataService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        public SampleDataService(IUnityContainer unity) : base(unity)
        {
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDto> GetAllUsers()
        {
            return new ArraySegment<UserDto>();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override int Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
