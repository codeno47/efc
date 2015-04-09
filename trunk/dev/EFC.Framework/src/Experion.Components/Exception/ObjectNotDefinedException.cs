// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ObjectNotDefinedException.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ObjectNotDefinedException.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------
namespace EFC.Components.Exception
{
    /// <summary>
    /// ObjectNotDefinedException.
    /// </summary>
    public class ObjectNotDefinedException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotDefinedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ObjectNotDefinedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotDefinedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public ObjectNotDefinedException(string message, System.Exception exception)
            : base(message, exception)
        {
        }
    }
}
