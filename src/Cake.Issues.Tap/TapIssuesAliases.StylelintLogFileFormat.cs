﻿namespace Cake.Issues.Tap;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.Issues.Tap.LogFileFormat;

/// <content>
/// Aliases for provider to read issues in Test Anything Protocol file generated by Stylelint.
/// </content>
public static partial class TapIssuesAliases
{
    /// <summary>
    /// Gets an instance for the log format for Test Anything Protocol file generated by Stylelint.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>Instance for the Test Anything Protocol format generated by Stylelint.</returns>
    [CakePropertyAlias]
    [CakeAliasCategory(IssuesAliasConstants.IssueProviderCakeAliasCategory)]
    public static BaseTapLogFileFormat StylelintLogFileFormat(
        this ICakeContext context)
    {
        context.NotNull();

        return new StylelintLogFileFormat(context.Log);
    }
}
