using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFC.Sample.MEF.Plugins.Push
{
    using System.ComponentModel.Composition;
    using System.Windows;

    using EFC.Sample.MEF.Data.Contracts;

    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IPlugin))]
    [ExportMetadata("PushPlugin", "EFC.Sample.MEF.Plugins.Push")]
    public class PushPlugin : IPlugin
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PushPlugin"/> class.
        /// </summary>
        public PushPlugin()
        {
            Name = "PushPlugin";
        }
        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute()
        {
            MessageBox.Show("From PUSH Plugin");
        }
    }
}
