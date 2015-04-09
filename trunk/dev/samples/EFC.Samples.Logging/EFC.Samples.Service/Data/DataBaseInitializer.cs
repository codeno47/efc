using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Samples.Service.Model;

namespace EFC.Samples.Service.Data
{
    public class DataBaseInitializer : IDatabaseInitializer<FieldMaxDataContainer>
    {
        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <param name="context">The context.</param>
        public void InitializeDatabase(FieldMaxDataContainer context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
