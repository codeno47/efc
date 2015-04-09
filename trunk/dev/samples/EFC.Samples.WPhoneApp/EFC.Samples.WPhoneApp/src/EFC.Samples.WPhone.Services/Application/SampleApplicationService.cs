using EFC.Samples.WPhone.Services.Data;
using EFC.Service.Phone;
using EFC.Service.Phone.RepositoryBase;
using Microsoft.Practices.Unity;

namespace EFC.Samples.WPhone.Services.Application
{
    public class SampleApplicationService : ApplicationService<FieldMaxDataContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleApplicationService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public SampleApplicationService(IUnityContainer unity, IRepositoryContext context) : base(unity, context)
        {

        }
    }
}
