using System.Collections.Generic;
using System.Linq;
using EFC.Samples.Service.Model;
using Experion.Common.Service;
using Experion.Components.Data;
using Microsoft.Practices.Unity;

namespace EFC.Samples.Service.Application
{
    /// <summary>
    /// ASRoute.
    /// </summary>
    public class ASRoute : ApplicationService<FieldMaxDataContainer>
    {
        /// <summary>
        /// Gets the beat plan repository.
        /// </summary>
        /// <value>
        /// The beat plan repository.
        /// </value>
        private IRepository<BeatPlan, int> BeatPlanRepository
        {
            get { return DataContext.GetRepository<BeatPlan, int>(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRoute"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public ASRoute(IUnityContainer unity, IRepositoryContext context) : base(unity, context)
        {
        }

        /// <summary>
        /// Gets all routes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BeatPlan> GetAllRoutes()
        {
            return BeatPlanRepository.GetAll();
        }

        /// <summary>
        /// Gets the beat plan.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public BeatPlan GetBeatPlan(int id)
        {
            var roleSpecification = new Specification<BeatPlan>(r => r.BeatPlanId.Equals(id));
            return BeatPlanRepository.GetBySpecification(roleSpecification).FirstOrDefault();
        }

        /// <summary>
        /// Adds the beat plan.
        /// </summary>
        /// <param name="beatPlanToAdd">The beat plan to add.</param>
        /// <returns>BeatPlan.</returns>
        public BeatPlan AddBeatPlan(BeatPlan beatPlanToAdd)
        {
            return BeatPlanRepository.Add(beatPlanToAdd);
        }

        /// <summary>
        /// Deletes the beat plan.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteBeatPlan(int id)
        {
            var beatPlanToDelete = GetBeatPlan(id);
            BeatPlanRepository.Delete(beatPlanToDelete);
        }

        /// <summary>
        /// Updates the beat plan.
        /// </summary>
        /// <param name="beatPlanToUpdate">The beat plan to update.</param>
        public void UpdateBeatPlan(BeatPlan beatPlanToUpdate)
        {
            BeatPlanRepository.Update(beatPlanToUpdate);
        }
    }
}
