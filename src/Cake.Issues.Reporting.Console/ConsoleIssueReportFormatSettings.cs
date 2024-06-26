﻿namespace Cake.Issues.Reporting.Console;

/// <summary>
/// Settings for <see cref="ConsoleIssueReportFormatAliases"/>.
/// </summary>
public class ConsoleIssueReportFormatSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether diagnostics for the individual issues should be shown.
    /// Default value is <c>true</c>.
    /// </summary>
    public bool ShowDiagnostics { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the report should be rendered in compact mode.
    /// Default value is <c>false</c>.
    /// </summary>
    public bool Compact { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether issues should be grouped by rule or if
    /// for every issue a separate diagnostic should be created.
    /// Default value is <c>false</c>.
    /// </summary>
    public bool GroupByRule { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a summary of issues by provider / run
    /// should be shown.
    /// Default value is <c>false</c>.
    /// </summary>
    public bool ShowProviderSummary { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a summary of issues by provider / run
    /// with the number of issues for each priority should be shown.
    /// Default value is <c>false</c>.
    /// </summary>
    public bool ShowPrioritySummary { get; set; }
}
