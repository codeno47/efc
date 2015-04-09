using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Client.Common.Base;
using GalaSoft.MvvmLight;

namespace Experion.TTS.Client.Models
{
    public class GoToViewModelMessage
    {
        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public ViewModel ViewModel { get; set; }
    }
}
