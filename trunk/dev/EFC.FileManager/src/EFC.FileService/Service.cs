using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using EFC.FileManager.Services;
using EFC.FileManager.Services.Configuration;
using EFC.FileManager.Services.Constants;
using EFC.FileManager.Services.Dto;

namespace EFC.FileService
{
    public partial class Service : ServiceBase
    {
        #region Fields

        /// <summary>
        /// The service name description
        /// </summary>
        public const string ServiceNameDesc = "Experion.FileService";

        /// <summary>
        /// The file system watcher
        /// </summary>
        private FileSystemWatcher fileSystemWatcher;

        /// <summary>
        /// The setting service
        /// </summary>
        private readonly SettingService settingService;

        /// <summary>
        /// The io file service
        /// </summary>
        private readonly IOFileService ioFileService;

        /// <summary>
        /// The schedule service
        /// </summary>
        private readonly ScheduleService scheduleService;

        /// <summary>
        /// The mail service
        /// </summary>
        private readonly MailService mailService;

        /// <summary>
        /// The state timer
        /// </summary>
        private System.Timers.Timer stateTimer;

        /// <summary>
        /// The settings
        /// </summary>
        private FileManagerSection settings;

        #endregion

        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        public Service()
        {
            InitializeComponent();
            settingService = new SettingService();
            ioFileService = new IOFileService();
            scheduleService = new ScheduleService();
            mailService = new MailService();
        }

        #endregion

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("Starting service");
            try
            {


                settings = InitlizeSettings();
                InitilizeWatcher(settings.FileSettings.DeafultWatchLocation);
                StartTimer();
            }
            catch (Exception exception)
            {
                EventLog.WriteEntry(exception.Message);
            }

            ////WriteLog("Starting service completed");
        }

        /// <summary>
        /// Starts the service for Testing.
        /// </summary>
        public void StartService()
        {
            OnStart(new string[2]);
        }

        #region Watcher Events

        /// <summary>
        /// Called when [changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            ////created or modified.
            if (!settings.FileSettings.Filters.Any(p => e.FullPath.Contains(p)))
            {
                var scheduleTime = DateTime.Now.AddMinutes(+settings.FileSettings.FileDeleteDuration);
                scheduleService.AddSchedule(new ScheduleInfo {FilePath = e.FullPath, Time = scheduleTime});
                WriteLog("New Schedule added");
            }
            // SendMail(e.FullPath);
        }

        #endregion

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="file">The file.</param>
        private void SendMail(string file)
        {
            var mailSettings = settings.MailSettings;
            var body = string.Format("File  {0} will be delete after 30 minutes", file);

            mailSettings.Body = body;
            mailService.SendMail(mailSettings);


        }
        /// <summary>
        /// Initlizes the settings.
        /// </summary>
        /// <returns></returns>
        private FileManagerSection InitlizeSettings()
        {
            settings = LoadSettings();

            if (settings == null)
            {
               
                var mailSettings = new MailInfo
                {
                    Body = "sample",
                    FromEmail = "binu.bhasuran@experionglobal.com",
                    IsSslEnabled = true,
                    MailServer = "smtp.gmail.com",
                    Password = "QQQQ@#",
                    Port = 25,
                    Subject = "test",
                    UserName = "codeno47"
                };

                mailSettings.ToAddress.Add("codeno47@gmail.com");

                var settingData = new FileManagerSection
                {
                    MailSettings = mailSettings,

                    FileSettings = new FileManagerSettingsInfo
                        {
                            DeafultWatchLocation = FileManagerConstants.WatcherPath, 
                            FileDeleteDuration = 1,
                            Filters = new List<string> { "SOFTWARES" }
                        }
                };
                settingService.SaveSettings(settingData, FileManagerConstants.SettingsFile);
                settingData.EnableEventLog = false;

                settings = settingData;
            }

            return settings;
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        /// <returns></returns>
        private FileManagerSection LoadSettings()
        {
            return settingService.LoadSettings(FileManagerConstants.SettingsFile);
        }

        /// <summary>
        /// Initilizes the watcher.
        /// </summary>
        /// <param name="watcherLocation">The watcher location.</param>
        private void InitilizeWatcher(string watcherLocation)
        {
            // Create a new FileSystemWatcher with the path
            //and text file filter
            fileSystemWatcher = new FileSystemWatcher(watcherLocation)
            {
                NotifyFilter = NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.FileName
                               | NotifyFilters.DirectoryName
            };

            //Watch for changes in LastAccess and LastWrite times, and
            //the renaming of files or directories.

            // Add event handlers.
            //fileSystemWatcher.Changed += OnChanged;
            fileSystemWatcher.Created += OnChanged;
            //fileSystemWatcher.Deleted += OnDeleted;
            //fileSystemWatcher.Renamed += OnRenamed;

            fileSystemWatcher.IncludeSubdirectories = true;
            // Begin watching.
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        private void StartTimer()
        {
            stateTimer = new Timer();
            stateTimer.Interval = 30000;
            stateTimer.Elapsed += CheckStatus;
            stateTimer.Enabled = true;
        }

        /// <summary>
        /// Checks the status.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void CheckStatus(object source, ElapsedEventArgs e)
        {
            WriteLog("Checking status");
            var schedules = scheduleService.GetCurrentSchedules();
            WriteLog(string.Format("Found Schedule count is {0}", schedules.Count));
            if (!schedules.Any()) return;

            foreach (var schedule in schedules)
            {
                WriteLog("Deleting file");
                ioFileService.DeleteFile(schedule.FilePath);
                scheduleService.RemoveSchedule(schedule.Id);
            }
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            stateTimer.Enabled = false;
            stateTimer.Dispose();
            fileSystemWatcher.Dispose();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Pause command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service pauses.
        /// </summary>
        protected override void OnPause()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// When implemented in a derived class, <see cref="M:System.ServiceProcess.ServiceBase.OnContinue" /> runs when a Continue command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service resumes normal functioning after being paused.
        /// </summary>
        protected override void OnContinue()
        {
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="message">The message.</param>
        private void WriteLog(string message)
        {
            if (settings != null && settings.EnableEventLog)
            {
                EventLog.WriteEntry(message);
            }
        }
    }
}
