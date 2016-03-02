using Cake.Core;
using Cake.Core.IO;

namespace Cake.Gulp
{
    /// <summary>
    /// Returns a gulp runner based on either a local or global gulp installation via npm
    /// </summary>
    public class GulpRunnerFactory
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IProcessRunner _processRunner;
        private readonly IGlobber _globber;

        internal GulpRunnerFactory(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IGlobber globber)
        {
            _fileSystem = fileSystem;
            _environment = environment;
            _processRunner = processRunner;
            _globber = globber;
        }
        
        /// <summary>
        /// Get a gulp local runner based on a local gulp installation, a local installation is achieved through `npm install gulp`
        /// </summary>
        public GulpRunner<GulpLocalRunnerSettings> Local => new GulpLocalRunner(_fileSystem, _environment, _processRunner, _globber);
        
        /// <summary>
        /// Get a gulp global runner based on a global gulp installation, a global installation is achieved through `npm install gulp -g`
        /// </summary>
        public GulpRunner<GulpRunnerSettings> Global => new GulpGlobalRunner(_fileSystem, _environment, _processRunner, _globber);
    }
}