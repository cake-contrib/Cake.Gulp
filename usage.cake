#addin "Cake.Gulp"

Task("Default")
    .Does(() => 
    {
        // Executes gulp from a global installation (npm install -g gulp)
        Gulp.Global.Execute();
        
        // Executes gulp from a local installation (npm install gulp)
        Gulp.Local.Execute();
    });
        
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

RunTarget(target);    