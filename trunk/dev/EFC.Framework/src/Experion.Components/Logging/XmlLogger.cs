namespace EFC.Components.Logging
{
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// XmlLogger
    /// </summary>
    public class XmlLogger
    {
        /// <summary>
        /// Gets or sets the DependencyContainer.
        /// </summary>
        /// <value>
        /// The DependencyContainer.
        /// </value>
        private IUnityContainer DependencyContainer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlLogger"/> class.
        /// </summary>
        /// <param name="dependencyContainer">The DependencyContainer.</param>
        public XmlLogger(IUnityContainer dependencyContainer)
        {
            if (dependencyContainer == null)
            {
                throw new InvalidDataException("Unity container cannot be null");
            }
            this.DependencyContainer = dependencyContainer;
        }

        /// <summary>
        /// Saves the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <exception cref="System.IO.InvalidDataException">AuditLoggingDatabase instance not found. Connection string not found in unity configuration.</exception>
        public void Save(string xml)
        {
            var connectionString = DependencyContainer.Resolve<string>("AuditLoggingDatabase");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidDataException("AuditLoggingDatabase instance not found. Connection string not found in unity configuration.");
            }

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("INSERT AuditTrail VALUES (@XML)", connection))
                {
                    command.Parameters.Add("XML", SqlDbType.Xml, xml.Length).Value = xml;
                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}
