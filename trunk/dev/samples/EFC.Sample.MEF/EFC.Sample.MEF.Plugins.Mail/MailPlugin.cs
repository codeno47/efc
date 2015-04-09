using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFC.Sample.MEF.Plugins.Mail
{
    using System.ComponentModel.Composition;
    using System.Windows;

    using EFC.Sample.MEF.Data.Contracts;

    [Export(typeof(IPlugin))]
    [ExportMetadata("MailPlugin", "EFC.Sample.MEF.Plugins.Mail")]
    public class MailPlugin : IPlugin
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MailPlugin"/> class.
        /// </summary>
        public MailPlugin()
        {
            Name = "Mail Plugin";
        }
        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Execute()
        {
            MessageBox.Show("From Mail Plugin");
        }
    }
}
