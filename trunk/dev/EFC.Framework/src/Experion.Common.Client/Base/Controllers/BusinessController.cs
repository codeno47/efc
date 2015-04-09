// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="BusinessController.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="BusinessController.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using EFC.Components.Unity;

namespace EFC.Client.Common.Base.Controllers
{
    /// <summary>
    /// BusinessController.
    /// </summary>
    public  abstract class BusinessController : IBusinessController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessController"/> class.
        /// </summary>
        protected BusinessController()
        {
            unityContainer = UnityContainerManager.GetInstance();
        }


        /// <summary>
        /// Gets the unity.
        /// </summary>
        public UnityContainerManager Unity
        {
            get { return unityContainer; }
        }

        /// <summary>
        /// UnityContainerManager.
        /// </summary>
        private readonly UnityContainerManager unityContainer;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}