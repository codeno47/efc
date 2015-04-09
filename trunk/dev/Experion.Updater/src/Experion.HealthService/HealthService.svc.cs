using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Experion.HealthService
{
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Web.UI.WebControls;

    using Experion.FileManager.Services;
    using Experion.FileManager.Services.Configuration;
    using Experion.FileManager.Services.Constants;
    using Experion.FileManager.Services.Dto;
    using Experion.HealthService.Dto;
    using Experion.Updater.Dto;

    using Microsoft.Win32;

    [ServiceBehavior(
     ConcurrencyMode = ConcurrencyMode.Single,
     InstanceContextMode = InstanceContextMode.Single
   )]
    public class HealthService : IService1, IHealthService
    {
        #region Fields

        private static SettingService settingService;

        private static IOFileService ioFileService;

        private static MailService mailService;

        private static FileManagerSection settings;

        #endregion


        public HealthService()
        {
            SystemEvents.SessionEnding += OnSessionEnding;
            InitilizeScheduler();

        }

        #region Events

        private void OnSessionEnding(object sender, SessionEndingEventArgs e)
        {
            if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                SendShutDownNotification();
            }
        }

        #endregion

        #region Utilities

        private void SendShutDownNotification()
        {
            var message = new StringBuilder();
            var ipaddress = this.GetIp4Address();
            message.AppendLine(string.Format("A Shutdown command issued for the machine IP {0}", ipaddress));
            SendReportMail(message, "Machine Shutdown Alert");
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

        /// <summary>
        /// Loads the settings.
        /// </summary>
        /// <returns></returns>
        private static FileManagerSection LoadSettings()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(dir, FileManagerConstants.SettingsFile);
            return settingService.LoadSettings(filePath);
        }

        /// <summary>
        /// Sends the report mail.
        /// </summary>
        /// <param name="message">The message.</param>
        private static void SendReportMail(StringBuilder message, string title)
        {

            InitlizeSettings();

            ////MailDefinition md = new MailDefinition();
            ////md.From = "test@domain.com";
            ////md.IsBodyHtml = true;
            ////md.Subject = "Test of MailDefinition";

            var mailData = new MailInfo
            {
                Body = message.ToString(),
                FromEmail = settings.MailSettings.FromEmail,
                IsSslEnabled = settings.MailSettings.IsSslEnabled,
                MailServer = settings.MailSettings.MailServer,
                Password = settings.MailSettings.Password,
                Port = settings.MailSettings.Port,
                Subject = title,
                ToAddress = settings.MailSettings.ToAddress,
                UserName = settings.MailSettings.UserName
            };
            mailService.SendMail(mailData);
        }

        #endregion


        public string GetData(int value)
        {
            SendShutDownNotification();
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public MachineMemoryInfo GetMemoryUsage()
        {
            var response = new MachineMemoryInfo();

            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
            decimal percentOccupied = 100 - percentFree;

            response.MachineName = GetIp4Address();

            response.AvailablePhysicalMemory = phav;
            response.TotalMemory = tot;
            response.FreeMemory = percentFree;
            response.Occupied = percentOccupied;
            //Console.WriteLine("Available Physical Memory (MiB) " + phav.ToString());
            //Console.WriteLine("Total Memory (MiB) " + tot.ToString());
            //Console.WriteLine("Free (%) " + percentFree.ToString());
            //Console.WriteLine("Occupied (%) " + percentOccupied.ToString());
            //Console.ReadLine();

            return response;
        }

        public MachineProcessInfo GetAllMemoryStatics()
        {
            var response = new MachineProcessInfo();
            var processes = Process.GetProcesses();
            if (!processes.Any())
            {
                return response;
            }

            response.MachineName = GetIp4Address();

            foreach (var process in processes)
            {
                response.ProcessInfos.Add(new ProcessInfo { Name = process.ProcessName, WorkingSet = process.WorkingSet64 });
            }

            return response;
        }

        public bool RestartIIS()
        {
            try
            {
                Process.Start(@"C:\Windows\System32\issreset.exe");
            }
            catch (Exception)
            {
                
                return false;
            }

            return true;
        }

        private string GetIp4Address()
        {
            string strHostName = Dns.GetHostName(); ;
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            if (addr.Any())
            {
                return (from ipAddress in addr where ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork select ipAddress.ToString()).FirstOrDefault();
            }
            return null;
        }
    }
}
