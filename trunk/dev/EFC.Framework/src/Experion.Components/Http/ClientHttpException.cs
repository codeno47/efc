// // <copyright company="OnboarD Cyber Cafe" file ="ClientHttpException.cs">
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without OnboarD Cyber Cafe's prior written authorization
// // </copyright>
// //---------------------------------------------------------------------------------------------

namespace EFC.Components.Http
{
    using System;

    /// <summary>
    /// http exception class 
    /// </summary>
    [Serializable]
    public class ClientHttpException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientHttpException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ClientHttpException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientHttpException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public ClientHttpException(string message, System.Exception exception)
            : base(message, exception)
        {
        }
    }
}
