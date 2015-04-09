
namespace EFC.Components.Events
{
    using System;
    using System.Reflection;

    using EFC.Components.Validations;

    /// <summary>
    /// MethodInfo extensions.
    /// </summary>
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// Determines whether method info is describing an event handler.
        /// </summary>
        /// <param name="methodInfo">The method info.</param>
        /// <returns>
        /// <c>True</c> if is describing an event handler; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEventHandler(this MethodInfo methodInfo)
        {
            Requires.NotNull(methodInfo, "methodInfo");
            ParameterInfo[] parameters = methodInfo.GetParameters();
            return parameters.Length == 2
                && parameters[0].ParameterType == typeof(object)
                && typeof(EventArgs).IsAssignableFrom(parameters[1].ParameterType)
                && methodInfo.ReturnType == typeof(void);
        }
    }
}
