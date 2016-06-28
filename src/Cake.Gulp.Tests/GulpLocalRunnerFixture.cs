using System;

using Cake.Testing.Fixtures;

namespace Cake.Gulp.Tests {
	public class GulpLocalRunnerFixture : ToolFixture<GulpLocalRunnerSettings>
	{
		public GulpLocalRunnerFixture() : base("node") {}

		public Action<GulpLocalRunnerSettings> InstallSettings { get; set; }

		protected override void RunTool()
		{
			var tool = new GulpLocalRunner(FileSystem, Environment, ProcessRunner, Globber);
			tool.Execute(InstallSettings);
		}
	}
}