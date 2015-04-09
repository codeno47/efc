// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ObjectNotDefinedException.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ObjectNotDefinedException.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
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
