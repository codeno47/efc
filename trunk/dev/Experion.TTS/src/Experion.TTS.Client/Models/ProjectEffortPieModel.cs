using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.TTS.Client.Models
{
    using EFC.Client.Common.Base;

    public class ProjectEffortPieModel : ModelBase
    {
        private decimal effort;

        private string projectCode;

        private string projectName;

        public int ProjectID { get; set; }

        public string ProjectCode
        {
            get
            {
                return this.projectCode;
            }
            set
            {
                this.projectCode = value;
                this.RaisePropertyChanged("ProjectCode");
            }
        }

        public string ProjectName
        {
            get
            {
                return this.projectName;
            }
            set
            {
                this.projectName = value;
                this.RaisePropertyChanged("ProjectName");
            }
        }

        public decimal Effort
        {
            get
            {
                return this.effort;
            }
            set
            {
                this.effort = value;
                this.RaisePropertyChanged("Effort");
            }
        }

        public string Label
        {
            get
            {
                return string.Format("{0} Total Effort : {1}", ProjectName, Effort);
            }
        }
    }
}
