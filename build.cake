
var solution = "MyApp.sln";
var testProject = "Source/MyLibrary.Facts/MyLibrary.Facts.csproj";
var libProject = "Soruce/MyLibrary/MyLibrary.csproj";

Task("Tests").Does(() => {
    DotNetCoreTest(testProject);
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