using System.Windows.Navigation;

namespace EFC.Samples.WPhone.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Adds the view model routing.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="page">The page.</param>
        void AddViewModelRouting<TViewModel>(string page);

        /// <summary>
        /// Gets a value indicating whether can go back.
        /// </summary>
        bool CanGoBack { get; }

        /// <summary>
        /// Decodes the navigation parameter.
        /// </summary>
        /// <typeparam name="TJson">The type of the json.</typeparam>
        /// <param name="context">The context.</param>
        /// <returns>The json result.</returns>
        TJson DecodeNavigationParameter<TJson>(NavigationContext context);

        /// <summary>
        /// The go back.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Navigates the specified parameter.
        /// </summary>
        /// <typeparam name="TDestinationViewModel">The type of the destination view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        void Navigate<TDestinationViewModel>(object parameter);

        /// <summary>
        /// Navigates the specified parameter.
        /// </summary>
        /// <typeparam name="TDestinationViewModel">The type of the destination view model.</typeparam>
        void Navigate<TDestinationViewModel>();
    }
}