﻿namespace Cake.Issues.InspectCode;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

/// <summary>
/// Contains functionality for reading issues from JetBrains Inspect Code log files.
/// </summary>
[CakeAliasCategory(IssuesAliasConstants.MainCakeAliasCategory)]
public static class InspectCodeIssuesAliases
{
    /// <summary>
    /// Gets the name of the Inspect Code issue provider.
    /// This name can be used to identify issues based on the <see cref="IIssue.ProviderType"/> property.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>Name of the Inspect Code issue provider.</returns>
    [CakePropertyAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static string InspectCodeIssuesProviderTypeName(
        this ICakeContext context)
    {
        context.NotNull();

        return typeof(InspectCodeIssuesProvider).FullName;
    }

    /// <summary>
    /// Gets an instance of a provider for issues reported by JetBrains Inspect Code using a log file from disk.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="logFilePath">Path to the InspectCode log file.</param>
    /// <returns>Instance of a provider for issues reported by JetBrains Inspect Code.</returns>
    /// <example>
    /// <para>Read issues reported by JetBrains Inspect Code:</para>
    /// <code>
    /// <![CDATA[
    ///     var issues =
    ///         ReadIssues(
    ///             InspectCodeIssuesFromFilePath(@"c:\build\InspectCode.log"),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider InspectCodeIssuesFromFilePath(
        this ICakeContext context,
        FilePath logFilePath)
    {
        context.NotNull();
        logFilePath.NotNull();

        return context.InspectCodeIssues(new InspectCodeIssuesSettings(logFilePath));
    }

    /// <summary>
    /// Gets an instance of a provider for issues reported by JetBrains Inspect Code using log file content.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="logFileContent">Content of the Inspect Code log file.</param>
    /// <returns>Instance of a provider for issues reported by JetBrains Inspect Code.</returns>
    /// <example>
    /// <para>Read issues reported by JetBrains Inspect Code:</para>
    /// <code>
    /// <![CDATA[
    ///     var issues =
    ///         ReadIssues(
    ///             InspectCodeIssuesFromContent(logFileContent)),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider InspectCodeIssuesFromContent(
        this ICakeContext context,
        string logFileContent)
    {
        context.NotNull();
        logFileContent.NotNullOrWhiteSpace();

        return context.InspectCodeIssues(new InspectCodeIssuesSettings(logFileContent.ToByteArray()));
    }

    /// <summary>
    /// Gets an instance of a provider for issues reported by JetBrains Inspect Code using specified settings.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">Settings for reading the Inspect Code log.</param>
    /// <returns>Instance of a provider for issues reported by JetBrains Inspect Code.</returns>
    /// <example>
    /// <para>Read issues reported by JetBrains Inspect Code:</para>
    /// <code>
    /// <![CDATA[
    ///     var settings =
    ///         new InspectCodeIssuesSettings(
    ///             @"c:\build\InspectCode.log));
    ///
    ///     var issues =
    ///         ReadIssues(
    ///             InspectCodeIssues(settings),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider InspectCodeIssues(
        this ICakeContext context,
        InspectCodeIssuesSettings settings)
    {
        context.NotNull();
        settings.NotNull();

        return new InspectCodeIssuesProvider(context.Log, settings);
    }
}
