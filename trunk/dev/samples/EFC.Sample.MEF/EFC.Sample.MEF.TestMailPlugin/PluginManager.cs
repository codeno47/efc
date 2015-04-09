namespace EFC.Sample.MEF.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;

    using EFC.Sample.MEF.Data.Contracts;

    public class PluginManager
    {
        /// <summary>
        /// Gets or sets the plugins.
        /// </summary>
        /// <value>
        /// The plugins.
        /// </value>
        [ImportMany(typeof(IPlugin), AllowRecomposition = true)]
        public IEnumerable<IPlugin> Plugins { get; set; }

        /// <summary>
        /// The container
        /// </summary>
        private CompositionContainer container;

        /// <summary>
        /// The searchpath
        /// </summary>
        private const string Searchpath = "plugins";

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginManager"/> class.
        /// </summary>
        public PluginManager()
        {
            this.InitlizePlugin();
        }

        /// <summary>
        /// Initlizes the plugin.
        /// </summary>
        private void InitlizePlugin()
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Searchpath);
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new DirectoryCatalog(directory));

            this.container = new CompositionContainer(catalog);

            try
            {
                // here 'this' is the consumer of the plugin.
                this.container.ComposeParts(this);
            }
            catch (Exception exception)
            {

                throw;
            }

        }
    }
}
