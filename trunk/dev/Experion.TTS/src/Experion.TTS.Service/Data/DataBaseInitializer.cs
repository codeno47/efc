#region FileHeader
// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="DataBaseInitializer.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="DataBaseInitializer.cs"/> file.
// // </summary>
// // //---------------------------------------------------------------------------------------------
#endregion

using System.Data.Entity;
using Experion.TTS.Service.Model;

namespace Experion.TTS.Service.Data
{
    /// <summary>
    /// The data base initializer.
    /// </summary>
    public class DataBaseInitializer : IDatabaseInitializer<Entities>
    {
        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public void InitializeDatabase(Entities context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
