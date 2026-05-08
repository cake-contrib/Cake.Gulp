#reference "../../BuildArtifacts/temp/_PublishedLibraries/Cake.Gulp/net6.0/Cake.Gulp.dll"

// Self-contained exercise of Cake.Gulp's settings + alias surface.
// Verifies the addin loads, the settings types can be constructed and
// round-tripped, and the runner aliases are accessible. Does NOT
// actually invoke gulp — the addin shells out to node, which isn't a
// runtime dependency of the addin itself or of the workspace's
// canonical CI matrix. The settings round-trip is what matters at
// the addin's API surface.

using Cake.Gulp;

void AssertThat(bool condition, string message)
{
    if (!condition)
    {
        throw new Exception("Assertion failed: " + message);
    }
}

Task("Default")
    .IsDependentOn("Settings-Global")
    .IsDependentOn("Settings-Local")
    .IsDependentOn("Alias-Surface");

Task("Settings-Global")
    .Does(() =>
{
    var settings = new GulpRunnerSettings();
    settings.WithGulpFile("./gulpfile.js");
    settings.WithArguments("default --silent");

    AssertThat(settings.GulpFile != null, "GulpFile should be set");
    AssertThat(settings.GulpFile.FullPath.EndsWith("gulpfile.js"),
        "GulpFile mismatch: " + settings.GulpFile.FullPath);
    AssertThat(settings.Arguments == "default --silent",
        "Arguments mismatch: " + settings.Arguments);

    Information("GulpRunnerSettings OK (GulpFile={0}, Arguments={1})",
        settings.GulpFile.FullPath, settings.Arguments);
});

Task("Settings-Local")
    .Does(() =>
{
    var settings = new GulpLocalRunnerSettings();
    settings.WithGulpFile("./build.gulpfile.js");
    settings.WithArguments("ci");
    settings.SetPathToGulpJs("custom/path/gulp.js");

    AssertThat(settings.GulpFile != null
        && settings.GulpFile.FullPath.EndsWith("build.gulpfile.js"),
        "GulpFile mismatch");
    AssertThat(settings.Arguments == "ci",
        "Arguments mismatch: " + settings.Arguments);
    AssertThat(settings.PathToGulpJs.FullPath == "custom/path/gulp.js",
        "PathToGulpJs mismatch: " + settings.PathToGulpJs.FullPath);

    Information("GulpLocalRunnerSettings OK (PathToGulpJs={0})",
        settings.PathToGulpJs.FullPath);
});

Task("Alias-Surface")
    .Does(() =>
{
    // Resolve the Gulp property alias and walk through to both runner
    // factories. This proves the [CakePropertyAlias] dispatch and the
    // runner-construction path are both wired correctly under the
    // demo's cake.tool.
    var factory = Gulp;
    AssertThat(factory != null, "Gulp factory should be non-null");

    var local = factory.Local;
    AssertThat(local != null, "Gulp.Local should be non-null");

    var global = factory.Global;
    AssertThat(global != null, "Gulp.Global should be non-null");

    Information("Alias surface OK (factory + Local + Global resolved)");
});

RunTarget("Default");
