using Cake.Testing;
using Shouldly;
using Xunit;

namespace Cake.Gulp.Tests {
	public class GulpLocalRunnerTests {
		private readonly GulpLocalRunnerFixture _fixture;
		private readonly string _gulpFile;

		public GulpLocalRunnerTests()
		{
			this._fixture = new GulpLocalRunnerFixture();
            this._gulpFile = "gulpfile.js";
			const string pathToGulpJs = "/Working/node_modules/gulp/bin/gulp.js";
			this._fixture.FileSystem.CreateFile(pathToGulpJs);
			this._fixture.FileSystem.CreateFile("/abc");
			this._fixture.FileSystem.CreateFile(this._gulpFile);
            this._fixture.FileSystem.CreateFile("/Working/path-to-gulp/gulp.js");
        }

		[Fact]
		public void Install_Settings_With_Gulp_File_Should_Add_Gulpfile_Argument()
		{
			this._fixture.InstallSettings = s => s.WithGulpFile(this._gulpFile);

			var result = this._fixture.Run();

			result.Args.ShouldBe("\"/Working/node_modules/gulp/bin/gulp.js\" --gulpfile \"gulpfile.js\"");
		}

		[Fact]
		public void No_Install_Settings_Specified_Should_Execute_Command_Without_Arguments()
		{
			this._fixture.InstallSettings = null;

			var result = this._fixture.Run();

			result.Args.ShouldBe("\"/Working/node_modules/gulp/bin/gulp.js\"");
		}

        [Fact]
        public void Custom_Gulp_Path()
        {
            this._fixture.InstallSettings = s => s.SetPathToGulpJs("path-to-gulp/gulp.js");
            var result = this._fixture.Run();

            result.Args.ShouldBe("\"/Working/path-to-gulp/gulp.js\"");
        }
    }
}