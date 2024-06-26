﻿namespace Cake.Issues.Reporting.Generic;

using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core.IO;

/// <summary>
/// Settings for <see cref="GenericIssueReportFormatAliases"/>.
/// </summary>
public class GenericIssueReportFormatSettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GenericIssueReportFormatSettings"/> class.
    /// </summary>
    /// <param name="template">Template to use for generating the report.</param>
    protected GenericIssueReportFormatSettings(GenericIssueReportTemplate template)
    {
        using (var stream = this.GetType().Assembly.GetManifestResourceStream("Cake.Issues.Reporting.Generic.Templates." + template.GetTemplateResourceName()))
        {
            if (stream == null)
            {
                throw new ApplicationException($"Could not load resource {template}");
            }

            using (var sr = new StreamReader(stream))
            {
                this.Template = sr.ReadToEnd();
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericIssueReportFormatSettings"/> class.
    /// </summary>
    /// <param name="templatePath">Path to the template to use for generating the report.</param>
    protected GenericIssueReportFormatSettings(FilePath templatePath)
    {
        templatePath.NotNull();

        using (var stream = new FileStream(templatePath.FullPath, FileMode.Open, FileAccess.Read))
        {
            using (var sr = new StreamReader(stream))
            {
                this.Template = sr.ReadToEnd();
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericIssueReportFormatSettings"/> class.
    /// </summary>
    /// <param name="templateContent">Content of the template to use for generating the report.</param>
    protected GenericIssueReportFormatSettings(string templateContent)
    {
        templateContent.NotNullOrWhiteSpace();

        this.Template = templateContent;
    }

    /// <summary>
    /// Gets the template to use for generating the report.
    /// </summary>
    public string Template { get; }

    /// <summary>
    /// Gets the options to use for generating the report.
    /// See template for available options.
    /// </summary>
    public Dictionary<string, object> Options { get; } = [];

    /// <summary>
    /// Returns a new instance of the <see cref="GenericIssueReportFormatSettings"/> class from a template file on disk.
    /// </summary>
    /// <param name="template">Template to use for generating the report.</param>
    /// <returns>Instance of the <see cref="GenericIssueReportFormatSettings"/> class.</returns>
    public static GenericIssueReportFormatSettings FromEmbeddedTemplate(GenericIssueReportTemplate template) =>
        new(template);

    /// <summary>
    /// Returns a new instance of the <see cref="GenericIssueReportFormatSettings"/> class from a template file on disk.
    /// </summary>
    /// <param name="templatePath">Path to the template to use for generating the report.</param>
    /// <returns>Instance of the <see cref="GenericIssueReportFormatSettings"/> class.</returns>
    public static GenericIssueReportFormatSettings FromFilePath(FilePath templatePath) =>
        new(templatePath);

    /// <summary>
    /// Returns a new instance of the <see cref="GenericIssueReportFormatSettings"/> class from the content
    /// of a template file.
    /// </summary>
    /// <param name="templateContent">Content of the template to use for generating the report.</param>
    /// <returns>Instance of the <see cref="GenericIssueReportFormatSettings"/> class.</returns>
    public static GenericIssueReportFormatSettings FromContent(string templateContent) =>
        new(templateContent);
}
