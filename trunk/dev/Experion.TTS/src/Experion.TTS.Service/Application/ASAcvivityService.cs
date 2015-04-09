using System.Data.Entity;
using System.Linq;
using EFC.Common.Service;
using EFC.Components.Data;
using Experion.TTS.Service.Model;
using Microsoft.Practices.Unity;

namespace Experion.TTS.Service.Application
{
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Application Service
    /// </summary>
    public class ASAcvivityService : ApplicationService<Entities>
    {
        /// <summary>
        /// Gets the activity repository.
        /// </summary>
        /// <value>
        /// The activity repository.
        /// </value>
        private IRepository<Activity, int> ActivityRepository
        {
            get { return DataContext.GetRepository<Activity, int>(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASAcvivityService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public ASAcvivityService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }

        /// <summary>
        /// Gets the activity by unique identifier.
        /// </summary>
        /// <param name="activityId">The activity unique identifier.</param>
        /// <returns></returns>
        public Activity GetActivityById(int activityId)
        {
            var roleSpecification = new Specification<Activity>(r => r.ActivityId.Equals(activityId));
            return ActivityRepository.GetBySpecification(roleSpecification).FirstOrDefault();
        }

        public IEnumerable<Activity> GetAllActivitieses()
        {
            return  ActivityRepository.GetAll().Distinct();
            
        }
    }
}
