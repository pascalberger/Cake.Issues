---
title: Examples
description: Examples for using the Cake.Issues.Markdownlint addin.
---

The following example will call [markdownlint-cli] to lint some markdown files and outputs the number of warnings.

To call [markdownlint-cli] from a Cake script you can use the [Cake.Markdownlint] addin.

```csharp
#addin "Cake.Markdownlint"
```

To read issues from markdownlint-cli log files you need to import the core addin and the markdownlint support:

```csharp
#addin "Cake.Issues"
#addin "Cake.Issues.Markdownlint"
```

!!! warning
    Please note that you always should pin addins to a specific version to make sure your builds are deterministic and
    won't break due to updates to one of the addins.

    See [pinning addin versions](https://cakebuild.net/docs/writing-builds/reproducible-builds/){target="_blank"} for details.

We need some global variables:

```csharp
var logPath = @"c:\build\markdownlint.log";
var repoRootFolder = MakeAbsolute(Directory("./"));
```

The following task will run [markdownlint-cli] and write a log file:

```csharp
Task("Lint-Documentation").Does(() =>
{
    // Run markdownlint-cli.
    var settings =
        MarkdownlintNodeJsRunnerSettings.ForDirectory(repoRootPath.Combine("docs"));
    settings.OutputFile = logPath;
    settings.ThrowOnIssue = false;
    RunMarkdownlintNodeJs(settings);
});
```

Finally you can define a task where you call the core addin with the desired issue provider.

```csharp
Task("Read-Issues")
    .IsDependentOn("Lint-Documentation")
    .Does(() =>
    {
        // Read Issues.
        var issues =
            ReadIssues(
                MarkdownlintIssuesFromFilePath(
                    logPath,
                    MarkdownlintCliLogFileFormat),
                repoRootPath);

        Information("{0} issues are found.", issues.Count());
    });
```

[markdownlint-cli]: https://github.com/igorshubovych/markdownlint-cli
[Cake.Markdownlint]: https://www.nuget.org/packages/Cake.Markdownlint/
