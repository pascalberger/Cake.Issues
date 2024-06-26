#addin "Cake.Markdownlint"
#addin "Cake.Issues&prerelease"
#addin "Cake.Issues.MsBuild&prerelease"
#addin "Cake.Issues.Markdownlint&prerelease"
#addin "Cake.Issues.DupFinder&prerelease"
#addin "Cake.Issues.InspectCode&prerelease"

#tool nuget:?package=JetBrains.ReSharper.CommandLineTools&version=2021.2.2

#load build/build/build.cake
#load build/analyze/analyze.cake
#load build/create-issues/create-issues.cake

var target = Argument("target", "Default");

public class BuildData
{
    public DirectoryPath RepoRootFolder { get; }
    public DirectoryPath SourceFolder { get; }
    public DirectoryPath DocsFolder { get; }
    public List<IIssue> Issues { get; }

    public BuildData(ICakeContext context)
    {
        this.RepoRootFolder = context.MakeAbsolute(context.Directory("./"));
        this.SourceFolder = this.RepoRootFolder.Combine("src");
        this.DocsFolder = this.RepoRootFolder.Combine("docs");

        this.Issues = new List<IIssue>();
    }
}

Setup<BuildData>(setupContext =>
{
    return new BuildData(setupContext);
});

Task("Default")
    .IsDependentOn("Create-Issues");

RunTarget(target);
