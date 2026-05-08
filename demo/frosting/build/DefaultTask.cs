using Build.Tasks;
using Cake.Frosting;

namespace Build
{
    [TaskName("Default")]
    [IsDependentOn(typeof(SettingsGlobalTask))]
    [IsDependentOn(typeof(SettingsLocalTask))]
    [IsDependentOn(typeof(AliasSurfaceTask))]
    public sealed class DefaultTask : FrostingTask
    {
    }
}
