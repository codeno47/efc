// //---------------------------------------------------------------------------------------------
// // <copyright company="OnboarD Cyber Cafe" file ="IRemoteHandler.cs">
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without OnboarD Cyber Cafe's prior written authorization
// // </copyright>
// //---------------------------------------------------------------------------------------------

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
