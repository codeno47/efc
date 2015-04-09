using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EFC.Samples.WPhone.Services.Annotations;
using EFC.Service.Phone.Data;

namespace EFC.Samples.WPhone.Services.Data
{
    // Define the to-do items database table.
    [Table]
    public class ToDoItem : SqLiteTableBase
    {
        // Define ID: private field, public property, and database column.
        private int toDoItemId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false,
            AutoSync = AutoSync.OnInsert)]
        public int ToDoItemId
        {
            get { return toDoItemId; }
            set
            {
                if (toDoItemId != value)
                {
                    OnPropertyChanging("ToDoItemId");
                    toDoItemId = value;
                    OnPropertyChanged("ToDoItemId");
                }
            }
        }

        
    }
}
