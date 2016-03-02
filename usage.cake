// #addin "Cake.Gulp"
#r "src\Cake.Gulp\bin\Debug\Cake.Gulp.dll"

Task("Default")
    .Does(() => 
    {
        try {
            Information("Running Global Gulp");
            // Executes gulp from a global installation (npm install -g gulp)
            Gulp.Global.Execute();
        } catch(Exception ex) {
            Error(ex.ToString());
        }
        
        try {
            Information("Running Local Gulp");
            // Executes gulp from a local installation (npm install gulp)
            Gulp.Local.Execute(settings => settings.WithGulpFile("gulpfile.js"));
        } catch(Exception ex) {
            Error(ex.ToString());
        }
    });
        
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

RunTarget(target);    