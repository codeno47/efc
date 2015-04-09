// //----------------------------------------------------------------------------
// // <copyright company="iAquaSYS" file ="ExceptionBootstrap.cs">
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without iAquaSYS prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ExceptionBootstrap.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

namespace EFC.Components.Exception
{
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

    /// <summary>
    /// Initializes Exception block.
    /// </summary>
    public class ExceptionBootstrap
    {
        /// <summary>
        /// Initializes this instance.
        /// Call this method to set default exception manager.
        /// </summary>
        public static void Initilize()
        {
            var config = ConfigurationSourceFactory.Create();
            var factory = new ExceptionPolicyFactory(config);

            var exceptionManager = factory.CreateManager();

            ExceptionPolicy.SetExceptionManager(exceptionManager);
        }
    }
}
