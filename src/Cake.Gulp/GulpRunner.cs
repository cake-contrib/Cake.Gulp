using System;
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
        /// <summary>
        /// creates a new gulp runner
        /// </summary>
        /// <param name="fileSystem">the file system</param>
        /// <param name="environment">The cake environment</param>
        /// <param name="processRunner">The cake process runner</param>
        /// <param name="globber">The globber</param>
        protected GulpRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) : base(fileSystem, environment, processRunner, globber)
        {
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
    }
}