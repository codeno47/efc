// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="Requires.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="Requires.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Validations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EFC.Components.Exception;

    /// <summary>
    /// The requires helper class.
    /// </summary>
    public static class Requires
    {
        #region Methods

        /// <summary>
        /// Requires the not null value.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        public static void NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw ExceptionBuilder.ArgumentNull(parameterName);
            }
        }

        /// <summary>
        /// Requires the not null and not empty string value.
        /// </summary>
        /// <param name="value">Value of the parameter.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the value is empty string.</exception>
        public static void NotNullOrEmpty(string value, string parameterName)
        {
            NotNull(value, parameterName);

            if (value.Length == 0)
            {
                throw ExceptionBuilder.ArgumentEmptyString(parameterName);
            }
        }

        /// <summary>
        /// Requires the values to be not null and contain any elements.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="values">The values.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown when the values is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the values is empty.</exception>
        public static void NotNullOrEmpty<T>(IEnumerable<T> values, string parameterName) where T : class
        {
            NotNull(values, parameterName);

            if (!values.Any())
            {
                throw ExceptionBuilder.ArgumentNotValid(parameterName, Messages.ArgumentEmptyCollection);
            }
        }

        /// <summary>
        /// Requires the values to be not null and contain not null elements.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="values">The values.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown when the values is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the values contains null elements.</exception>
        public static void NotNullOrNullElements<T>(IEnumerable<T> values, string parameterName) where T : class
        {
            NotNull(values, parameterName);
            NotNullElements(values, parameterName);
        }

        /// <summary>
        /// Requires the values to be null or contain not null elements.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="values">The values.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentException">Thrown when the values is not null and contains null elements.</exception>
        public static void NullOrNotNullElements<T>(IEnumerable<T> values, string parameterName) where T : class
        {
            if (values != null)
            {
                NotNullElements(values, parameterName);
            }
        }

        /// <summary>
        /// Requires the values to contain not null elements.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="values">The values.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentException">Thrown when the values contains null elements.</exception>
        private static void NotNullElements<T>(IEnumerable<T> values, string parameterName) where T : class
        {
            foreach (T value in values)
            {
                if (value == null)
                {
                    throw ExceptionBuilder.ArgumentNotValid(parameterName, Messages.ArgumentNullElement);
                }
            }
        }

        /// <summary>
        /// Requires the value to be in the range.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is out of the range.</exception>
        public static void InRange<T>(T value, T start, T end, string parameterName) where T : struct, IComparable<T>
        {
            if (value.CompareTo(start) < 0 || value.CompareTo(end) > 0)
            {
                throw ExceptionBuilder.ArgumentOutOfRange(parameterName);
            }
        }

        /// <summary>
        /// Requires the object to be of the specified type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentException">Thrown when the object is not of the specified type.</exception>
        public static void OfType<T>(object instance, string parameterName)
        {
            NotNull(instance, "instance");

            if (!(instance is T))
            {
                throw ExceptionBuilder.ArgumentNotExpectedType(parameterName, typeof(T));
            }
        }

        /// <summary>
        /// Requires the assignable type.
        /// </summary>
        /// <param name="valueType">The value type.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentException">Thrown when the type is not assignable.</exception>
        public static void Assignable(Type valueType, Type targetType, string parameterName)
        {
            NotNull(valueType, "valueType");
            NotNull(targetType, "targetType");

            if (!targetType.IsAssignableFrom(valueType))
            {
                throw ExceptionBuilder.ArgumentNotAssignable(parameterName, valueType, targetType);
            }
        }

        /// <summary>
        /// Requires the type to be an interface.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="ArgumentException">Thrown when the type is not an interface.</exception>
        public static void Interface(Type type, string parameterName)
        {
            NotNull(type, "type");

            if (!type.IsInterface)
            {
                throw ExceptionBuilder.ArgumentNotAnInterface(parameterName);
            }
        }

        /// <summary>
        /// Requires the member to be called only once.
        /// </summary>
        /// <param name="condition"><c>True</c> if the member has been called before; otherwise, <c>false</c>.</param>
        /// <param name="memberName">Name of the member.</param>
        public static void CalledOnce(bool condition, string memberName)
        {
            if (condition)
            {
                throw ExceptionBuilder.CalledTwice(memberName);
            }
        }

        #endregion
    }
}
