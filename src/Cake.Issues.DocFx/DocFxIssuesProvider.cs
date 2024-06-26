﻿namespace Cake.Issues.DocFx;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

/// <summary>
/// Provider for warnings reported by DocFx.
/// </summary>
/// <param name="log">The Cake log context.</param>
/// <param name="issueProviderSettings">Settings for the issue provider.</param>
internal class DocFxIssuesProvider(ICakeLog log, DocFxIssuesSettings issueProviderSettings)
    : BaseConfigurableIssueProvider<DocFxIssuesSettings>(log, issueProviderSettings)
{
    /// <summary>
    /// Gets the name of the DocFx issue provider.
    /// This name can be used to identify issues based on the <see cref="IIssue.ProviderType"/> property.
    /// </summary>
    public static string ProviderTypeName => typeof(DocFxIssuesProvider).FullName;

    /// <inheritdoc />
    public override string ProviderName => "DocFX";

    /// <inheritdoc />
    protected override IEnumerable<IIssue> InternalReadIssues()
    {
        // Determine path of the doc root.
        var docRootPath = this.IssueProviderSettings.DocRootPath;
        if (docRootPath.IsRelative)
        {
            docRootPath = docRootPath.MakeAbsolute(this.Settings.RepositoryRoot);
        }

        IEnumerable<LogEntryDataContract> logFileEntries;

        var logFileContent = this.IssueProviderSettings.LogFileContent.ToStringUsingEncoding(true);

        logFileContent =
            "[" +
                string.Join(",", logFileContent.SplitLines()) +
            "]";

        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(logFileContent)))
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(LogEntryDataContract[]));
            logFileEntries = jsonSerializer.ReadObject(ms) as LogEntryDataContract[];
        }

        return
            from logEntry in logFileEntries
            let file = this.TryGetFile(logEntry.file, docRootPath)
            let line = TryGetLine(logEntry.line)
            where
                (logEntry.message_severity == "warning" || logEntry.message_severity == "suggestion") &&
                !string.IsNullOrWhiteSpace(logEntry.message)
            select
                IssueBuilder
                    .NewIssue(logEntry.message, this)
                    .InFile(file, line)
                    .OfRule(logEntry.source)
                    .WithPriority(GetPriority(logEntry.message_severity))
                    .Create();
    }

    /// <summary>
    /// Converts the severity to a priority.
    /// </summary>
    /// <param name="severity">Severity as reported by DocFX.</param>
    /// <returns>Priority.</returns>
    private static IssuePriority GetPriority(string severity) =>
        severity.ToLowerInvariant() switch
        {
            "warning" => IssuePriority.Warning,
            "suggestion" => IssuePriority.Suggestion,
            _ => IssuePriority.Undefined,
        };

    /// <summary>
    /// Reads the affected line from an issue logged in a DocFx log file.
    /// </summary>
    /// <param name="line">The line in the current log entry.</param>
    /// <returns>The line of the issue.</returns>
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1515:Single-line comment should be preceded by blank line", Justification = "Not in expression bodies")]
    private static int? TryGetLine(int? line) =>
        // Convert negative line numbers or line number 0 to null
        line is <= 0 ? null : line;

    /// <summary>
    /// Reads the affected file path from an issue logged in a DocFx log file.
    /// </summary>
    /// <param name="fileName">The file name in the current log entry.</param>
    /// <param name="docRootPath">Absolute path to the root of the DocFx project.</param>
    /// <returns>The full path to the affected file.</returns>
    private string TryGetFile(
        string fileName,
        DirectoryPath docRootPath)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return null;
        }

        // Add path to repository root
        fileName = docRootPath.CombineWithFilePath(fileName).FullPath;

        // Make path relative to repository root.
        fileName = fileName[this.Settings.RepositoryRoot.FullPath.Length..];

        // Remove leading directory separator.
        if (fileName.StartsWith('/'))
        {
            fileName = fileName[1..];
        }

        return fileName;
    }
}