// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="NavigationService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="NavigationService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Newtonsoft.Json;

namespace EFC.Common.Client.Phone.Navigation
{
    /// <summary>
    /// The navigation service.
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// The view model routing.
        /// </summary>
        private readonly Dictionary<Type, string> viewModelRouting;


        /// <summary>
        /// Gets a value indicating whether can go back.
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return RootFrame.CanGoBack;
            }
        }

        /// <summary>
        /// Gets the root frame.
        /// </summary>
        private Frame RootFrame
        {
            get { return Application.Current.RootVisual as Frame; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        public NavigationService()
        {
            viewModelRouting = new Dictionary<Type, string>();
        }

        /// <summary>
        /// Decodes the navigation parameter.
        /// </summary>
        /// <typeparam name="TJson">The type of the json.</typeparam>
        /// <param name="context">The context.</param>
        /// <returns>The json result.</returns>
        public TJson DecodeNavigationParameter<TJson>(NavigationContext context)
        {
            if (context.QueryString.ContainsKey("param"))
            {
                var param = context.QueryString["param"];
                return string.IsNullOrWhiteSpace(param) ? default(TJson) : JsonConvert.DeserializeObject<TJson>(param);
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// The go back.
        /// </summary>
        public void GoBack()
        {
            RootFrame.GoBack();
        }

        /// <summary>
        /// Navigates the specified parameter.
        /// </summary>
        /// <typeparam name="TDestinationViewModel">The type of the destination view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        public void Navigate<TDestinationViewModel>(object parameter)
        {
            var navParameter = string.Empty;
            if (parameter != null)
            {
                navParameter = "?param=" + JsonConvert.SerializeObject(parameter);
            }

            NavigateView<TDestinationViewModel>(navParameter);
        }

        /// <summary>
        /// Navigates the specified parameter.
        /// </summary>
        /// <typeparam name="TDestinationViewModel">The type of the destination view model.</typeparam>
        public void Navigate<TDestinationViewModel>()
        {
            var navParameter = string.Empty;
            NavigateView<TDestinationViewModel>(navParameter);
        }

        /// <summary>
        /// Navigates the view.
        /// </summary>
        /// <typeparam name="TDestinationViewModel">The type of the destination view model.</typeparam>
        /// <param name="navParameter">The nav parameter.</param>
        private void NavigateView<TDestinationViewModel>(string navParameter)
        {
            if (viewModelRouting.ContainsKey(typeof(TDestinationViewModel)))
            {
                var page = viewModelRouting[typeof(TDestinationViewModel)];

                RootFrame.Navigate(new Uri("/" + page + navParameter, UriKind.Relative));
            }
        }
    }
}
