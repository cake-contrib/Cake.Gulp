using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.IO;

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
        /// <param name="globber">The globber</param>
        public GulpLocalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) : base(fileSystem, environment, processRunner, globber)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes gulp from the local installation
        /// </summary>
        public override void Execute(Action<GulpLocalRunnerSettings> configure = null)
        {
            var settings = new GulpLocalRunnerSettings(_fileSystem);
            configure?.Invoke(settings);

            if(!_fileSystem.Exist(settings.PathToGulpJs)) throw new FileNotFoundException($"unable to find local gulp installation at specified path [{settings.PathToGulpJs}], have you run 'npm install gulp'?");

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
        }
    }
}