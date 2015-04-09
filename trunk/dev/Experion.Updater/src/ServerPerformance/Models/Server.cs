using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ServerPerformance.Models
{
    public class Server:INotifyPropertyChanged
    {
        private double usage;
        private string name;
        private int id;
        private string workingset;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Usage
        {
            get { return usage; }
            set
            {
                usage = value;
                OnPropertyChanged("Usage");
            }
        }

        public double InitialUsage
        {
            get { return initialusage; }
            set
            {
                initialusage = value;
                OnPropertyChanged("InitialUsage");
            }
        }
        public string WorkingSet 
        {
            get { return workingset ;}
            set 
            {    workingset=value;
                 OnPropertyChanged("WorkingSet");
            } 
        }

       
            public event PropertyChangedEventHandler PropertyChanged;
            private double initialusage;
            private bool showserver;
           
            

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }



            public  ServerPerformance.EHS.ProcessInfo[] processinfolist { get; set; }

            public ServerPerformance.EHS_7.ProcessInfo[] processinfolist2 { get; set; }

            public ServerPerformance.EHS_6.ProcessInfo[] processinfolist3 { get; set; }

            public List<ProcInfo> procinfolist { get; set; }

            public bool ShowServer
            {
                get { return showserver; }
                set
                {
                    showserver = value;
                    OnPropertyChanged("ShowServer");
                }
            }
          


    }

    

   
}