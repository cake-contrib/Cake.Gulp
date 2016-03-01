using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Gulp
{
    public class GulpLocalRunner : GulpRunner
    {
        public GulpLocalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Executes gulp from the local installation
        /// </summary>
        public override void Execute()
        {
            if(!File.Exists("./node_modules/gulp/bin/gulp.js")) throw new FileNotFoundException("unable to find local gulp installation, have you run 'npm install gulp'?");
            var args = new ProcessArgumentBuilder();
            args.Append("./node_modules/gulp/bin/gulp.js");
            Run(new GulpRunnerSettings(), args);
        }
        
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "node.exe";
        }
    }
}