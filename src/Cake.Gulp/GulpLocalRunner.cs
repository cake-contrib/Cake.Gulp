using System;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Gulp
{
    /// <summary>
    /// gulp local runner.
    /// </summary>
    public class GulpLocalRunner : GulpRunner<GulpLocalRunnerSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="GulpLocalRunner"/> class. A new gulp local runner.
        /// </summary>
        /// <param name="fileSystem">the file system.</param>
        /// <param name="environment">The cake environment.</param>
        /// <param name="processRunner">The cake process runner.</param>
        /// <param name="tools">The tools locator.</param>
        public GulpLocalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes gulp from the local installation.
        /// </summary>
        /// <param name="configure">The action to configure the settings.</param>
        public override void Execute(Action<GulpLocalRunnerSettings> configure = null)
        {
            var settings = new GulpLocalRunnerSettings();
            configure?.Invoke(settings);
            ValidateSettings(settings);

            var args = new ProcessArgumentBuilder();
            args.AppendQuoted(settings.PathToGulpJs.ToString());
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
            yield return "node.exe";
            yield return "node";
            yield return "nodejs";
        }
    }
}
