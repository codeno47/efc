// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="UnityContainerManager.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="UnityContainerManager.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace EFC.Components.Unity
{
    /// <summary>
    /// UnityContinerManager.
    /// </summary>
    public sealed class UnityContainerManager : IUnityContainerManager
    {
        #region Fields

        private static UnityContainerManager containermanager;

        /// <summary>
        /// Unity container.
        /// </summary>
        private static IUnityContainer container = new UnityContainer();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the container.
        /// </summary>
        public IUnityContainer Container
        {
            get { return container; }
        }

        #endregion Properties

        /// <summary>
        /// Initializes the <see cref="UnityContainerManager"/> class.
        /// </summary>
        private UnityContainerManager()
        {
            InitilizeContainer();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>UnityContainerManager.</returns>
        public static UnityContainerManager GetInstance()
        {
            return containermanager ?? (containermanager = new UnityContainerManager());
        }

        /// <summary>
        /// Initializes the container.
        /// </summary>
        private void InitilizeContainer()
        {
            container = new UnityContainer();

            var section = LoadUnityConfigurationFile();
            section.Configure(container, "parent");
            section.Containers.Default.Configure(container);
        }

        /// <summary>
        /// Loads the unity configuration file.
        /// </summary>
        /// <returns>UnityConfigurationSection.</returns>
        private UnityConfigurationSection LoadUnityConfigurationFile()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            return section;
        }

        /// <summary>
        /// Resolves for a type.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="registrationName">Name of the registration.</param>
        /// <returns>TInstance.</returns>
        public TInstance ResolveFor<TInstance>(string registrationName)
        {
            return Container.Resolve<TInstance>(registrationName);
        }

        /// <summary>
        /// Resolves for a type.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <returns>TInstance.</returns>
        public TInstance ResolveFor<TInstance>()
        {
            return Container.Resolve<TInstance>();
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="instance">The instance.</param>
        public void RegisterInstance<TInstance>(TInstance instance)
        {
            Container.RegisterInstance(instance);
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name.</param>
        public void RegisterInstance<TInstance>(TInstance instance, string name)
        {
            Container.RegisterInstance(name, instance);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            container.Dispose();
        }
    }
}