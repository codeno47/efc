using System.Windows.Controls;

namespace Experion.TTS.Client.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using Experion.TTS.Client.Models;
    using Experion.TTS.Client.ViewModels;

    using Infragistics.Controls.Schedules;
    using Infragistics.Windows.Editors.Events;

    /// <summary>
    /// Description for TimeSheetView.
    /// </summary>
    public partial class TimeSheetView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the TimeSheetView class.
        /// </summary>
        public TimeSheetView()
        {
            InitializeComponent();
        }

        private void OnDateSectionChanged(object sender, SelectedDatesChangedEventArgs e)
        {
            var viewModel = DataContext as TimeSheetViewModel;
            if (viewModel != null)
            {
                viewModel.SelectedDatesChangedCommand.Execute(new EventArgs<DateSelection> { 
                    Data = new DateSelection
                           {
                               AddedDates = new List<DateTime>(e.AddedDates),
                               RemovedDates = new List<DateTime>(e.RemovedDates)
                           
                           }});
            }
        }

        private void OnAddButtonClicked(object sender, RoutedEventArgs e)
        {
           var viewModel = DataContext as TimeSheetViewModel;
            if (viewModel != null)
            {
                viewModel.AddNewRowCommand.Execute(null);
            }

        }

        private void OnRemoveButtonClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as TimeSheetViewModel;
            if (viewModel != null)
            {
                viewModel.RemoveRowCommand.Execute(null);
            }
        }
    }
}