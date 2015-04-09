using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TTsys.Models
{
    public class timetrackBO : INotifyPropertyChanged
    {
        private string projectname;
        public string ProjectName 
        { 
            get { return projectname; } 
            set {
                projectname=value ;
                OnPropertyChanged("ProjectName");
                } 
        }

  
        public double Day1 
        {
            get { return day1;}
            set { day1=value;
            OnPropertyChanged("Day1");
            }
        }
       
             public double Day2 { get; set; }

     
        public double Day3 { get; set; }

     
        public double Day4 { get; set; }

   
      public double Day5 { get; set; }

    
    public double Day6 { get; set; }

    
    public double Day7 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private double day1;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Day1Name { get; set; }

        
        public string Day2Name { get; set; }

        public string Day3Name { get; set; }
        public string Day4Name { get; set; }
        public string Day5Name { get; set; }

        public List<dateAndEffort> dateEffortlist { get; set; }

        public List<timetrackBO> timetrklist { get; set; }
    }
}