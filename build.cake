#addin "Cake.FileHelpers"
#tool nuget:?package=xunit.runner.console&version=2.3.1
#addin "nuget:?package=Cake.Incubator"

var target = Argument("target", "Default");
var configuration = Argument("Configuration", "Release");
var MockEsiLocation = Argument("MockEsiLocation", "http://127.0.0.1:8080");
var solutionFile = "";

Task("Restore")  
    .Does(() =>
    {
        DotNetCoreRestore("./ESIConnectionLibrary/");
    });

Task("Build")
.IsDependentOn("Restore")
.Does(() =>
{
    DotNetCoreBuild("./ESIConnectionLibrary/",
        new DotNetCoreBuildSettings()
        {
            Configuration = configuration,
            ArgumentCustomization = args => args.Append("--no-restore"),
        });
});

Task("ReplaceTestingUrl")
.IsDependentOn("Build")
.Does(() =>
{
    ReplaceTextInFiles("./**/Internal classes/StaticConnectionStrings.cs", "private static string TestEsiBaseUrl => \"http://127.0.0.1:8080\";", $"private static string TestEsiBaseUrl => \"{MockEsiLocation}\";");
});

Task("Test")  
.IsDependentOn("ReplaceTestingUrl")
    .Does(() =>
    {
        var testAssemblies = GetFiles($"./ESIConnectionLibrary/ESIConnectionLibraryTests/ESIConnectionLibraryTests.csproj");

        XUnit2Settings xunitSettings = new XUnit2Settings{
            // HtmlReport = true,
            OutputDirectory = "./TestOutput"
        };

        DotNetCoreTestSettings  settings = new DotNetCoreTestSettings {
            ResultsDirectory = "./TestOutput",
            Logger = "trx;LogFileName=TestOutput.xml"
        };

        foreach(var project in testAssemblies)
        {
            DotNetCoreTest(settings, project, xunitSettings);
        }
    }).OnError(exception =>
{
    // Handle the error here.
});

Task("Default")  
    .IsDependentOn("Test");

RunTarget(target);
