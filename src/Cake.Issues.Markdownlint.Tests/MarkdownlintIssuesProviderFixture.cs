﻿namespace Cake.Issues.Markdownlint.Tests;

using Cake.Issues.Markdownlint;

internal class MarkdownlintIssuesProviderFixture<T>
    : BaseMultiFormatIssueProviderFixture<MarkdownlintIssuesProvider, MarkdownlintIssuesSettings, T>
    where T : BaseMarkdownlintLogFileFormat
{
    public MarkdownlintIssuesProviderFixture(string fileResourceName)
        : base(fileResourceName)
    {
        this.ReadIssuesSettings =
            new ReadIssuesSettings(@"c:\Source\Cake.Issues");
    }

    protected override string FileResourceNamespace => "Cake.Issues.Markdownlint.Tests.Testfiles." + typeof(T).Name + ".";
}
