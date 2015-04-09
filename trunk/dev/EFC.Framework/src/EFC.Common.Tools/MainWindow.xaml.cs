// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="MainWindow.xaml.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="MainWindow.xaml.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Windows;
using EFC.Common.Tools.ConnectionChecker.ConnectionCheckerViewModel;
using Experion.Common.Tools.ConnectionChecker;
using Experion.Common.Tools.ConnectionChecker.ConnectionCheckerViewModel;
using Experion.Common.Tools.ConnectionChecker.WorkItems;

namespace Experion.Common.Tools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConnectionCheckerWorkItem WorkItem { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            WorkItem = new ConnectionCheckerWorkItem();
            WorkItem.Start();

            InitlizeRegions();
        }

        /// <summary>
        /// Initlizes the regions.
        /// </summary>
        private void InitlizeRegions()
        {
            var mainViewModel = WorkItem.Unity.ResolveFor<ConnectionCheckerViewModel>();
            Region1.Content = mainViewModel.View;
        }
    }
}
