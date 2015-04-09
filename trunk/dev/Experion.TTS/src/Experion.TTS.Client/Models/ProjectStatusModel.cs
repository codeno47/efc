using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Model;

namespace Experion.TTS.Client.Models
{
    [NotifyPropertyChanged]
    public class ProjectStatusModel
    {
        /// <summary>
        /// Gets or sets the project status identifier.
        /// </summary>
        /// <value>
        /// The project status identifier.
        /// </value>
        public int ProjectStatusId { get; set; }

        /// <summary>
        /// Gets or sets the project status.
        /// </summary>
        /// <value>
        /// The project status.
        /// </value>
        public string ProjectStatus { get; set; }
    }
}
