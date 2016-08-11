using System;
using System.IO;
using System.Xml.Schema;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Gulp
{
    /// <summary>
    /// Base gulp runner
    /// </summary>
    public abstract class GulpRunner<TSettings> : Tool<TSettings> where TSettings : GulpRunnerSettings
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// creates a new gulp runner
        /// </summary>
        /// <param name="fileSystem">the file system</param>
        /// <param name="environment">The cake environment</param>
        /// <param name="processRunner">The cake process runner</param>
        /// <param name="tools">The tools locator</param>
        protected GulpRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>
        /// The name of the tool.
        /// </returns>
        protected override string GetToolName()
        {
            return "Gulp Runner";
        }

        /// <summary>
        /// Executes gulp
        /// </summary>
        public abstract void Execute(Action<TSettings> settings = null);

        /// <summary>
        /// Validates settings
        /// </summary>
        /// <param name="settings">the settings class</param>
        /// <exception cref="FileNotFoundException">when gulp file does not exist</exception>
        protected virtual void ValidateSettings(TSettings settings = null)
        {
            if (settings?.GulpFile != null && !_fileSystem.Exist(settings.GulpFile))
            {
                throw new FileNotFoundException("gulpfile not found", settings.GulpFile.FullPath);
            }
        }
    }
}