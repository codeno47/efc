// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="DatabaseService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="DatabaseService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using EFC.Common.Service;
using EFC.Components.Aspect;
using Experion.Common.Tools.ConnectionChecker.Service;
using Microsoft.Practices.Unity;

namespace EFC.Common.Tools.ConnectionChecker.Service
{
    public class DatabaseService : BusinessService, IDatabaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        public DatabaseService(IUnityContainer unity)
            : base(unity)
        {
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns></returns>
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FieldMaxLicenceConString"].ConnectionString;
        }

        /// <summary>
        /// Determines whether [is server active].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is server active]; otherwise, <c>false</c>.
        /// </returns>
        [HandleException("ApplicationPolicy")]
        public bool IsServerActive()
        {
            try
            {
                //try to open the connection with a connection string.
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    //open connection .
                    connection.Open();
                    //if control reaches this point, server is active  so result set to True.
                    //close the connection.
                    connection.Close();
                }
                return true;
            }
            catch (SqlException)
            {
                return false;
            }

        }

        /// <summary>
        /// Gets the connection details to table.
        /// </summary>
        /// <returns></returns>
        [HandleException("ApplicationPolicy")]
        public DataTable GetConnectionDetailsToTable()
        {
            var builder = new StringBuilder();
            builder.Append("SELECT db_name(dbid) as DatabaseName");
            builder.Append(", count(dbid) as NoOfConnections,");
            builder.Append("loginame as LoginName");
            builder.Append(" FROM sys.sysprocesses");
            builder.Append(" WHERE dbid > 0");
            builder.Append(" GROUP BY dbid, loginame");

            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var command = new SqlCommand(builder.ToString()) { Connection = connection };
                var adapter = new SqlDataAdapter(command);

                var dt = new DataTable("DBDetails");
                adapter.Fill(dt);

                return dt;
            }
        }

        /// <summary>
        /// Saves this Current changes to database.
        /// </summary>
        /// <returns>
        /// Status code.
        /// </returns>
        public override int Save()
        {
            return 0;
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }

}
