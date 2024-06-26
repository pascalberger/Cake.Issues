﻿namespace Cake.Issues.Markdownlint;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.Issues.Markdownlint.LogFileFormat;

/// <content>
/// Aliases for provider to read issues reported by markdownlint-cli with <c>--json</c> parameter.
/// </content>
public static partial class MarkdownlintIssuesAliases
{
    /// <summary>
    /// Gets an instance for the log format as written by markdownlint-cli with <c>--json</c> parameter.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>Instance for the Markdownlint log format.</returns>
    [CakePropertyAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static BaseMarkdownlintLogFileFormat MarkdownlintCliJsonLogFileFormat(
        this ICakeContext context)
    {
        context.NotNull();

        return new MarkdownlintCliJsonLogFileFormat(context.Log);
    }
}
