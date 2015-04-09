using System.Data.Linq;

namespace EFC.Samples.WPhone.Services.Data
{
    public class FieldMaxDataContext : DataContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldMaxDataContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public FieldMaxDataContext(string connectionString)
            : base(connectionString)
        {
            
        }

        // Specify the connection string as a static, used in main page and app.xaml.
        public static string DbConnectionString = "Data Source=isostore:/fieldmax.sdf";


        // Specify a single table for the to-do items.
        public Table<ToDoItem> ToDoItems;
    }
}
