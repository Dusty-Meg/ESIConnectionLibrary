#addin nuget:?package=Cake.Docker&version=0.9.3

var target = Argument("target", "Default");
var configuration = Argument("Configuration", "Release");
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

Task("DockerPull")
.IsDependentOn("Build")
	.Does(() => 
    {
		// or more containers at once
		DockerPull("antihax/mock-esi");
	});

Task("DockerRun")
.IsDependentOn("DockerPull")
	.Does(() => 
    {
		// or more containers at once
		StartProcess("C:\\WINDOWS\\system32\\WindowsPowerShell\\v1.0\\powershell.exe", "docker run -d -p 127.0.0.1:8080:8080 --name mock-esi antihax/mock-esi");
	});

Task("Test")  
.IsDependentOn("DockerRun")
    .Does(() =>
    {
        var projects = GetFiles("./ESIConnectionLibrary/ESIConnectionLibraryTests/*.csproj");
        foreach(var project in projects)
        {
            Information("Testing project " + project);
            DotNetCoreTest(
                project.ToString(),
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true,
                    ArgumentCustomization = args => args.Append("--no-restore"),
                });
        }
    })
    .OnError(exception =>
    {
    });

Task("DockerRm")
    .IsDependentOn("Test")
	.Does(() => 
    {
        DockerStop("mock-esi");
		DockerRm("mock-esi");
	});

Task("Default")  
    .IsDependentOn("DockerRm");

RunTarget(target);