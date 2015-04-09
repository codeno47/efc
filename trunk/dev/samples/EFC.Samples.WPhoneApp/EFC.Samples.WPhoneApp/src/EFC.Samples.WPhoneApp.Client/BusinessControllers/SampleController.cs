using EFC.Samples.WPhone.Base;
using Microsoft.Practices.Unity;

namespace EFC.Samples.WPhone.BusinessControllers
{
    /// <summary>
    /// SampleController.
    /// </summary>
    public class SampleController:BusinessController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleController"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public SampleController(IUnityContainer container) : base(container)
        {

        }

        /// <summary>
        /// Determines whether [is valid user data] [the specified username].
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool IsValidUserData(string username, string password)
        {
            if (!IsOffline)
            {
                //// Call online service
            }
            else
            {
                //// call offline service.
            }

            return true;
        }
    }
}
