Task("Run-DupFinder")
    .Description("Runs JetBrains DupFinder analysis")
    .WithCriteria((context) => context.IsRunningOnWindows(), "DupFinder is only supported on Windows.")
    .Does<BuildData>((data) =>
{
    var dupFinderLogFilePath =
        data.RepoRootFolder.CombineWithFilePath("dupFinder.log");

    // Run DupFinder
    var settings = new DupFinderSettings() {
        OutputFile = dupFinderLogFilePath
    };

    DupFinder(
        data.SourceFolder.CombineWithFilePath("ClassLibrary1.sln"),
        settings);

    // Read issues
    var readIssuesSettings = new ReadIssuesSettings(data.RepoRootFolder)
    {
        FileLinkSettings =
            IssueFileLinkSettingsForGitHubBranch(
                new System.Uri("https://github.com/cake-contrib/Cake.Issues"),
                "develop",
                "tests/TestDataGenerator"
            )
    };

    data.Issues.AddRange(
        ReadIssues(
            DupFinderIssuesFromFilePath(dupFinderLogFilePath),
            readIssuesSettings));
});