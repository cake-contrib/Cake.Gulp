using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Gulp
{
    /// <summary>
    /// contains functionality to interact with gulp
    /// </summary>
    [CakeAliasCategory("Gulp")]
    public static class GulpRunnerAliases
    {
        /// <summary>
        /// Allows access to the gulp task orchestrator for either the local or global installation
        /// </summary>
        /// <param name="context">The cake context</param>
        /// <returns></returns>
        [CakePropertyAlias(Cache = true)]
        public static GulpRunnerFactory Gulp(this ICakeContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new GulpRunnerFactory(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
        }
    }
}