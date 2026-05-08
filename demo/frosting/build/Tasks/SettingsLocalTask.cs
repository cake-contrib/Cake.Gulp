using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.Gulp;

namespace Build.Tasks
{
    [TaskName("Settings-Local")]
    public sealed class SettingsLocalTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            var settings = new GulpLocalRunnerSettings();
            settings.WithGulpFile("./build.gulpfile.js");
            settings.WithArguments("ci");
            settings.SetPathToGulpJs("custom/path/gulp.js");

            if (settings.GulpFile == null
                || !settings.GulpFile.FullPath.EndsWith("build.gulpfile.js"))
            {
                throw new System.Exception("GulpFile round-trip failed");
            }

            if (settings.Arguments != "ci")
            {
                throw new System.Exception("Arguments round-trip failed: " + settings.Arguments);
            }

            if (settings.PathToGulpJs.FullPath != "custom/path/gulp.js")
            {
                throw new System.Exception(
                    "PathToGulpJs round-trip failed: " + settings.PathToGulpJs.FullPath);
            }

            context.Information(
                "GulpLocalRunnerSettings OK (PathToGulpJs={0})",
                settings.PathToGulpJs.FullPath);
        }
    }
}
