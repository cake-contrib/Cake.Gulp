using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Gulp
{
    /// <summary>
    /// gulp local runner
    /// </summary>
    public class GulpLocalRunner : GulpRunner<GulpLocalRunnerSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// creates a new gulp local runner
        /// </summary>
        /// <param name="fileSystem">the file system</param>
        /// <param name="environment">The cake environment</param>
        /// <param name="processRunner">The cake process runner</param>
        /// <param name="tools">The tools locator</param>
        public GulpLocalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes gulp from the local installation
        /// </summary>
        public override void Execute(Action<GulpLocalRunnerSettings> configure = null)
        {
            var settings = new GulpLocalRunnerSettings();
            configure?.Invoke(settings);
            ValidateSettings(settings);

            var workingDir = GetWorkingDirectory(settings);

            var gulpJsPath = FilePath.FromString(workingDir +"/" + settings.PathToGulpJs);
            if (!_fileSystem.Exist(gulpJsPath)) throw new FileNotFoundException($"unable to find local gulp installation at specified path [{gulpJsPath}], have you run 'npm install gulp'?");

            var args = new ProcessArgumentBuilder();
            args.AppendQuoted(gulpJsPath.ToString());
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