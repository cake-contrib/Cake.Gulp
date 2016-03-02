using System;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Gulp
{
    /// <summary>
    /// Gulp settings
    /// </summary>
    public class GulpRunnerSettings : ToolSettings
    {
        /// <summary>
        /// The file system
        /// </summary>
        protected readonly IFileSystem FileSystem;

        internal GulpRunnerSettings(IFileSystem fileSystem)
        {
            FileSystem = fileSystem;
        }

        /// <summary>
        /// The gulpfile to run
        /// </summary>
        public FilePath GulpFile { get; private set; }

        /// <summary>
        /// Argument string to pass to gulp
        /// </summary>
        public string Arguments { get; private set; }

        /// <summary>
        /// The gulpfile to use
        /// </summary>
        /// <param name="gulpfile">path to gulpfile</param>
        /// <returns>the settings</returns>
        public GulpRunnerSettings WithGulpFile(FilePath gulpfile)
        {
            if(gulpfile.GetExtension() != ".js") throw new ArgumentException("gulpfile should be a javascript file with the .js extension");
            if(!FileSystem.Exist(gulpfile)) throw new FileNotFoundException("gulpfile not found", gulpfile.FullPath);

            GulpFile = gulpfile;

            return this;
        }

        /// <summary>
        /// The argument string to pass to gulp
        /// </summary>
        /// <param name="arguments">an argument string</param>
        /// <returns>the settings</returns>
        public GulpRunnerSettings WithArguments(string arguments)
        {
            Arguments = arguments;
            return this;
        }

        internal void Evaluate(ProcessArgumentBuilder args)
        {
            if(GulpFile != null) args.AppendSwitchQuoted("--gulpfile", GulpFile.FullPath);
            if (!string.IsNullOrWhiteSpace(Arguments)) args.Append(Arguments);
            EvaluateCore(args);
        }

        /// <summary>
        /// evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
            
        }
    }
}