using System;
using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.Gulp;

namespace Build.Tasks
{
    [TaskName("Settings-Global")]
    public sealed class SettingsGlobalTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            var settings = new GulpRunnerSettings();
            settings.WithGulpFile("./gulpfile.js");
            settings.WithArguments("default --silent");

            AssertThat(
                settings.GulpFile != null && settings.GulpFile.FullPath.EndsWith("gulpfile.js"),
                "GulpFile round-trip mismatch: " + (settings.GulpFile?.FullPath ?? "<null>"));
            AssertThat(
                settings.Arguments == "default --silent",
                "Arguments round-trip mismatch: " + settings.Arguments);

            context.Information(
                "GulpRunnerSettings OK (GulpFile={0}, Arguments={1})",
                settings.GulpFile.FullPath,
                settings.Arguments);
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
