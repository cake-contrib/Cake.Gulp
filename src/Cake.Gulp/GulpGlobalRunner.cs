using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Gulp
{
    /// <summary>
    /// gulp global runner.
    /// </summary>
    public class GulpGlobalRunner : GulpRunner<GulpRunnerSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="GulpGlobalRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">the file system.</param>
        /// <param name="environment">The cake environment.</param>
        /// <param name="processRunner">The cake process runner.</param>
        /// <param name="tools">The tools locator.</param>
        public GulpGlobalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes gulp from the global installation.
        /// </summary>
        /// <param name="configure">The action that configures the settings.</param>
        public override void Execute(Action<GulpRunnerSettings> configure = null)
        {
            var settings = new GulpRunnerSettings();
            configure?.Invoke(settings);
            ValidateSettings(settings);

            var args = new ProcessArgumentBuilder();
            settings.Evaluate(args);
            Run(settings, args);
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>
        /// The tool executable name.
        /// </returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "gulp.cmd";
            yield return "gulp";
        }
    }
}
