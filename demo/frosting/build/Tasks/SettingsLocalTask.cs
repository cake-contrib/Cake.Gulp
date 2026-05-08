using System;
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

            AssertThat(
                settings.GulpFile != null && settings.GulpFile.FullPath.EndsWith("build.gulpfile.js"),
                "GulpFile round-trip mismatch: " + (settings.GulpFile?.FullPath ?? "<null>"));
            AssertThat(
                settings.Arguments == "ci",
                "Arguments round-trip mismatch: " + settings.Arguments);
            AssertThat(
                settings.PathToGulpJs.FullPath == "custom/path/gulp.js",
                "PathToGulpJs round-trip mismatch: " + settings.PathToGulpJs.FullPath);

            context.Information(
                "GulpLocalRunnerSettings OK (PathToGulpJs={0})",
                settings.PathToGulpJs.FullPath);
        }

        private static void AssertThat(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception("Assertion failed: " + message);
            }
        }
    }
}
