#tool "nuget:?package=xunit.runner.console"

var target = Argument("target","BuildPackages");

Task("Build")
.Does(()=>{
    MSBuild("./src/PipelineTest.sln");
});
Task("RunUnitTests")
.IsDependentOn("Build")
    .Does(()=>{
        XUnit2("./src/PipelineTest.Tests/bin/debug/PipelineTest.Tests.dll");
    });
Task("BuildPackages")
	.IsDependentOn("RunUnitTests")
    .Does(() =>
{

	var buildResultDir = Directory("./build-output");
    var nuGetPackSettings = new NuGetPackSettings
	{
		OutputDirectory = buildResultDir.ToString()  + @"\artifacts\",
		IncludeReferencedProjects = true,
		Properties = new Dictionary<string, string>
		{
			{ "Configuration", "Debug" }
		}
	};
   
    NuGetPack("./src/PipelineTest/PipelineTest.nuspec", nuGetPackSettings);
});
RunTarget(target);