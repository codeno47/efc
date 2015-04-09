// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="MainWindow.xaml.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="MainWindow.xaml.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------
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
