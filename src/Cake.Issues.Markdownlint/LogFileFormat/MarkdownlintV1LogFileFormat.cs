﻿namespace Cake.Issues.Markdownlint.LogFileFormat;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using Cake.Core.Diagnostics;

/// <summary>
/// Logfile format as written by Markdownlint with <c>options.resultVersion</c> set to 1.
/// </summary>
/// <param name="log">The Cake log instance.</param>
internal class MarkdownlintV1LogFileFormat(ICakeLog log)
    : BaseMarkdownlintLogFileFormat(log)
{
    /// <inheritdoc />
    public override IEnumerable<IIssue> ReadIssues(
        MarkdownlintIssuesProvider issueProvider,
        IRepositorySettings repositorySettings,
        MarkdownlintIssuesSettings markdownlintIssuesSettings)
    {
        issueProvider.NotNull();
        repositorySettings.NotNull();
        markdownlintIssuesSettings.NotNull();

        Dictionary<string, IEnumerable<Issue>> logFileEntries;
        using (var ms = new MemoryStream(markdownlintIssuesSettings.LogFileContent.RemovePreamble()))
        {
            var jsonSerializer = new DataContractJsonSerializer(
                typeof(Dictionary<string, IEnumerable<Issue>>),
                settings: new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });

            logFileEntries = jsonSerializer.ReadObject(ms) as Dictionary<string, IEnumerable<Issue>>;
        }

        return
            from file in logFileEntries
            from entry in file.Value
            let
                rule = entry.ruleName
            select
                IssueBuilder
                    .NewIssue(entry.ruleDescription, issueProvider)
                    .InFile(file.Key, entry.lineNumber)
                    .WithPriority(IssuePriority.Warning)
                    .OfRule(rule, MarkdownlintRuleUrlResolver.Instance.ResolveRuleUrl(rule))
                    .Create();
    }
}
