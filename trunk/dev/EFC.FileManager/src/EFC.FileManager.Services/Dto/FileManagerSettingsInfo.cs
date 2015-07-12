using System;
using System.Collections.Generic;

namespace EFC.FileManager.Services.Dto
{
    [Serializable]
    public class FileManagerSettingsInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileManagerSettingsInfo"/> class.
        /// </summary>
        public FileManagerSettingsInfo()
        {
            Filters = new List<string>();
        }

        /// <summary>
        /// Gets or sets the deafult watch location.
        /// </summary>
        /// <value>
        /// The deafult watch location.
        /// </value>
        public string DeafultWatchLocation { get; set; }

        /// <summary>
        /// Gets or sets the duration of the file delete.
        /// </summary>
        /// <value>
        /// The duration of the file delete.
        /// </value>
        public int FileDeleteDuration { get; set; }

        /// <summary>
        /// Gets or sets the filters.
        /// </summary>
        /// <value>
        /// The filters.
        /// </value>
        public List<string> Filters { get; set; }

    }
}
