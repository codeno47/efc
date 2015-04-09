// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ExceptionBuilder.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ExceptionBuilder.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Exception
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using EFC.Components.Validations;

    /// <summary>
    /// The exception builder helper class.
    /// </summary>
    public static class ExceptionBuilder
    {
        #region Methods

        /// <summary>
        /// Creates the argument null exception.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument null exception.</returns>
        public static ArgumentNullException ArgumentNull(string parameterName)
        {
            Requires.NotNullOrEmpty(parameterName, "parameterName");

            return new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Creates the argument empty string exception.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument empty string exception.</returns>
        public static ArgumentException ArgumentEmptyString(string parameterName)
        {
            Requires.NotNullOrEmpty(parameterName, "parameterName");

            return new ArgumentException(Messages.ArgumentEmptyString, parameterName);
        }

        /// <summary>
        /// Creates the argument out of range exception.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument out of range exception.</returns>
        public static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName)
        {
            Requires.NotNullOrEmpty(parameterName, "parameterName");

            return new ArgumentOutOfRangeException(parameterName);
        }

        /// <summary>
        /// Creates the argument not expected type exception.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>The argument not expected type exception.</returns>
        public static ArgumentException ArgumentNotExpectedType(string parameterName, Type expectedType)
        {
            Requires.NotNullOrEmpty(parameterName, "parameterName");
            Requires.NotNull(expectedType, "expectedType");

            return new ArgumentException(Format(Messages.ArgumentNotExpectedType, expectedType), parameterName);
        }

        /// <summary>
        /// Creates the argument not assignable exception.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="valueType">Type of the value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns>The argument not assignable exception.</returns>
        public static ArgumentException ArgumentNotAssignable(string parameterName, Type valueType, Type targetType)
        {
            Requires.NotNullOrEmpty(parameterName, "parameterName");
            Requires.NotNull(valueType, "valueType");
            Requires.NotNull(targetType, "targetType");

            return new ArgumentException(Format(Messages.ArgumentNotAssignable, valueType, targetType), parameterName);
        }

        /// <summary>
        /// Creates the argument not an interface exception.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument exception.</returns>
        public static ArgumentException ArgumentNotAnInterface(string parameterName)
        {
            Requires.NotNullOrEmpty(parameterName, "parameterName");

            return new ArgumentException(Messages.ArgumentNotAnInterface, parameterName);
        }

        /// <summary>
        /// Creates the argument not valid exception.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>The argument not valid exception.</returns>
        public static ArgumentException ArgumentNotValid(string parameterName, string messageFormat, params object[] arguments)
        {
            Requires.NotNullOrEmpty(parameterName, "parameterName");
            Requires.NotNullOrEmpty(messageFormat, "messageFormat");

            return new ArgumentException(Format(messageFormat, arguments), parameterName);
        }

        /// <summary>
        /// Creates the object uninitialized exception.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>The object uninitialized exception.</returns>
        public static ObjectUninitializedException ObjectUninitialized(object instance)
        {
            Requires.NotNull(instance, "instance");

            return new ObjectUninitializedException(instance.GetType().ToString());
        }

        /// <summary>
        /// Creates the object disposed exception.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>The object disposed exception.</returns>
        public static ObjectDisposedException ObjectDisposed(object instance)
        {
            Requires.NotNull(instance, "instance");

            return new ObjectDisposedException(instance.GetType().ToString());
        }

        /// <summary>
        /// Creates the not overridden exception.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns>The not overridden exception.</returns>
        public static NotImplementedException NotOverridden(string memberName)
        {
            Requires.NotNullOrEmpty(memberName, "memberName");

            return new NotImplementedException(Format(Messages.NotOverridden, memberName));
        }

        /// <summary>
        /// Creates the called twice exception.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns>The called twice exception.</returns>
        public static InvalidOperationException CalledTwice(string memberName)
        {
            Requires.NotNullOrEmpty(memberName, "memberName");

            return new InvalidOperationException(Format(Messages.CalledTwice, memberName));
        }

        /// <summary>
        /// Creates the invalid operation exception.
        /// </summary>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>The invalid operation exception.</returns>
        public static InvalidOperationException InvalidOperation(string messageFormat, params object[] arguments)
        {
            Requires.NotNullOrEmpty(messageFormat, "messageFormat");

            return new InvalidOperationException(Format(messageFormat, arguments));
        }

        /// <summary>
        /// Creates the key not found exception.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The key not found exception.</returns>
        public static KeyNotFoundException KeyNotFound(object key)
        {
            return new KeyNotFoundException(Format(Messages.KeyNotFound, key));
        }

        /// <summary>
        /// Creates the directory not found exception.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <returns>The directory not found exception.</returns>
        public static DirectoryNotFoundException DirectoryNotFound(string directoryName)
        {
            Requires.NotNullOrEmpty(directoryName, "directoryName");

            return new DirectoryNotFoundException(Format(Messages.DirectoryNotFound, directoryName));
        }

        /// <summary>
        /// Creates the file not found exception.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The file not found exception.</returns>
        public static FileNotFoundException FileNotFound(string fileName)
        {
            Requires.NotNullOrEmpty(fileName, "fileName");

            return new FileNotFoundException(Format(Messages.FileNotFound, fileName), fileName);
        }

        /// <summary>
        /// Creates the not supported exception.
        /// </summary>
        /// <returns>The not supported exception.</returns>
        public static NotSupportedException NotSupported()
        {
            return new NotSupportedException();
        }

        /// <summary>
        /// Creates the not implemented exception.
        /// </summary>
        /// <returns>The not implemented exception.</returns>
        public static NotImplementedException NotImplemented()
        {
            return new NotImplementedException();
        }

        /// <summary>
        /// Formats the message.
        /// </summary>
        /// <param name="messageFormat">The message format.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>The message.</returns>
        private static string Format(string messageFormat, params object[] arguments)
        {
            return string.Format(CultureInfo.CurrentCulture, messageFormat, arguments);
        }

        #endregion
    }
}
