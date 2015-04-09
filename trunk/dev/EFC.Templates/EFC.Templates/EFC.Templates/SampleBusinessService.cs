using System;

using Microsoft.Practices.Unity;

namespace EFC.Templates
{
    using EFC.Common.Service;

    /// <summary>
    /// Business Service
    /// </summary>
    public class SampleBusinessService : BusinessService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleBusinessService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        public SampleBusinessService(IUnityContainer unity)
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
    }
}
