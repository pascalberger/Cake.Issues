﻿namespace Cake.Issues.Reporting;

using System.Collections.Generic;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

/// <summary>
/// Base class for all report format implementations.
/// </summary>
/// <param name="log">The Cake log context.</param>
public abstract class IssueReportFormat(ICakeLog log)
    : BaseIssueComponent<ICreateIssueReportSettings>(log), IIssueReportFormat
{
    /// <inheritdoc />
    public FilePath CreateReport(IEnumerable<IIssue> issues)
    {
        issues.NotNullOrEmptyElement();

        this.AssertInitialized();

        return this.InternalCreateReport(issues);
    }

    /// <summary>
    /// Creates a report from a list of issues.
    /// Compared to <see cref="CreateReport"/> it is safe to access Settings from this method.
    /// </summary>
    /// <param name="issues">Issues for which the report should be created.</param>
    /// <returns>Path to the created report.</returns>
    protected abstract FilePath InternalCreateReport(IEnumerable<IIssue> issues);
}
