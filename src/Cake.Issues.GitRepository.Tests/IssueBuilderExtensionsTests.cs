﻿namespace Cake.Issues.GitRepository.Tests;

public sealed class IssueBuilderExtensionsTests
{
    public sealed class TheOfRuleMethod
    {
        [Fact]
        public void Should_Throw_If_IssueBuilder_Is_Null()
        {
            // Given
            IssueBuilder issueBuilder = null;
            var ruleDescription = new BinaryFileNotTrackedByLfsRuleDescription();
            var issueProviderVersion = "1.0.0";

            // When
            var result = Record.Exception(() => issueBuilder.OfRule(ruleDescription, issueProviderVersion));

            // Then
            result.IsArgumentNullException("issueBuilder");
        }

        [Fact]
        public void Should_Throw_If_RuleDescription_Is_Null()
        {
            // Given
            var issueBuilder = IssueBuilder.NewIssue("message", "providerType", "providerName");
            var issueProviderVersion = "1.0.0";
            BaseGitRepositoryIssuesRuleDescription ruleDescription = null;

            // When
            var result = Record.Exception(() => issueBuilder.OfRule(ruleDescription, issueProviderVersion));

            // Then
            result.IsArgumentNullException("ruleDescription");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_Use_Latest_If_IssueProviderVersion_Is_Not_Set(string issueProviderVersion)
        {
            // Given
            var issueBuilder = IssueBuilder.NewIssue("message", "providerType", "providerName");
            var ruleDescription = new BinaryFileNotTrackedByLfsRuleDescription();

            // When
            var result = issueBuilder.OfRule(ruleDescription, issueProviderVersion);

            // Then
            result.Create().RuleUrl.ToString().ShouldBe("https://cakeissues.net/latest/documentation/issue-providers/gitrepository/rules/BinaryFileNotTrackedByLfs");
        }

        [Fact]
        public void Should_Set_RuleId()
        {
            // Given
            var issueBuilder = IssueBuilder.NewIssue("message", "providerType", "providerName");
            var issueProviderVersion = "1.0.0";
            var ruleDescription = new BinaryFileNotTrackedByLfsRuleDescription();

            // When
            var result = issueBuilder.OfRule(ruleDescription, issueProviderVersion);

            // Then
            result.Create().RuleId.ShouldBe(ruleDescription.RuleId);
        }

        [Fact]
        public void Should_Set_RuleName()
        {
            // Given
            var issueBuilder = IssueBuilder.NewIssue("message", "providerType", "providerName");
            var issueProviderVersion = "1.0.0";
            var ruleDescription = new BinaryFileNotTrackedByLfsRuleDescription();

            // When
            var result = issueBuilder.OfRule(ruleDescription, issueProviderVersion);

            // Then
            result.Create().RuleName.ShouldBe(ruleDescription.RuleName);
        }

        [Fact]
        public void Should_Set_RuleUrl()
        {
            // Given
            var issueBuilder = IssueBuilder.NewIssue("message", "providerType", "providerName");
            var issueProviderVersion = "1.0.0";
            var ruleDescription = new BinaryFileNotTrackedByLfsRuleDescription();

            // When
            var result = issueBuilder.OfRule(ruleDescription, issueProviderVersion);

            // Then
            result.Create().RuleUrl.ToString().ShouldBe("https://cakeissues.net/1.0.0/documentation/issue-providers/gitrepository/rules/BinaryFileNotTrackedByLfs");
        }

        [Fact]
        public void Should_Set_Priority()
        {
            // Given
            var issueBuilder = IssueBuilder.NewIssue("message", "providerType", "providerName");
            var issueProviderVersion = "1.0.0";
            var ruleDescription = new BinaryFileNotTrackedByLfsRuleDescription();

            // When
            var result = issueBuilder.OfRule(ruleDescription, issueProviderVersion);

            // Then
            result.Create().Priority.ShouldBe((int)ruleDescription.Priority);
        }

        [Fact]
        public void Should_Set_PriorityName()
        {
            // Given
            var issueBuilder = IssueBuilder.NewIssue("message", "providerType", "providerName");
            var issueProviderVersion = "1.0.0";
            var ruleDescription = new BinaryFileNotTrackedByLfsRuleDescription();

            // When
            var result = issueBuilder.OfRule(ruleDescription, issueProviderVersion);

            // Then
            result.Create().PriorityName.ShouldBe(ruleDescription.Priority.ToString());
        }
    }
}
