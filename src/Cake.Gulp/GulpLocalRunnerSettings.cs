using Cake.Core.IO;

namespace Cake.Gulp
{
    /// <summary>
    /// gulp local runner settings.
    /// </summary>
    public class GulpLocalRunnerSettings : GulpRunnerSettings
    {
        /// <summary>
        /// Gets path to node modules.
        /// </summary>
        public FilePath PathToGulpJs { get; private set; } = "node_modules/gulp/bin/gulp.js";

        /// <summary>
        /// Overrides the default path to gulp javascript, the current working directory will be prepended to this path.
        /// </summary>
        /// <param name="gulpJs">path to gulp if different from './node_modules/gulp/bin/gulp.js'.</param>
        /// <returns>The <see cref="GulpLocalRunnerSettings"/> for fluent re-use.</returns>
        public GulpLocalRunnerSettings SetPathToGulpJs(FilePath gulpJs)
        {
            PathToGulpJs = gulpJs;
            return this;
        }
    }
}
