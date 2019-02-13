using System.IO;
using Cake.Core.IO;

namespace Cake.Gulp
{
    /// <summary>
    /// gulp local runner settings
    /// </summary>
    public class GulpLocalRunnerSettings : GulpRunnerSettings
    {
        /// <summary>
        /// Path to node modules
        /// </summary>
        public FilePath PathToGulpJs { get; private set; } = "node_modules/gulp/bin/gulp.js";

        /// <summary>
        /// Overrides the default path to gulp javascript, the current working directory will be prepended to this path
        /// </summary>
        /// <param name="gulpJs">path to gulp if different from './node_modules/gulp/bin/gulp.js'</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public GulpLocalRunnerSettings SetPathToGulpJs(FilePath gulpJs)
        {
            PathToGulpJs = gulpJs;
            return this;
        }

        /// <summary>
        /// Overrides the default path to the NodeJs tool that will be used to run gulp.
        /// </summary>
        /// <param name="toolPath">path to NodeJs</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public GulpLocalRunnerSettings SetToolPath(FilePath toolPath)
        {
            ToolPath = toolPath;
            return this;
        }
    }
}