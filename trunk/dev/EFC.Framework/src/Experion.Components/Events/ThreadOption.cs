

namespace EFC.Components.Events
{
    /// <summary>
    /// Specifies on which <see cref="System.Threading.Thread"/> subscribers event handler will be called.
    /// </summary>
    public enum ThreadOption
    {
        /// <summary>
        /// The call is done on the same <see cref="System.Threading.Thread"/> as the publisher event publication was fired.
        /// </summary>
        Publisher,
        /// <summary>
        /// The call is done asynchronously on a background <see cref="System.Threading.Thread"/>.
        /// </summary>
        Background,
        /// <summary>
        /// The call is done is done on the UI <see cref="System.Threading.Thread"/>.
        /// </summary>
        UserInterface,
    }
}
