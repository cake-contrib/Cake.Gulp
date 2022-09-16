using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Gulp
{
    /// <summary>
    /// contains functionality to interact with gulp.
    /// </summary>
    [CakeAliasCategory("Node")]
    public static class GulpRunnerAliases
    {
        /// <summary>
        /// Allows access to the gulp task orchestrator for either the local or global installation.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <returns>A new instance of the <see cref="GulpRunnerFactory"/>.</returns>
        /// <example>
        /// <para>Run 'gulp' from your local gulp installation.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Gulp")
        ///     .Does(() =>
        /// {
        ///     Gulp.Local.Execute();
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'gulp' from your global gulp installation.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Gulp")
        ///     .Does(() =>
        /// {
        ///     Gulp.Global.Execute();
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'gulp --gulpfile gulpbuild.js'.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Gulp")
        ///     .Does(() =>
        /// {
        ///     Gulp.Local.Execute(settings => settings.WithGulpFile("gulpbuild.js"));
        ///
        ///     Gulp.Global.Execute(settings => settings.WithGulpFile("gulpbuild.js"));
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'gulp ci'.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Gulp")
        ///     .Does(() =>
        /// {
        ///     Gulp.Local.Execute(settings => settings.WithArguments("ci"));
        ///     Gulp.Global.Execute(settings => settings.WithArguments("ci"));
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'gulp ci --dist=./artifacts/dist'.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Gulp")
        ///     .Does(() =>
        /// {
        ///     Gulp.Local.Execute(settings => settings.WithArguments("ci --dist=./artifacts/dist"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakePropertyAlias(Cache = true)]
        public static GulpRunnerFactory Gulp(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new GulpRunnerFactory(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }
    }
}
