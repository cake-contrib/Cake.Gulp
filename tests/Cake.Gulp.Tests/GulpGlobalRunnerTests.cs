using Cake.Testing;

using Shouldly;

using Xunit;

namespace Cake.Gulp.Tests {
	public class GulpGlobalRunnerTests {
		private readonly GulpGlobalRunnerFixture fixture;
		private readonly string gulpFile;

		public GulpGlobalRunnerTests()
		{
			this.fixture = new GulpGlobalRunnerFixture();
			this.gulpFile = "../gulpfile.js";
			this.fixture.FileSystem.CreateFile(this.gulpFile);
		}

		[Fact]
		public void Install_Settings_With_Gulp_File_Should_Add_Gulpfile_Argument()
		{
			this.fixture.InstallSettings = s => s.WithGulpFile(this.gulpFile);

			var result = this.fixture.Run();

			result.Args.ShouldBe("--gulpfile \"../gulpfile.js\"");
		}

		[Fact]
		public void Install_Settings_With_Gulp_File_Ánd_Arguments_Should_Add_Gulp_File_And_Additional_Arguments()
		{
			this.fixture.InstallSettings = s => s.WithGulpFile(this.gulpFile).WithArguments("--production");

			var result = this.fixture.Run();

			result.Args.ShouldBe("--gulpfile \"../gulpfile.js\" --production");
		}

		[Fact]
		public void No_Install_Settings_Specified_Should_Execute_Command_Without_Arguments()
		{
			this.fixture.InstallSettings = null;

			var result = this.fixture.Run();

			result.Args.ShouldBe("");
		}
	}
}