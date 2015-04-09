#region FileHeader
// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="FieldMaxRepositoryContext.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="FieldMaxRepositoryContext.cs"/> file.
// // </summary>
// // //---------------------------------------------------------------------------------------------
#endregion

using EFC.Components.Data;
using Experion.TTS.Service.Model;
using Microsoft.Practices.Unity;

namespace Experion.TTS.Service.Data
{
    /// <summary>
    ///     The field max repository context.
    /// </summary>
    public class TtsRepositoryContext : EFRepositoryContext<Entities>
    {
        #region Fields

        /// <summary>
        ///     The connection string.
        /// </summary>
        private readonly string connectionString;

        #endregion

        public TtsRepositoryContext(IUnityContainer container)
        {
            connectionString = container.Resolve<string>("ExperionEntities");
        }
        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <returns></returns>
        protected override Entities CreateContext()
        {
            return new Entities(connectionString);
        }
    }
}