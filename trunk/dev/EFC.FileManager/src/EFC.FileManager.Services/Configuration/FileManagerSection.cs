using System;
using EFC.FileManager.Services.Dto;

namespace EFC.FileManager.Services.Configuration
{
    /// <summary>
    /// FileManagerSection.
    /// </summary>
    [Serializable]
    public class FileManagerSection
    {
        /// <summary>
        /// Gets or sets the settings version.
        /// </summary>
        /// <value>
        /// The settings version.
        /// </value>
        public string SettingsVersion { get; set; }

        /// <summary>
        /// Gets or sets the mail settings.
        /// </summary>
        /// <value>
        /// The mail settings.
        /// </value>
        public MailInfo MailSettings { get; set; }

        /// <summary>
        /// Gets or sets the file settings.
        /// </summary>
        /// <value>
        /// The file settings.
        /// </value>
        public FileManagerSettingsInfo FileSettings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable event log].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable event log]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableEventLog { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileManagerSection"/> class.
        /// </summary>
        public FileManagerSection()
        {
            SettingsVersion = new Version(1,0,0,0).ToString();
        }
    }
}
