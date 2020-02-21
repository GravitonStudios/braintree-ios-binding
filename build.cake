#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=3.2.1

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var VERSION = "4.32.0";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solutionPath = "./braintree-ios.sln";
var artifacts = new [] {
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.BraintreeCore.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.BraintreeCore.iOS.nuspec",
        Dependencies = new string [] { 
        },
        Name = "Core"
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.BraintreeCard.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.BraintreeCard.iOS.nuspec",
        Dependencies = new [] { 
            "GravitonStudios.BraintreeCore.iOS"
        },
        Name = "Card"
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.BraintreeApplePay.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.BraintreeApplePay.iOS.nuspec",
        Dependencies = new [] { 
            "GravitonStudios.BraintreeCore.iOS"
        },
        Name = "ApplePay"
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.BraintreeUnionPay.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.BraintreeUnionPay.iOS.nuspec",
        Dependencies = new [] { 
            "GravitonStudios.BraintreeCard.iOS"
        },
        Name = "UnionPay"
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.PayPalUtils.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.PayPalUtils.iOS.nuspec",
        Dependencies = new string[] {
        },
        Name = "PayPal Utils"
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.PayPalDataCollector.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.PayPalDataCollector.iOS.nuspec",
        Dependencies = new [] { 
            "GravitonStudios.PayPalUtils.iOS"
        }
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.PayPalOneTouch.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.PayPalOneTouch.iOS.nuspec",
        Dependencies = new string[] { 
            "GravitonStudios.BraintreeCore.iOS",
            "GravitonStudios.PayPalDataCollector.iOS"
        },
        Name = "PayPal OneTouch"
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.BraintreePayPal.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.BraintreePayPal.iOS.nuspec",
        Dependencies = new [] { 
            "GravitonStudios.PayPalOneTouch.iOS"
        },
        Name = "PayPal"
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.CardinalMobile.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.CardinalMobile.iOS.nuspec",
        Dependencies = new string[] { 
        },
        Name = "CardinalMobile"
    },
    new Artifact {
        AssemblyInfoPath = "./GravitonStudios.BraintreePaymentFlow.iOS/Properties/AssemblyInfo.cs",
        NuspecPath = "./nuspec/GravitonStudios.BraintreePaymentFlow.iOS.nuspec",
        Dependencies = new [] { 
            "GravitonStudios.BraintreeCard.iOS",
            "GravitonStudios.CardinalMobile.iOS"
        },
        Name = "PaymentFlow"
    },
};

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory("./packages");

    var nugetPackages = GetFiles("./*.nupkg");

    foreach (var package in nugetPackages)
    {
        DeleteFile(package);
    }
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solutionPath);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    MSBuild(solutionPath, settings => settings.SetConfiguration(configuration));
});

Task("UpdateVersion")
    .Does(() => 
{
    foreach(var artifact in artifacts) {
        ReplaceRegexInFiles(artifact.AssemblyInfoPath, "\\[assembly\\: AssemblyVersion([^\\]]+)\\]", string.Format("[assembly: AssemblyVersion(\"{0}\")]", VERSION));
    }
});

Task("Pack")
    .IsDependentOn("UpdateVersion")
    .IsDependentOn("Build")
    .Does(() =>
{
    foreach(var artifact in artifacts) {
        NuGetPack(artifact.NuspecPath, new NuGetPackSettings {
            Version = VERSION,
            ReleaseNotes = new [] {
                string.Format("Braintree iOS SDK v{0} - {1}", VERSION, artifact.Name)
            },
            Dependencies = artifact.Dependencies.Select(x =>
                new NuSpecDependency {
                    Id = x,
                    Version = VERSION
                }).ToArray()
        });
    }
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Pack");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);

class Artifact {
    public string AssemblyInfoPath { get; set; }

    public string NuspecPath { get; set; }

    public string[] Dependencies { get; set; }

    public string Name { get; set; }
}
