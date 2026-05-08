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

            if (settings.GulpFile == null || !settings.GulpFile.FullPath.EndsWith("gulpfile.js"))
            {
                throw new System.Exception("GulpFile round-trip failed");
            }

            if (settings.Arguments != "default --silent")
            {
                throw new System.Exception("Arguments round-trip failed: " + settings.Arguments);
            }

            context.Information(
                "GulpRunnerSettings OK (GulpFile={0}, Arguments={1})",
                settings.GulpFile.FullPath,
                settings.Arguments);
        }
    }
}
