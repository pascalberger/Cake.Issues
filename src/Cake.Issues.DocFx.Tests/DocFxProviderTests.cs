﻿namespace Cake.Issues.DocFx.Tests;

using System.Runtime.InteropServices;

public sealed class DocFxProviderTests
{
    public sealed class TheCtor
    {
        [Fact]
        public void Should_Throw_If_Log_Is_Null()
        {
            // Given / When
            var result = Record.Exception(() =>
                new DocFxIssuesProvider(
                    null,
                    new DocFxIssuesSettings("Foo".ToByteArray(), @"c:\Source\Cake.Issues")));

            // Then
            result.IsArgumentNullException("log");
        }

        [Fact]
        public void Should_Throw_If_IssueProviderSettings_Are_Null()
        {
            var result = Record.Exception(() =>
                new DocFxIssuesProvider(
                    new FakeLog(),
                    null));

            // Then
            result.IsArgumentNullException("issueProviderSettings");
        }
    }

    public sealed class TheReadIssuesMethod
    {
        [SkippableTheory]
        [InlineData(@"c:\Source\Cake.Issues\docs", "docs/")]
        [InlineData("docs", "docs/")]
        [InlineData(@"c:\Source\Cake.Issues\src\docs", "src/docs/")]
        [InlineData(@"src\docs", "src/docs/")]
        [InlineData(@"c:\Source\Cake.Issues", "")]
        [InlineData("./", "")]
        public void Should_Read_Issue_Correct(string docRootPath, string docRelativePath)
        {
            // Uses Windows specific paths.
            Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));

            // Given
            var fixture = new DocFxProviderFixture("docfx.json", docRootPath);

            // When
            var issues = fixture.ReadIssues().ToList();

            // Then
            issues.Count.ShouldBe(1);
            IssueChecker.Check(
                issues[0],
                IssueBuilder.NewIssue(
                    "Invalid cross reference \"[Foo](xref:foo)\".",
                    "Cake.Issues.DocFx.DocFxIssuesProvider",
                    "DocFX")
                    .InFile(docRelativePath + "index.md")
                    .OfRule("Build Document.LinkPhaseHandler.Apply Templates")
                    .WithPriority(IssuePriority.Warning));
        }

        [SkippableFact]
        public void Should_Read_Line_Correct()
        {
            // Uses Windows specific paths.
            Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));

            // Given
            var fixture = new DocFxProviderFixture("entry-with-line.json", "./");

            // When
            var issues = fixture.ReadIssues().ToList();

            // Then
            issues.Count.ShouldBe(1);
            IssueChecker.Check(
                issues[0],
                IssueBuilder.NewIssue(
                    "Invalid file link:(~/foo.md).",
                    "Cake.Issues.DocFx.DocFxIssuesProvider",
                    "DocFX")
                    .InFile("bar.md", 45)
                    .OfRule("Build Document.LinkPhaseHandler.ConceptualDocumentProcessor.Save")
                    .WithPriority(IssuePriority.Warning));
        }

        [SkippableFact]
        public void Should_Read_Line_Zero_Correct()
        {
            // Uses Windows specific paths.
            Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));

            // Given
            var fixture = new DocFxProviderFixture("entry-with-line-0.json", "./");

            // When
            var issues = fixture.ReadIssues().ToList();

            // Then
            issues.Count.ShouldBe(1);
            IssueChecker.Check(
                issues[0],
                IssueBuilder.NewIssue(
                    "Invalid file link:(~/foo.md).",
                    "Cake.Issues.DocFx.DocFxIssuesProvider",
                    "DocFX")
                    .InFile("~/toc.yml")
                    .OfRule("BuildCore.Build Document.LinkPhaseHandlerWithIncremental.TocDocumentProcessor.Save")
                    .WithPriority(IssuePriority.Warning));
        }

        [SkippableFact]
        public void Should_Read_Suggestions_Correct()
        {
            // Uses Windows specific paths.
            Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));

            // Given
            var fixture = new DocFxProviderFixture("entry-of-level-suggestion.json", "./");

            // When
            var issues = fixture.ReadIssues().ToList();

            // Then
            issues.Count.ShouldBe(1);
            IssueChecker.Check(
                issues[0],
                IssueBuilder.NewIssue(
                    "Invalid file link:(~/foo.md).",
                    "Cake.Issues.DocFx.DocFxIssuesProvider",
                    "DocFX")
                    .InFile("bar.md", 45)
                    .OfRule("Build Document.LinkPhaseHandler.ConceptualDocumentProcessor.Save")
                    .WithPriority(IssuePriority.Suggestion));
        }
    }
}
