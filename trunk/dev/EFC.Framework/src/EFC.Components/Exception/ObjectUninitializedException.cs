// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ObjectUninitializedException.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ObjectUninitializedException.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------


namespace EFC.Components.Exception
{
    using System;

    /// <summary>
    /// The object uninitialized exception.
    /// </summary>
    public class ObjectUninitializedException : InvalidOperationException
    {
        #region Properties

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        /// <value>The name of the object.</value>
        public string ObjectName { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectUninitializedException"/> class.
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        public ObjectUninitializedException(string objectName) : base(Messages.ObjectUninitialized)
        {
            this.ObjectName = objectName;
        }

        #endregion
    }
}
