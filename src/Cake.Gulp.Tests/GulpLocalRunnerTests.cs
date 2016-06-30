using System;
using System.IO;

using Cake.Core.IO;
using Cake.Testing;

using Shouldly;

using Xunit;

namespace Cake.Gulp.Tests {
	public class GulpLocalRunnerTests {
		private readonly GulpLocalRunnerFixture fixture;
		private readonly string gulpFile;

		public GulpLocalRunnerTests()
		{
			this.fixture = new GulpLocalRunnerFixture();
			this.gulpFile = "../gulpfile.js";
			const string pathToGulpJs = "node_modules/gulp/bin/gulp.js";
			this.fixture.FileSystem.CreateFile(pathToGulpJs);
			this.fixture.FileSystem.CreateFile("/abc");
			this.fixture.FileSystem.CreateFile(this.gulpFile);
            this.fixture.FileSystem.CreateFile("path-to-gulp/gulp.js");
        }

		[Fact]
		public void Install_Settings_With_Gulp_File_Should_Add_Gulpfile_Argument()
		{
			this.fixture.InstallSettings = s => s.WithGulpFile(this.gulpFile);

			var result = this.fixture.Run();

			result.Args.ShouldBe("\"node_modules/gulp/bin/gulp.js\" --gulpfile \"../gulpfile.js\"");
		}

		[Fact]
		public void No_Install_Settings_Specified_Should_Execute_Command_Without_Arguments()
		{
			this.fixture.InstallSettings = null;

			var result = this.fixture.Run();

			result.Args.ShouldBe("\"node_modules/gulp/bin/gulp.js\"");
		}

        [Fact]
        public void Custom_Gulp_Path()
        {
            this.fixture.InstallSettings = s => s.SetPathToGulpJs("path-to-gulp/gulp.js");
            var result = this.fixture.Run();

            result.Args.ShouldBe("\"path-to-gulp/gulp.js\"");
        }
    }
}