namespace Cake.Issues.PullRequests.Tests;

using Cake.Core.Diagnostics;
using Spectre.Console.Testing;

internal class OrchestratorForIssueProvidersFixture
{
    public OrchestratorForIssueProvidersFixture()
        : this((builder, _) => builder)
    {
    }

    public OrchestratorForIssueProvidersFixture(
        Func<FakePullRequestSystemBuilder, IReportIssuesToPullRequestSettings, FakePullRequestSystemBuilder> pullRequestSettings)
    {
        pullRequestSettings.NotNull();

        this.Log = new FakeLog { Verbosity = Verbosity.Normal };

        this.Console = new TestConsole();

        this.IssueProviders = [new(this.Log)];

        this.Settings =
            new ReportIssuesToPullRequestFromIssueProviderSettings(
                @"c:\Source\Cake.Issues");

        var pullRequestSystemBuilder = FakePullRequestSystemBuilder.NewPullRequestSystem(this.Log);
        pullRequestSystemBuilder =
            pullRequestSettings(pullRequestSystemBuilder, this.Settings);
        this.PullRequestSystem = pullRequestSystemBuilder.Create();
    }

    public FakeLog Log { get; set; }

    public TestConsole Console { get; set; }

    public IList<FakeIssueProvider> IssueProviders { get; set; }

    public FakePullRequestSystem PullRequestSystem { get; set; }

    public IReportIssuesToPullRequestFromIssueProviderSettings Settings { get; set; }

    public PullRequestIssueResult RunOrchestrator()
    {
        var orchestrator =
            new Orchestrator(
                this.Log,
                this.Console,
                this.PullRequestSystem);
        return
            orchestrator.Run(
                this.IssueProviders,
                this.Settings);
    }
}
