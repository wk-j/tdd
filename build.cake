
//#tool "nuget:?package=xunit.runner.console"
//#tool "nuget:?package=xunit.runners&version=1.9.2"
//#addin "nuget?package=Cake.Incubator"

var solution = "MyApp.sln";
var testProject = "Source/MyLibrary.Facts/MyLibrary.Facts.csproj";
var libProject = "Soruce/MyLibrary/MyLibrary.csproj";


Task("Tests").Does(() => {
     var settings = new DotNetCoreTestSettings
     {
         Configuration = "Debug",
         OutputDirectory = "build"
     };

    DotNetCoreTest(testProject);
    /*
    DotNetCoreTest(testProject, new XUnit2Settings {
        HtmlReport = true,
        OutputDirectory = "./build"
    });
    */
});

Task("Restore").Does(() => {
    DotNetCoreRestore(solution);
});

Task("Watch-Test").Does(() => {
    var dir = System.IO.Path.GetDirectoryName(testProject);
    StartProcess("dotnet", new ProcessSettings {
        Arguments = "watch test",
        WorkingDirectory = dir
    });
});


var target = Argument("target", "default");
RunTarget(target);