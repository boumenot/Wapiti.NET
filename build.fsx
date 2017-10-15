#r @"packages\FAKE\tools\FakeLib.dll"
open System
open System.IO
open Fake
open Fake.ReleaseNotesHelper
open Fake.Testing

let wapitiUrl = "https://github.com/boumenot/Wapiti/releases/download/2.1.0/wapiti-msvc-x64-release.zip"
let nugetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"

let authors = ["Christopher Boumenot"]
let project = "Wapiti.x64"
let summary = "Wapiti for .NET"
let description = "Wapiti for .NET"

let tags = ""

let testResultsDir = "./"

let release = parseReleaseNotes (IO.File.ReadAllLines "RELEASE_NOTES.md")

let buildMode = getBuildParamOrDefault "buildMode" "Debug" 

MSBuildDefaults <- {
  MSBuildDefaults with
    ToolsVersion = Some("14.0")
    Verbosity = Some(Minimal)
    Properties = 
        [
            "AllowUnsafeBlocks", "True"
            "Configuration", buildMode
            "DebugSymbols", "True"
            "Platform", "x64"
        ]
}

let properties = 
    match buildMode with
    | "Release" -> [ "Optimize", "True" ]
    | _ -> []

Target "Clean" (fun _ ->
    !! "./wapiti.sln"
    |> MSBuild "" "Clean" properties
    |> Log "Target::Clean"
)

Target "BuildSolution" (fun _ ->
    !! "./wapiti.sln"
    |> MSBuild "" "Build" properties
    |> Log "Target::BuildSolution"
)

Target "UnitTests" (fun _ ->
    !! (sprintf "./test/Wapiti.Test/bin/%s/Wapiti*.Test.dll" buildMode)
    |> xUnit2 (fun x -> { x with XmlOutputPath = Some(testResultsDir @@ "xunit2.xml");
                                 HtmlOutputPath = Some(testResultsDir @@ "xunit2.html");
                                 ToolPath = "packages/xunit.runner.console/tools/xunit.console.exe" })
)

#r "System.IO.Compression"
#r "System.IO.Compression.FileSystem"

Target "DownloadWapiti" (fun _ ->
  let zipFile = Path.GetFileName wapitiUrl
  if not (File.Exists zipFile) then 
    let c = new System.Net.WebClient()
    c.DownloadFile(wapitiUrl, zipFile)
    System.IO.Compression.ZipFile.ExtractToDirectory(zipFile, "wapiti.native")
)

// ==================================================
// NuGet

let referenceDependencies dependencies =
    let packagesDir = __SOURCE_DIRECTORY__  @@ "packages"
    [ for dependency in dependencies -> dependency, GetPackageVersion packagesDir dependency ]

Target "DownloadNuGet" (fun _ ->
  let nugetExe= Path.GetFileName nugetUrl
  if not (File.Exists nugetExe) then 
    CreateDir "./.nuget"
    let c = new System.Net.WebClient()
    c.DownloadFile(nugetUrl, "./.nuget/" + nugetExe)
)

// == wapiti.X.Y.Z.nupkg
Target "NuGet" (fun _ ->
    NuGet (fun x ->
        { x with
            Authors = authors
            Project = project
            Summary = summary
            Description = description
            Version = release.NugetVersion
            ReleaseNotes = String.Join(Environment.NewLine, release.Notes)
            Tags = tags
            AccessKey = getBuildParamOrDefault "nugetkey" ""
            Publish = hasBuildParam "nugetkey"
            Files = [ (@"..\nuget\build\wapiti.x64.props",                Some @"build\wapiti.x64.props",   None)
                      (@"..\wapiti.native\libwapiti.dll",                 Some @"native\x64\libwapiti.dll", None)
                      (@"..\src\Wapiti\bin" @@ buildMode @@ "Wapiti.dll", Some @"lib\net45",                None) ] })
        ("nuget/" + project + ".nuspec")
)

Target "Default" DoNothing

"Clean"
  ==> "DownloadWapiti"
  ==> "BuildSolution"
  ==> "UnitTests"
  ==> "DownloadNuGet"
  ==> "NuGet"
  ==> "Default"

RunTargetOrDefault "Default"
