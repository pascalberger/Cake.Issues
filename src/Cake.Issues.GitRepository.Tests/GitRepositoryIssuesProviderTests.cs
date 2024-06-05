namespace Cake.Issues.GitRepository.Tests;

using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Core;

public sealed class GitRepositoryIssuesProviderTests
{
    public sealed class TheCtor
    {
        [Fact]
        public void Should_Throw_If_CakeLog_Is_Null()
        {
            // Given
            ICakeLog log = null;
            ICakeEnvironment environment = new FakeEnvironment(PlatformFamily.Linux);
            IFileSystem fileSystem = new FakeFileSystem(environment);
            IProcessRunner processRunner = null;
            IToolLocator toolLocator = null;
            GitRepositoryIssuesSettings issueProviderSettings = new GitRepositoryIssuesSettings();

            // When
            var result = Record.Exception(() => new GitRepositoryIssuesProvider(log, fileSystem, environment, processRunner, toolLocator, issueProviderSettings));

            // Then
            result.IsArgumentNullException("log");
        }
    }
}