// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IRemoteHandler.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IRemoteHandler.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Http
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The interface IRemoteHandler 
    /// </summary>
    public interface IRemoteHandler : IDisposable
    {
        /// <summary>
        /// Processes the post request.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns>
        /// response generic instance
        /// </returns>
        Task<TInstance> ProcessPostRequest<TInstance>(string url, dynamic data);

        /// <summary>
        /// Processes the get request.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// response generic instance
        /// </returns>
        Task<TInstance> ProcessGetRequest<TInstance>(string url);
    }
}
