// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="INavigationService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="INavigationService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Common.Client.Phone.Navigation
{
    /// <summary>
    /// INavigationService.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Gets a value indicating whether can go back.
        /// </summary>
        bool CanGoBack { get; }

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
        /// Navigates this instance.
        /// </summary>
        /// <typeparam name="TDestinationViewModel">The type of the destination view model.</typeparam>
        void Navigate<TDestinationViewModel>();
    }
}