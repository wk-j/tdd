 
// not working
/*
Task("XUnit2-Runner").Does(() => {
    var testAssemblies = GetFiles("Source/**/*.Facts.dll");
    XUnit2(testAssemblies,  new XUnit2Settings {
        ToolPath = "packages/xunit.runner.console/tools/xunit.console.exe",
        Parallelism = ParallelismOption.All,
        HtmlReport = true,
        NoAppDomain = true,
        OutputDirectory = "./build"
    });
});
*/

// not working
/*
Task("XUnit1-Runner").Does(() => {
    var testAssemblies = GetFiles("Source/**/*.Facts.dll");
    XUnit(testAssemblies);
});