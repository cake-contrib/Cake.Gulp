using System;
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
            AssertThat(factory != null, "Gulp factory should be non-null");

            var local = factory.Local;
            AssertThat(local != null, "Gulp.Local should be non-null");

            var global = factory.Global;
            AssertThat(global != null, "Gulp.Global should be non-null");

            context.Information("Alias surface OK (factory + Local + Global resolved)");
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
