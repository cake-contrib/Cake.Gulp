# Build Script

You can reference Cake.Gulp in your build script as a cake addin:

```cake
#addin "Cake.Gulp"
```

or nuget reference:

```cake
#addin "nuget:https://www.nuget.org/api/v2?package=Cake.Gulp"
```

Then some examples:

```c#
    #addin "Cake.Gulp"

    Task("Default")
        .Does(() => 
        {
            // Executes gulp from a global installation (npm install -g gulp)
            Gulp.Global.Execute();

            // Executes gulp from a local installation (npm install gulp)
            Gulp.Local.Execute();
        });
```