﻿namespace Cake.Issues.Tests.Testing;

public sealed class BaseIssueProviderFixtureTests
{
    public sealed class TheCtor
    {
        [Fact]
        public void Should_Set_Log()
        {
            // Given

            // When
            var result = new FakeIssueProviderFixture();

            // Then
            _ = result.Log.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Set_RepositorySettings()
        {
            // Given

            // When
            var result = new FakeIssueProviderFixture();

            // Then
            _ = result.ReadIssuesSettings.ShouldNotBeNull();
        }
    }

    public sealed class TheReadIssuesMethod
    {
        [Fact]
        public void Should_Throw_If_Log_Is_Null()
        {
            // Given
            var fixture = new FakeIssueProviderFixture
            {
                Log = null,
            };

            // When
            var result = Record.Exception(fixture.ReadIssues);

            // Then
            result.IsInvalidOperationException("No log instance set.");
        }

        [Fact]
        public void Should_Throw_If_RepositorySettings_Are_Null()
        {
            // Given
            var fixture = new FakeIssueProviderFixture
            {
                ReadIssuesSettings = null,
            };

            // When
            var result = Record.Exception(fixture.ReadIssues);

            // Then
            result.IsInvalidOperationException("No settings for reading issues set.");
        }

        [Fact]
        public void Should_Return_Issues()
        {
            // Given
            var issue =
                IssueBuilder
                    .NewIssue("Message Foo", "ProviderType Foo", "ProviderName Foo")
                    .Create();
            var fixture = new FakeIssueProviderFixture([issue]);

            // When
            var result = fixture.ReadIssues().ToList();

            // Then
            result.Count.ShouldBe(1);
            result.ShouldContain(issue);
        }
    }
}
