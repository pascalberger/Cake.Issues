﻿namespace Cake.Issues.DocFx;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

/// <summary>
/// Contains functionality related to read warnings from DocFx log files.
/// </summary>
[CakeAliasCategory(IssuesAliasConstants.MainCakeAliasCategory)]
public static class DocFxIssuesAliases
{
    /// <summary>
    /// Gets the name of the DocFx issue provider.
    /// This name can be used to identify issues based on the <see cref="IIssue.ProviderType"/> property.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>Name of the DocFx issue provider.</returns>
    [CakePropertyAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static string DocFxIssuesProviderTypeName(
        this ICakeContext context)
    {
        context.NotNull();

        return DocFxIssuesProvider.ProviderTypeName;
    }

    /// <summary>
    /// Gets an instance of a provider for warnings reported by DocFx using a log file from disk
    /// for a DocFx project in the repository root.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="logFilePath">Path to the DocFx log file.</param>
    /// <returns>Instance of a provider for warnings reported by DocFx.</returns>
    /// <example>
    /// <para>Read warnings reported by DocFx:</para>
    /// <code>
    /// <![CDATA[
    ///     var issues =
    ///         ReadIssues(
    ///             DocFxIssuesFromFilePath(@"c:\build\docfx.log"),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider DocFxIssuesFromFilePath(
        this ICakeContext context,
        FilePath logFilePath)
    {
        context.NotNull();
        logFilePath.NotNull();

        return context.DocFxIssuesFromFilePath(logFilePath, "/");
    }

    /// <summary>
    /// Gets an instance of a provider for warnings reported by DocFx using a log file from disk.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="logFilePath">Path to the DocFx log file.</param>
    /// <param name="docRootPath">Path to the root directory of the DocFx project.
    /// Either the full path or the path relative to the repository root.</param>
    /// <returns>Instance of a provider for warnings reported by DocFx.</returns>
    /// <example>
    /// <para>Read warnings reported by DocFx:</para>
    /// <code>
    /// <![CDATA[
    ///     var issues =
    ///         ReadIssues(
    ///             DocFxIssuesFromFilePath(
    ///                 @"c:\build\docfx.log",
    ///                 @"c:\build\doc")),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider DocFxIssuesFromFilePath(
        this ICakeContext context,
        FilePath logFilePath,
        DirectoryPath docRootPath)
    {
        context.NotNull();
        logFilePath.NotNull();
        docRootPath.NotNull();

        return context.DocFxIssues(new DocFxIssuesSettings(logFilePath, docRootPath));
    }

    /// <summary>
    /// Gets an instance of a provider for warnings reported by DocFx using log file content
    /// for a DocFx project in the repository root.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="logFileContent">Content of the DocFx log file.</param>
    /// <returns>Instance of a provider for warnings reported by DocFx.</returns>
    /// <example>
    /// <para>Read warnings reported by DocFx:</para>
    /// <code>
    /// <![CDATA[
    ///     var issues =
    ///         ReadIssues(
    ///             DocFxIssuesFromContent(logFileContent)),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider DocFxIssuesFromContent(
        this ICakeContext context,
        string logFileContent)
    {
        context.NotNull();
        logFileContent.NotNullOrWhiteSpace();

        return context.DocFxIssues(new DocFxIssuesSettings(logFileContent.ToByteArray(), "/"));
    }

    /// <summary>
    /// Gets an instance of a provider for warnings reported by DocFx using log file content.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="logFileContent">Content of the DocFx log file.</param>
    /// <param name="docRootPath">Path to the root directory of the DocFx project.
    /// Either the full path or the path relative to the repository root.</param>
    /// <returns>Instance of a provider for warnings reported by DocFx.</returns>
    /// <example>
    /// <para>Read warnings reported by DocFx:</para>
    /// <code>
    /// <![CDATA[
    ///     var issues =
    ///         ReadIssues(
    ///             DocFxIssuesFromContent(
    ///                 logFileContent,
    ///                 @"c:\build\doc")),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider DocFxIssuesFromContent(
        this ICakeContext context,
        string logFileContent,
        DirectoryPath docRootPath)
    {
        context.NotNull();
        logFileContent.NotNullOrWhiteSpace();
        docRootPath.NotNull();

        return context.DocFxIssues(new DocFxIssuesSettings(logFileContent.ToByteArray(), docRootPath));
    }

    /// <summary>
    /// Gets an instance of a provider for warnings reported by DocFx using specified settings.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">Settings for reading the DocFx log.</param>
    /// <returns>Instance of a provider for warnings reported by DocFx.</returns>
    /// <example>
    /// <para>Read warnings reported by DocFx:</para>
    /// <code>
    /// <![CDATA[
    ///     var settings =
    ///         new DocFxIssuesSettings(@"c:\build\docfx.log");
    ///
    ///     var issues =
    ///         ReadIssues(
    ///             DocFxIssues(settings),
    ///             @"c:\repo");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static IIssueProvider DocFxIssues(
        this ICakeContext context,
        DocFxIssuesSettings settings)
    {
        context.NotNull();
        settings.NotNull();

        return new DocFxIssuesProvider(context.Log, settings);
    }
}
