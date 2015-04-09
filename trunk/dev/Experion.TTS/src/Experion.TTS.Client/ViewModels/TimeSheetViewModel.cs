// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="TimeSheetViewModel.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="TimeSheetViewModel.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using EFC.Client.Common.Base;
using Experion.TTS.Client.Models;
using Experion.TTS.Service;
using Experion.TTS.Service.Model;
using Microsoft.Practices.Unity;
using System;

namespace Experion.TTS.Client.ViewModels
{
    using Experion.TTS.Client.Constants;
    using Experion.TTS.Client.Extensions;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// TimeSheetViewModel.
    /// </summary>
    public class TimeSheetViewModel : ViewModel
    {
        #region Members

        private DateTime maxDate;

        private USER_DEFN currentUser;

        public USER_DEFN CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                if (currentUser != null)
                {
                    InitilizeViewModelData();
                }
            }
        }

        private bool showBulkAdd;

        private bool isBusy;



        public ObservableCollection<DateTime> Dates { get; set; }


        private TimeSheetService TimeSheetService { get; set; }

        public TimeSheetModel Model { get; set; }

        public ICommand SelectedDatesChangedCommand { get; set; }

        public ICommand AddNewRowCommand { get; set; }

        public ICommand BulkAddCommand { get; set; }

        public ICommand PopupCancelCommand { get; set; }

        public ICommand PopupOkCommand { get; set; }

        public ICommand SaveCommand { get; set; }


        public DateTime MaxDate
        {
            get
            {
                return this.maxDate;
            }
            set
            {
                this.maxDate = value;
                RaisePropertyChanged("MaxDate");
            }
        }

        public bool ShowBulkAdd
        {
            get
            {
                return this.showBulkAdd;
            }
            set
            {
                this.showBulkAdd = value;
                this.RaisePropertyChanged("ShowBulkAdd");
            }
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                this.isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        public ICommand RemoveRowCommand { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the TimeSheetViewModel class.
        /// </summary>
        public TimeSheetViewModel(IUnityContainer container)
            : base(container)
        {
            InitilizeCommands();
        }

        /// <summary>
        /// Initilizes the commands.
        /// </summary>
        private void InitilizeCommands()
        {
            SelectedDatesChangedCommand = new RelayCommand<EventArgs<DateSelection>>(SelectedDatesChangedCommandHandler);

            AddNewRowCommand = new RelayCommand(AddNewRowCommandHandler);
            BulkAddCommand = new RelayCommand(BulkAddCommandHandler);
            PopupCancelCommand = new RelayCommand(PopupCancelCommandHandler);
            PopupOkCommand = new RelayCommand(PopupOkCommandHandler);
            SaveCommand = new RelayCommand(SaveCommandHandler);
            RemoveRowCommand = new RelayCommand(RemoveRowCommandHandler);

            Messenger.Default.Unregister<string>(this, OnMessageReceived);
            Messenger.Default.Register<string>(this, OnMessageReceived);

        }

        /// <summary>
        /// Called when [message received].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnMessageReceived(string message)
        {
            switch (message)
            {
                case RibbonConstants.AddBulkRibbonCommand:
                    this.BulkAddCommandHandler();
                    break;

                case RibbonConstants.SaveRibbonCommand:
                    this.SaveCommandHandler();
                    break;
            }
        }

        /// <summary>
        /// Removes the row command handler.
        /// </summary>
        private void RemoveRowCommandHandler()
        {
            if (MessageBox.Show(
                "Are you sure want delete this entry?",
                "Delete Time Sheet",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var selectedTimeSheet = this.Model.SelectedTimeSheet;
                if (selectedTimeSheet != null)
                {
                    this.TimeSheetService.Remove(selectedTimeSheet.ToEntity());
                }

                if (TimeSheetService.Save() > 0)
                {
                    LoadTimeSheetData(Model.SelectedDates.Min(), Model.SelectedDates.Max());

                    MessageBox.Show(
                        "Time sheet changes saved successfully",
                        "Save Time Sheet",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Time sheet save failed.",
                        "Save Time Sheet",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

            }
        }

        private void SaveCommandHandler()
        {

            if (MessageBox.Show(
                "Are you sure want save these changes?",
                "Save Time Sheet",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (TimeSheetService.Save() > 0)
                {
                    LoadTimeSheetData(Model.SelectedDates.Min(), Model.SelectedDates.Max());
                    MessageBox.Show(
                        "Time sheet changes saved successfully",
                        "Save Time Sheet",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Time sheet save failed.",
                        "Save Time Sheet",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void PopupOkCommandHandler()
        {
            if (MessageBox.Show(
                "Are you sure want to add same record for all selected Date?",
                "Bulk Add",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                IsBusy = true;
                var addedCollection = new List<SheetModel>();
                var addedEntities = new List<Timesheet>();

                Task.Factory.StartNew(
                    () =>
                    {
                        foreach (var selectedDate in Model.SelectedDates)
                        {
                            var newItem = new SheetModel
                            {
                                Date = selectedDate,
                                Activity = Model.SelectedActivities,
                                Duration = Model.SelectedEffort,
                                ProjectName = Model.SelectedProjects,
                                Task = Model.SelectedTask,
                                UserID = CurrentUser.Id
                            };
                            addedCollection.Add(newItem);

                        }

                        addedCollection.ForEach(d => addedEntities.Add(d.ToEntity()));
                        TimeSheetService.BulkAdd(addedEntities);

                    }).ContinueWith(
                        p =>
                        {
                            addedCollection.ForEach(d => this.Model.TimeSheetCollection.Add(d));

                            IsBusy = false;
                        },
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void PopupCancelCommandHandler()
        {
            ShowBulkAdd = false;
        }

        private void BulkAddCommandHandler()
        {
            if (Model.SelectedDates.Any())
            {
                ShowBulkAdd = true;
            }
            else
            {
                MessageBox.Show(
                    "Select atleast a date to add.",
                    "Bulk Add",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }

        /// <summary>
        /// Adds the new row command handler.
        /// </summary>
        private void AddNewRowCommandHandler()
        {
            var newItem = new SheetModel { Date = DateTime.Now };
            Model.TimeSheetCollection.Add(newItem);
            Model.TimeSheetData.MoveCurrentTo(newItem);
        }

        /// <summary>
        /// Selecteds the dates changed command handler.
        /// </summary>
        /// <param name="eventArgs">The <see cref="EventArgs{DateSelection}"/> instance containing the event data.</param>
        private void SelectedDatesChangedCommandHandler(EventArgs<DateSelection> eventArgs)
        {
            foreach (var removedDate in eventArgs.Data.RemovedDates)
            {
                if (Model.SelectedDates.Any(p => p.Equals(removedDate)))
                {
                    Model.SelectedDates.Remove(removedDate);
                }
            }

            foreach (var addedDate in eventArgs.Data.AddedDates)
            {
                if (!Model.SelectedDates.Any(p => p.Equals(addedDate)))
                {
                    Model.SelectedDates.Add(addedDate);
                }
            }

            LoadTimeSheetData(Model.SelectedDates.Min(), Model.SelectedDates.Max());

        }

        private void InitilizeViewModelData()
        {
            MaxDate = DateTime.Now.Date;

            Model = new TimeSheetModel();
            Dates = new ObservableCollection<DateTime> { new DateTime(2013, 10, 1), new DateTime(2013, 11, 1) };

            TimeSheetService = Unity.Resolve<TimeSheetService>();

            LoadTimeSheetData(DateTime.Now.AddDays(-7), DateTime.Now);
        }

        /// <summary>
        /// Loads the time sheet data.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        private void LoadTimeSheetData(DateTime startDate, DateTime endDate)
        {
            IsBusy = true;
            Messenger.Default.Send(new RibbonVisibilityMessage { ItemName = "TimeSheet", IsEnabled = false });
            Model.PieCollection.Clear();

            IEnumerable<Timesheet> timeSheets = new List<Timesheet>();
            this.GetTimeSheets(startDate, endDate, timeSheets);
        }

        /// <summary>
        /// Gets the time sheets.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="timeSheets">The time sheets.</param>
        private void GetTimeSheets(DateTime startDate, DateTime endDate, IEnumerable<Timesheet> timeSheets)
        {
            Task.Factory.StartNew(() => { timeSheets = this.TimeSheetService.GetTimeSheet(this.CurrentUser.Id, startDate, endDate); })
                .ContinueWith(async t =>
                    {
                        this.Model.Activities = new ObservableCollection<Activity>(this.TimeSheetService.GetAllActivities());

                        var projects = await this.TimeSheetService.GetAllProjects();
                        this.Model.Projects = new ObservableCollection<Project>(projects);

                        this.Model.TimeSheetCollection.Clear();

                        foreach (var sheet in timeSheets)
                        {
                            this.PopulateTimeSheet(sheet);
                        }
                        Messenger.Default.Send(new RibbonVisibilityMessage { ItemName = "TimeSheet", IsEnabled = true });
                        this.IsBusy = false;
                    },
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Populates the time sheet.
        /// </summary>
        /// <param name="timesheet">The timesheet.</param>
        private void PopulateTimeSheet(Timesheet timesheet)
        {

            var sheet = new SheetModel
                {

                    Date = timesheet.TimesheetDate,
                    Duration = timesheet.Duration,
                    ProjectName = timesheet.Project,
                    ProjectDescription = timesheet.Project.Description,
                    Remarks = timesheet.Remarks,
                    Task = timesheet.Task,
                    ID = timesheet.TimesheetId
                };

            Model.TimeSheetCollection.Add(sheet);
            var pieModel = new ProjectEffortPieModel
                           {
                               Effort = sheet.Duration,
                               ProjectName = timesheet.Project.Description,
                               ProjectCode = timesheet.Project.Code,
                               ProjectID = timesheet.Project.ProjectId
                           };

            if (this.Model.PieCollection.All(p => p.ProjectID != pieModel.ProjectID))
            {
                Model.PieCollection.Add(pieModel);
            }
            else
            {
                var foundItem = Model.PieCollection.FirstOrDefault(p => p.ProjectID == pieModel.ProjectID);
                foundItem.Effort = pieModel.Effort + foundItem.Effort;
            }

        }
    }
}