using System.Collections.Generic;
using EFC.Samples.Service.Application;
using EFC.Samples.Service.Contracts;
using EFC.Samples.Service.Contracts.Dto;
using EFC.Samples.Service.Extension;
using Experion.Components.Aspect;
using Microsoft.Practices.Unity;

namespace EFC.Samples.Service
{
    public class RouteService : IRouteService
    {
        /// <summary>
        /// Gets or sets as route.
        /// </summary>
        /// <value>
        /// As route.
        /// </value>
        [Dependency]
        public ASRoute AsRoute { get; set; }

        /// <summary>
        /// The container
        /// </summary>
        private IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteService"/> class.
        /// </summary>
        /// <param name="unityContainer">The unity container.</param>
        public RouteService(IUnityContainer unityContainer)
        {
            container = unityContainer;
        }

        /// <summary>
        /// Gets all routes.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HandleException("ApplicationPolicy")]
        public IEnumerable<BeatPlanDto> GetAllRoutes()
        {
            return AsRoute.GetAllRoutes().ToDto();
        }

        /// <summary>
        /// Gets the beat plan.
        /// </summary>
        /// <param name="beatPlan">The beat plan.</param>
        /// <returns></returns>
        [HandleException("ApplicationPolicy")]
        public BeatPlanDto GetBeatPlan(BeatPlanDto beatPlan)
        {
            return AsRoute.GetBeatPlan(beatPlan.Id).ToDto();
        }
    }
}
