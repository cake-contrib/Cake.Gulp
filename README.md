# cake-gulp

## Usage

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

## Scope
At present the scope of the implementation of this Cake addin is to meet my own requirements, which are primarily to support a client side build process for a typical .NET based web application.  
This process would usual involve a design or creative team developing and maintaining client side assets (js, scss) for which they have a gulp based development and build workflow.

My goal to be to able to support this workflow as part of a complete solution build.

### I cant do <insert-function-here>
See above, the initial release supports only the most basic functionality I need, if you have feature requests please submit them as issues
