using System;

using Cake.Testing.Fixtures;

namespace Cake.Gulp.Tests {
	public class GulpGlobalRunnerFixture : ToolFixture<GulpRunnerSettings> {
		public GulpGlobalRunnerFixture() : base("gulp") { }

		public Action<GulpRunnerSettings> InstallSettings { get; set; }

		protected override void RunTool() {
			var tool = new GulpGlobalRunner(FileSystem, Environment, ProcessRunner, Tools);
			tool.Execute(InstallSettings);
		}
	}
}