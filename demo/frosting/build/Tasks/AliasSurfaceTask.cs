using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.Gulp;

namespace Build.Tasks
{
    [TaskName("Alias-Surface")]
    public sealed class AliasSurfaceTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            var factory = context.Gulp();
            if (factory == null)
            {
                throw new System.Exception("Gulp factory should be non-null");
            }

            var local = factory.Local;
            if (local == null)
            {
                throw new System.Exception("Gulp.Local should be non-null");
            }

            var global = factory.Global;
            if (global == null)
            {
                throw new System.Exception("Gulp.Global should be non-null");
            }

            context.Information("Alias surface OK (factory + Local + Global resolved)");
        }
    }
}
