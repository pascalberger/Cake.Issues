---
title: Examples
description: Examples for using the Cake.Issues.Reporting.Console addin.
---

The following example will print issues logged as warnings by MsBuild to the console.

!!! warning
    Please note that you always should pin addins and tools to a specific version to make sure your builds are deterministic and
    won't break due to updates to one of the packages.

    See [pinning addin versions](https://cakebuild.net/docs/writing-builds/reproducible-builds/){target="_blank"} for details.

```csharp
#tool "nuget:?package=MSBuild.Extension.Pack"
#addin "Cake.Issues"
#addin "Cake.Issues.MsBuild"
#addin "Cake.Issues.Reporting"
#addin "Cake.Issues.Reporting.Console"

Task("Create-IssueReport").Does(() =>
{
    var repoRootFolder = new DirectoryPath(@"c:\repo");

    // Build MySolution.sln solution in the repository root folder and log issues
    // using XmlFileLogger from MSBuild Extension Pack.
    FilePath msBuildLogFile = @"c:\build\msbuild.log";
    var settings = new MsBuildSettings()
        .WithLogger(
            Context.Tools.Resolve("MSBuild.ExtensionPack.Loggers.dll").FullPath,
            "XmlFileLogger",
            string.Format(
                "logfile=\"{0}\";verbosity=Detailed;encoding=UTF-8",
                msBuildLogFile)
        );
    MSBuild(repoRootFolder.CombineWithFilePath("MySolution.sln"), settings);

    // Write issues to console.
    CreateIssueReport(
        new List<IIssueProvider>
        {
            MsBuildIssuesFromFilePath(
                msBuildLogFile,
                MsBuildXmlFileLoggerFormat)
        },
        ConsoleIssueReportFormat(
            new ConsoleIssueReportFormatSettings
            {
                GroupByRule = true,
                ShowProviderSummary = true,
                ShowPrioritySummary = true
            }),
        repoRootFolder,
        string.Empty);
});
```
