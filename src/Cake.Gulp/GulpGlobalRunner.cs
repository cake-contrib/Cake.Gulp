using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Gulp
{
    /// <summary>
    /// gulp global runner
    /// </summary>
    public class GulpGlobalRunner : GulpRunner<GulpRunnerSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// creates a new gulp global runner
        /// </summary>
        /// <param name="fileSystem">the file system</param>
        /// <param name="environment">The cake environment</param>
        /// <param name="processRunner">The cake process runner</param>
        /// <param name="globber">The globber</param>
        public GulpGlobalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) : base(fileSystem, environment, processRunner, globber)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes gulp from the global installation
        /// </summary>
        public override void Execute(Action<GulpRunnerSettings> configure = null)
        {
            var settings = new GulpRunnerSettings(_fileSystem);
            configure?.Invoke(settings);

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