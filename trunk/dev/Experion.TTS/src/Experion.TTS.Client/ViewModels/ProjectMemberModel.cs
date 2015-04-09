using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.TTS.Client.Model
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using EFC.Client.Common.Base;

    using Experion.TTS.Client.Annotations;

    public class ProjectMemberModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public int ProjectId { get; set; }

        private string name;

        private string role;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                OnPropertyChanged("Name");
                this.name = value;
            }
        }

        public string Role
        {
            get
            {
                return this.role;
            }
            set
            {
                OnPropertyChanged("Role");
                this.role = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
