﻿namespace Cake.Issues.Markdownlint;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

/// <content>
/// Aliases to read markdownlint issues.
/// </content>
public static partial class MarkdownlintIssuesAliases
{
    /// <summary>
    /// Gets the name of the Markdownlint issue provider.
    /// This name can be used to identify issues based on the <see cref="IIssue.ProviderType"/> property.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>Name of the Markdownlint issue provider.</returns>
    [CakePropertyAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static string MarkdownlintIssuesProviderTypeName(
        this ICakeContext context)
    {
        context.NotNull();

        return MarkdownlintIssuesProvider.ProviderTypeName;
    }

    /// <summary>
    /// Gets an instance of a provider for issues reported by Markdownlint using a log file from disk.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="logFilePath">Path to the Markdownlint log file.
    /// The log file needs to be in the format as defined by the <paramref name="format"/> parameter.</param>
    /// <param name="format">Format of the provided Markdownlint log file.</param>
    /// <returns>Instance of a provider for issues reported by Markdownlint.</returns>
    /// <example>
    /// <para>Read issues reported by Cake.Markdownlint:</para>
    /// <code>
    /// <![CDATA[
    ///     var issues =
    ///         ReadIssues(
    ///             MarkdownlintIssuesFromFilePath(
    ///                 @"c:\build\Markdownlint.log",
    ///                 MarkdownlintCliLogFileFormat),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider MarkdownlintIssuesFromFilePath(
        this ICakeContext context,
        FilePath logFilePath,
        BaseMarkdownlintLogFileFormat format)
    {
        context.NotNull();
        logFilePath.NotNull();
        format.NotNull();

        return context.MarkdownlintIssues(new MarkdownlintIssuesSettings(logFilePath, format));
    }

    /// <summary>
    /// Gets an instance of a provider for issues reported by Markdownlint using log file content.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="logFileContent">Content of the Markdownlint log file.
    /// The log file needs to be in the format as defined by the <paramref name="format"/> parameter.</param>
    /// <param name="format">Format of the provided Markdownlint log file.</param>
    /// <returns>Instance of a provider for issues reported by Markdownlint.</returns>
    /// <example>
    /// <para>Read issues reported by Markdownlint:</para>
    /// <code>
    /// <![CDATA[
    ///     var issues =
    ///         ReadIssues(
    ///             MarkdownlintIssuesFromContent(
    ///                 logFileContent,
    ///                 MarkdownlintLogFileFormat),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider MarkdownlintIssuesFromContent(
        this ICakeContext context,
        string logFileContent,
        BaseMarkdownlintLogFileFormat format)
    {
        context.NotNull();
        logFileContent.NotNullOrWhiteSpace();
        format.NotNull();

        return context.MarkdownlintIssues(new MarkdownlintIssuesSettings(logFileContent, format));
    }

    /// <summary>
    /// Gets an instance of a provider for issues reported by Markdownlint using specified settings.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">Settings for reading the Markdownlint log.</param>
    /// <returns>Instance of a provider for issues reported by Markdownlint.</returns>
    /// <example>
    /// <para>Read issues reported by Cake.Markdownlint:</para>
    /// <code>
    /// <![CDATA[
    ///     var settings =
    ///         new MarkdownlintIssuesSettings(
    ///             @"C:\build\Markdownlint.log",
    ///             MarkdownlintCliLogFileFormat);
    ///
    ///     var issues =
    ///         ReadIssues(
    ///             MarkdownlintIssues(settings),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider MarkdownlintIssues(
        this ICakeContext context,
        MarkdownlintIssuesSettings settings)
    {
        context.NotNull();
        settings.NotNull();

        return new MarkdownlintIssuesProvider(context.Log, settings);
    }
}
