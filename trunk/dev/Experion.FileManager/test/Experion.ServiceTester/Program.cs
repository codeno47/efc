using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Experion.FileManager.Services;
using Experion.FileManager.Services.Configuration;
using Experion.FileManager.Services.Constants;
using Experion.FileManager.Services.Dto;

namespace Experion.ServiceTester
{
    class Program
    {
        #region Fields

        /// <summary>
        /// The io file service
        /// </summary>
        private static IOFileService ioFileService;

        /// <summary>
        /// The settings
        /// </summary>
        private static FileManagerSection settings;

        /// <summary>
        /// The setting service
        /// </summary>
        private static SettingService settingService;

        /// <summary>
        /// The mail service
        /// </summary>
        private static MailService mailService;

        #endregion

        static void Main(string[] args)
        {
            InitilizeScheduler();
            // ioFileService.UnloadFile("settings.rar");
            CleanFiles();
            ////var service = new Experion.FileService.Service();
            ////service.StartService(); // allows easy debugging of OnStart()

            //Console.ReadKey();
        }

        private static void CleanFiles()
        {
            Console.WriteLine("Deleting Directories");
            var message = new StringBuilder();

            var directories = ioFileService.GetAllDirectories(settings.FileSettings.DeafultWatchLocation);
            if (directories.Any())
            {
                message.AppendLine("Deleted Folders");

                foreach (var directory in directories)
                {
                    ////created or modified.
                    if (!settings.FileSettings.Filters.Any(p => directory.Contains(p)))
                    {
                        Console.WriteLine("Deleting {0}", directory);
                        if (ioFileService.DeleteDirectory(directory))
                        {
                            message.AppendLine(string.Format("Deleted {0}", directory));
                        }
                        else
                        {
                            ////ioFileService.DeleteDirectoryFiles(directory);
                            message.AppendLine(string.Format("Delete Failed {0}", directory));
                        }
                    }
                }

                message.AppendLine(string.Format("Folders Deleted {0}", directories.Count));
            }

            CleanFiles(message);

            SendReportMail(message);
        }

        /// <summary>
        /// Cleans the files.
        /// </summary>
        /// <param name="message">The message.</param>
        private static void CleanFiles(StringBuilder message)
        {
            Console.WriteLine("Deleting files");

            var files = ioFileService.GetAllFiles(settings.FileSettings.DeafultWatchLocation);
            if (files.Any())
            {
                message.AppendLine("Deleted Files");
                foreach (var file in files)
                {
                    Console.WriteLine("Deleting {0}", file);
                    if (ioFileService.DeleteFile(file))
                    {
                        message.AppendLine(string.Format("Deleted {0}", file));
                    }
                    else
                    {
                        ////ioFileService.UnloadFile(file);
                        ////ioFileService.DeleteFile(file);
                        message.AppendLine(string.Format("Delete Failed {0}", file));
                    }
                }
            }
        }

        /// <summary>
        /// Sends the report mail.
        /// </summary>
        /// <param name="message">The message.</param>
        private static void SendReportMail(StringBuilder message)
        {
            var mailData = new MailInfo
                {
                    Body = message.ToString(),
                    FromEmail = settings.MailSettings.FromEmail,
                    IsSslEnabled = settings.MailSettings.IsSslEnabled,
                    MailServer = settings.MailSettings.MailServer,
                    Password = settings.MailSettings.Password,
                    Port = settings.MailSettings.Port,
                    Subject = settings.MailSettings.Subject,
                    ToAddress = settings.MailSettings.ToAddress,
                    UserName = settings.MailSettings.UserName
                };
            mailService.SendMail(mailData);
        }

        /// <summary>
        /// Initilizes the scheduler.
        /// </summary>
        private static void InitilizeScheduler()
        {
            Console.WriteLine("Initlizing file cleaner");
            settingService = new SettingService();
            ioFileService = new IOFileService();
            mailService = new MailService();

            InitlizeSettings();
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        /// <returns></returns>
        private static FileManagerSection LoadSettings()
        {
            return settingService.LoadSettings(FileManagerConstants.SettingsFile);
        }

        /// <summary>
        /// Initlizes the settings.
        /// </summary>
        /// <returns></returns>
        private static void InitlizeSettings()
        {
            settings = LoadSettings();

            if (settings == null)
            {

                var mailSettings = new MailInfo
                {
                    Body = "sample",
                    FromEmail = "service.experion@gmail.com",
                    IsSslEnabled = true,
                    MailServer = "smtp.gmail.com",
                    Password = "win2008...",
                    Port = 25,
                    Subject = "Public Folder Cleanup",
                    UserName = "service.experion"
                };

                mailSettings.ToAddress.Add("binu.bhasuran@experionglobal.com");

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

            return;
        }

    }
}
