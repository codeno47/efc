// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ConnectionModel.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ConnectionModel.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Data;
using EFC.Client.Common.Base;

namespace Experion.Common.Tools.ConnectionChecker.ConnectionCheckerViewModel
{
    /// <summary>
    /// ConnectionModel
    /// </summary>
    public class ConnectionModel : ModelBase
    {
        private DataView connectionData;

        /// <summary>
        /// Gets or sets the connection data.
        /// </summary>
        /// <value>
        /// The connection data.
        /// </value>
        public DataView ConnectionData
        {
            get { return connectionData; }
            set
            {
                connectionData = value;
                RaisePropertyChanged("ConnectionData");
            }
        }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>
        /// The name of the server.
        /// </value>
        public string ServerName
        {
            get { return serverName; }
            set
            {
                RaisePropertyChanged("ServerName");
                serverName = value;
            }
        }

        private string serverName;
    }
}
